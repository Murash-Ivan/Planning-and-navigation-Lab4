using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lab4
{
    public partial class Form1 : Form
    {
        //Размер полигона
        private const int COLS = 64;      // Ширина
        private const int ROWS = 40;      // Высота
        private const int CELL_SIZE = 10; // Размер одной клетки в пикселях

        // Массив для сетки
        private int[,] grid;

        private Point? startPos = null;
        private Point? endPos = null;

        private UdpClient udpClient;
        private Thread receiveThread;
        private bool isRunning = false;

        private double cellSizeMeters = 0.25;
        private double robotDiameterMeters = 0.6;

        private int vppMode = 0; // Данные впп

        // данные от симулятора
        private double robotX = 0.75;      
        private double robotY = 0.75;      
        private double robotTheta = 0.0;  
        private int[] distances = new int[8]; 
        private int[] lineSensors = new int[5]; 
        private int bumper = 0;           

        private bool[,] configSpace;
        private bool showConfigSpace = false;
        private const double ROBOT_RADIUS_M = 0.3;
        private double robotRadiusCells;

        private class AStarNode
        {
            public int X, Y, G, H, F;
            public AStarNode Parent;
            public bool IsClosed;
        }

        private List<Point> astarPath = new List<Point>();
        private AStarNode[,] astarGrid = new AStarNode[ROWS, COLS];
        private bool isSearching = false;

        public Form1()
        {
            InitializeComponent();

            // Инициализируем сетку при старте
            grid = new int[ROWS, COLS];

            txtCellSizeM.Text = cellSizeMeters.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtRobotDiamM.Text = robotDiameterMeters.ToString(System.Globalization.CultureInfo.InvariantCulture);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, pnlMap, new object[] { true });

            LogMessage("Приложение готово. Загрузите карту");
        }

        //Отрисовка карты
        private void PnlMap_Paint(object sender, PaintEventArgs e)
        {
            UpdatePhysicalParameters();

            Graphics g = e.Graphics;

            // Рисую сетку
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    Color cellColor = grid[r, c] == 1 ? Color.Black : Color.White;
                    using (SolidBrush brush = new SolidBrush(cellColor))
                    {
                        g.FillRectangle(brush, c * CELL_SIZE, r * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                    }
                    g.DrawRectangle(Pens.LightGray, c * CELL_SIZE, r * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                }
            }

            // Рисую карту конфигурации
            if (showConfigSpace && configSpace != null)
            {
                for (int r = 0; r < ROWS; r++)
                {
                    for (int c = 0; c < COLS; c++)
                    {
                        if (configSpace[r, c])
                        {
                            using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, Color.Lime)))
                            {
                                g.FillRectangle(brush, c * CELL_SIZE, r * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                            }
                        }
                    }
                }
            }

            // Отрисовка А*
            if (astarPath.Count > 0 || isSearching)
            {
                // рисую градиент стоимости
                for (int r = 0; r < ROWS; r++)
                {
                    for (int c = 0; c < COLS; c++)
                    {
                        if (astarGrid[r, c] != null && astarGrid[r, c].G != int.MaxValue)
                        {
                            Color cellColor = GetGradientColor(astarGrid[r, c].F, COLS + ROWS);
                            using (SolidBrush brush = new SolidBrush(cellColor))
                            {
                                g.FillRectangle(brush, c * CELL_SIZE, r * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                            }
                        }
                    }
                }

                // рисую итоговый путь
                if (astarPath.Count > 1)
                {
                    using (Pen pathPen = new Pen(Color.Magenta, 3))
                    {
                        for (int i = 0; i < astarPath.Count - 1; i++)
                        {
                            float x1 = astarPath[i].X * CELL_SIZE + CELL_SIZE / 2f;
                            float y1 = astarPath[i].Y * CELL_SIZE + CELL_SIZE / 2f;
                            float x2 = astarPath[i + 1].X * CELL_SIZE + CELL_SIZE / 2f;
                            float y2 = astarPath[i + 1].Y * CELL_SIZE + CELL_SIZE / 2f;
                            g.DrawLine(pathPen, x1, y1, x2, y2);
                        }
                    }
                }
            }

            // Рисую точки старта и финиша
            if (startPos.HasValue)
            {
                int c = startPos.Value.X;
                int r = startPos.Value.Y;
                g.FillEllipse(Brushes.Green, c * CELL_SIZE + 2, r * CELL_SIZE + 2, CELL_SIZE - 4, CELL_SIZE - 4);
            }

            if (endPos.HasValue)
            {
                int c = endPos.Value.X;
                int r = endPos.Value.Y;
                g.FillEllipse(Brushes.Blue, c * CELL_SIZE + 2, r * CELL_SIZE + 2, CELL_SIZE - 4, CELL_SIZE - 4);
            }

            // рисую ВПП на карте
            if (vppMode == 1 && isRunning)
            {
                DrawVPP(e.Graphics, 1.0f, 0, 0);
            }

            // Рисую робота на карте
            if (isRunning && vppMode == 1)
            {
                double cellSize = (cellSizeMeters > 0) ? cellSizeMeters : 0.25;
                float cx = (float)(robotX / cellSize * CELL_SIZE);
                float cy = (float)(pnlMap.Height - (robotY / cellSize * CELL_SIZE));
                float r = (float)((robotDiameterMeters / 2.0) / cellSize * CELL_SIZE);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, Color.Orange)))
                {
                    e.Graphics.FillEllipse(brush, cx - r, cy - r, r * 2, r * 2);
                }
                e.Graphics.DrawEllipse(Pens.Black, cx - r, cy - r, r * 2, r * 2);

                double thetaRad = robotTheta * Math.PI / 180.0;
                float arrowLen = r * 1.5f;
                float ax = cx + (float)(Math.Sin(thetaRad) * arrowLen);
                float ay = cy - (float)(Math.Cos(thetaRad) * arrowLen);

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, cx, cy, ax, ay);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdMap.ShowDialog() == DialogResult.OK)
            {
                LoadMapFromFile(ofdMap.FileName);
            }
        }

        private void LoadMapFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                LogMessage("Ошибка: Файл не найден!");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // очищаю сетку
                grid = new int[ROWS, COLS];

                startPos = null;
                endPos = null;

                // читаю файл
                for (int r = 0; r < Math.Min(ROWS, lines.Length); r++)
                {
                    string line = lines[r];
                    for (int c = 0; c < Math.Min(COLS, line.Length); c++)
                    {
                        char ch = line[c];

                        if (ch == '#')
                        {
                            grid[r, c] = 1; // Стена
                        }
                        else if (ch == '.' || char.IsDigit(ch))
                        {
                            grid[r, c] = 0; // Свободно
                        }
                        else
                        {
                            grid[r, c] = 1; // Все остальные символы считаю стенами
                        }
                    }
                }

                // перерисовка карты
                pnlMap.Invalidate();
                LogMessage($"Карта успешно загружена из: {Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                LogMessage($"Ошибка чтения файла: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdMap.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfdMap.FileName))
                    {
                        for (int r = 0; r < ROWS; r++)
                        {
                            string line = "";
                            for (int c = 0; c < COLS; c++)
                            {
                                line += grid[r, c] == 1 ? '#' : '.';
                            }
                            sw.WriteLine(line);
                        }
                    }
                    LogMessage("Карта успешно сохранена!");
                }
                catch (Exception ex)
                {
                    LogMessage($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        private void LogMessage(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        private void PnlMap_MouseClick(object sender, MouseEventArgs e)
        {
            int c = e.X / CELL_SIZE;
            int r = e.Y / CELL_SIZE;

            if (c >= 0 && c < COLS && r >= 0 && r < ROWS)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // ЛКМ переключает состояние ячейки
                    grid[r, c] = 1 - grid[r, c];
                }
                else if (e.Button == MouseButtons.Right && !Control.ModifierKeys.HasFlag(Keys.Shift))
                {
                    // ПКМ устанавливает старт
                    SetStart(c, r);
                }
                else if (e.Button == MouseButtons.Right && Control.ModifierKeys.HasFlag(Keys.Shift))
                {
                    // Shift+ПКМ устанавливаеи финиш
                    SetEnd(c, r);
                }

                pnlMap.Invalidate();
            }
        }

        private void SetStart(int c, int r)
        {
            startPos = new Point(c, r);
            int logicalY = ROWS - 1 - r;
            txtStartX.Text = c.ToString();
            txtStartY.Text = logicalY.ToString();
            LogMessage($"Старт: X={c}, Y={logicalY}");
        }

        private void SetEnd(int c, int r)
        {
            endPos = new Point(c, r);
            int logicalY = ROWS - 1 - r;
            txtEndX.Text = c.ToString();
            txtEndY.Text = logicalY.ToString();
            LogMessage($"Финиш: X={c}, Y={logicalY}");
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnApplyStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStartX.Text, out int x) && int.TryParse(txtStartY.Text, out int y))
            {
                if (x >= 0 && x < COLS && y >= 0 && y < ROWS)
                {
                    int c = x;
                    int r = ROWS - 1 - y;
                    SetStart(c, r);
                    pnlMap.Invalidate();
                }
                else
                {
                    LogMessage("Координаты вне диапазона");
                }
            }
        }

        private void btnApplyEnd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEndX.Text, out int x) && int.TryParse(txtEndY.Text, out int y))
            {
                if (x >= 0 && x < COLS && y >= 0 && y < ROWS)
                {
                    int c = x;
                    int r = ROWS - 1 - y;
                    SetEnd(c, r);
                    pnlMap.Invalidate();
                }
                else
                {
                    LogMessage("Координаты вне диапазона");
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartUdpServer();
                btnConnect.Text = "Отключиться";
                lblStatus.Text = "Статус: Подключено";
            }
            else
            {
                StopUdpServer();
                btnConnect.Text = "Подключиться";
                lblStatus.Text = "Статус: Отключено";
            }
        }

        private void StartUdpServer()
        {
            try
            {
                int localPort = int.Parse(txtLocalPort.Text);
                udpClient = new UdpClient(localPort);
                isRunning = true;

                receiveThread = new Thread(new ThreadStart(ReceiveData));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
                isRunning = false;
            }
        }

        private void StopUdpServer()
        {
            isRunning = false;

            if (udpClient != null)
            {
                udpClient.Close();
            }

            if (receiveThread != null && receiveThread.IsAlive)
            {
                receiveThread.Join(1000);
            }
        }

        private void ReceiveData()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (isRunning)
            {
                try
                {
                    byte[] data = udpClient.Receive(ref remoteEndPoint);
                    string message = Encoding.UTF8.GetString(data);

                    this.Invoke((MethodInvoker)delegate {
                        UpdateUI(message);
                    });
                }
                catch (Exception ex)
                {
                    if (isRunning)
                    {
                        Console.WriteLine($"Ошибка приема: {ex.Message}");
                    }
                }
            }
        }

        private void UpdateUI(string message)
        {
            message = message.Trim();

            if (string.IsNullOrEmpty(message) || message == "0" || message.Contains("0 0 0 0 0"))
            {
                return;
            }

            if (message.Contains("{") && message.Contains("}"))
            {
                txtRawData.AppendText(message + Environment.NewLine);
                txtRawData.AppendText(new string('-', 50) + Environment.NewLine);

                txtRawData.SelectionStart = txtRawData.Text.Length;
                txtRawData.ScrollToCaret();

                if (txtRawData.Text.Length > 10000)
                {
                    int cutOff = txtRawData.Text.IndexOf(Environment.NewLine);
                    if (cutOff > 0)
                    {
                        txtRawData.Text = txtRawData.Text.Substring(cutOff);
                    }
                }
                ParseAndDisplayData(message);
            }
        }

        private void ParseAndDisplayData(string jsonMessage)
        {
            try
            {
                if (double.TryParse(GetJsonValue(jsonMessage, "x").Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double rx))
                    robotX = rx;

                if (double.TryParse(GetJsonValue(jsonMessage, "y").Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double ry))
                    robotY = ry;

                if (double.TryParse(GetJsonValue(jsonMessage, "t").Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double rt))
                    robotTheta = rt;

                if (int.TryParse(GetJsonValue(jsonMessage, "b"), out int bVal))
                    bumper = bVal;

                for (int i = 0; i < 8; i++)
                {
                    if (int.TryParse(GetJsonValue(jsonMessage, $"d{i}"), out int d))
                        distances[i] = d;
                }

                for (int i = 0; i < 5; i++)
                {
                    if (int.TryParse(GetJsonValue(jsonMessage, $"l{i}"), out int l))
                        lineSensors[i] = l;
                }

                UpdateTextBox("txtSimX", robotX.ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
                UpdateTextBox("txtSimY", robotY.ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
                UpdateTextBox("txtSimTheta", robotTheta.ToString("F1", System.Globalization.CultureInfo.InvariantCulture));

                for (int i = 0; i < 8; i++)
                {
                    UpdateTextBox($"txtD{i}", distances[i].ToString());
                }

                for (int i = 0; i < 5; i++)
                {
                    UpdateTextBox($"txtL{i}", lineSensors[i].ToString());
                }

                UpdateTextBox("txtAzimuth", GetJsonValue(jsonMessage, "az"));
                UpdateTextBox("txtDistance", GetJsonValue(jsonMessage, "ad"));
                UpdateTextBox("txtBumper", bumper.ToString());
                UpdateTextBox("txtCode", GetJsonValue(jsonMessage, "c"));
                UpdateTextBox("txtLeftEncoder", GetJsonValue(jsonMessage, "le"));
                UpdateTextBox("txtRightEncoder", GetJsonValue(jsonMessage, "re"));

                pnlMap.Invalidate();
                pnlVPP.Invalidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка парсинга данных: {ex.Message}");
            }
        }

        private void UpdateTextBox(string name, string value)
        {
            var controls = this.Controls.Find(name, true);
            if (controls.Length > 0 && controls[0] is TextBox tb)
            {
                tb.Text = string.IsNullOrEmpty(value) ? "0" : value;
            }
        }

        private string GetJsonValue(string json, string key)
        {
            string searchPattern = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchPattern);

            if (keyIndex == -1)
                return "0";

            int valueStart = keyIndex + searchPattern.Length;

            while (valueStart < json.Length && (json[valueStart] == ' ' || json[valueStart] == '"'))
                valueStart++;

            int valueEnd = valueStart;
            while (valueEnd < json.Length && json[valueEnd] != ',' && json[valueEnd] != '}' && json[valueEnd] != '"')
                valueEnd++;

            if (valueStart >= valueEnd)
                return "0";

            string value = json.Substring(valueStart, valueEnd - valueStart).Trim();

            return string.IsNullOrEmpty(value) ? "0" : value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
            {
                StopUdpServer();
            }
        }

        // считывание параметров из текстбоксов
        private void UpdatePhysicalParameters()
        {
            if (double.TryParse(txtCellSizeM.Text.Replace(',', '.'), out double cSize))
                cellSizeMeters = cSize;

            if (double.TryParse(txtRobotDiamM.Text.Replace(',', '.'), out double rDiam))
                robotDiameterMeters = rDiam;
        }

        private void btnToggleVPP_Click(object sender, EventArgs e)
        {
            vppMode = (vppMode + 1) % 3;

            if (vppMode == 0)
            {
                btnToggleVPP.Text = "ВПП: Скрыто";
                pnlVPP.Visible = false;
            }
            else if (vppMode == 1)
            {
                btnToggleVPP.Text = "ВПП: На карте";
                pnlVPP.Visible = false;
            }
            else
            {
                btnToggleVPP.Text = "ВПП: Отдельно";
                pnlVPP.Visible = true;
            }

            pnlMap.Invalidate();
            pnlVPP.Invalidate();
        }

        // Метод отрисовки впп
        private void DrawVPP(Graphics g, float scale, float offsetX, float offsetY)
        {
            double cellSize = cellSizeMeters > 0 ? cellSizeMeters : 0.25;

            float centerX = offsetX + (float)(robotX / cellSize * CELL_SIZE * scale);
            float centerY = offsetY + (float)(pnlMap.Height - (robotY / cellSize * CELL_SIZE) * scale);
            float robotRadiusPx = (float)((robotDiameterMeters / 2.0) / cellSize * CELL_SIZE * scale);

            // Рисую корпус робота
            Color robotColor = bumper == 1 ? Color.Red : Color.Orange;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, robotColor)))
            {
                g.FillEllipse(brush, centerX - robotRadiusPx, centerY - robotRadiusPx, robotRadiusPx * 2, robotRadiusPx * 2);
            }
            g.DrawEllipse(Pens.Black, centerX - robotRadiusPx, centerY - robotRadiusPx, robotRadiusPx * 2, robotRadiusPx * 2);

            // Рисую курс
            double thetaRad = robotTheta * Math.PI / 180.0;
            float arrowLen = robotRadiusPx * 1.5f;
            float endX = centerX + (float)(Math.Sin(thetaRad) * arrowLen);
            float endY = centerY - (float)(Math.Cos(thetaRad) * arrowLen);

            using (Pen pen = new Pen(Color.Black, 2 * scale))
            {
                g.DrawLine(pen, centerX, centerY, endX, endY);
            }

            // Рисую лучи дальномеров
            using (Pen rayPen = new Pen(Color.Blue, 1.5f * scale))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (distances[i] > 0 && distances[i] < 500)
                    {
                        double sensorAngleRad = thetaRad + (i * 45.0 * Math.PI / 180.0);
                        float distM = distances[i] / 100.0f;
                        float rayLenPx = (float)(distM / cellSize * CELL_SIZE * scale);

                        // Начальная точка
                        float startX = centerX + (float)(Math.Sin(sensorAngleRad) * robotRadiusPx);
                        float startY = centerY - (float)(Math.Cos(sensorAngleRad) * robotRadiusPx);

                        // Конечная точка
                        float rayEndX = startX + (float)(Math.Sin(sensorAngleRad) * rayLenPx);
                        float rayEndY = startY - (float)(Math.Cos(sensorAngleRad) * rayLenPx);

                        g.DrawLine(rayPen, startX, startY, rayEndX, rayEndY);

                        // Точка на конце луча
                        g.FillEllipse(Brushes.Blue, rayEndX - 2 * scale, rayEndY - 2 * scale, 4 * scale, 4 * scale);
                    }
                }
            }
        }

        private void PnlVPP_Paint(object sender, PaintEventArgs e)
        {
            // Очищаю панель белым фоном
            e.Graphics.Clear(Color.White);

            // Если данные не идут, ничего не рисуем
            if (!isRunning || vppMode != 2)
            {
                return;
            }

            // Параметры для отрисовки строго по центру
            float centerX = pnlVPP.Width / 2f;
            float centerY = pnlVPP.Height / 2f;

            float robotRadius = 10f;
            float rayScale = 15f;
            float maxRayLength = 140f;

            // отрисовка кругов
            using (Pen gridPen = new Pen(Color.LightGray, 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            using (Font font = new Font("Arial", 8, FontStyle.Regular))
            {
                for (int i = 1; i <= 4; i++)
                {
                    float radius = robotRadius + (i * rayScale);
                    e.Graphics.DrawEllipse(gridPen, centerX - radius, centerY - radius, radius * 2, radius * 2);

                    string label = $"{i} м";
                    SizeF textSize = e.Graphics.MeasureString(label, font);
                    e.Graphics.DrawString(label, font, Brushes.Gray, centerX - (textSize.Width / 2), centerY - radius - 14);
                }
            }

            // отрисовка робота
            Color robotColor = (bumper == 1) ? Color.Red : Color.Orange;
            using (SolidBrush brush = new SolidBrush(robotColor))
            {
                e.Graphics.FillEllipse(brush, centerX - robotRadius, centerY - robotRadius, robotRadius * 2, robotRadius * 2);
            }
            e.Graphics.DrawEllipse(Pens.Black, centerX - robotRadius, centerY - robotRadius, robotRadius * 2, robotRadius * 2);

            // отрисвока курса
            double thetaRad = robotTheta * Math.PI / 180.0;
            float arrowLen = robotRadius * 1.5f;
            float endX = centerX + (float)(Math.Sin(thetaRad) * arrowLen);
            float endY = centerY - (float)(Math.Cos(thetaRad) * arrowLen);

            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(pen, centerX, centerY, endX, endY);
            }

            // отрисвока лучей дальномеров
            using (Pen rayPen = new Pen(Color.Blue, 1.5f))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (distances[i] > 0 && distances[i] < 400)
                    {
                        double sensorAngleRad = thetaRad + (i * 45.0 * Math.PI / 180.0);
                        float distM = distances[i] / 100.0f;
                        float rayLen = distM * rayScale;

                        if (rayLen > maxRayLength)
                            rayLen = maxRayLength;

                        float startX = centerX + (float)(Math.Sin(sensorAngleRad) * robotRadius);
                        float startY = centerY - (float)(Math.Cos(sensorAngleRad) * robotRadius);

                        UpdatePhysicalParameters();
                        double currentRobotRadiusMeters = robotDiameterMeters / 2.0;
                        robotRadius = (float)(currentRobotRadiusMeters * rayScale);

                        if (robotRadius < 5f) robotRadius = 5f;

                        float rayEndX = startX + (float)(Math.Sin(sensorAngleRad) * rayLen);
                        float rayEndY = startY - (float)(Math.Cos(sensorAngleRad) * rayLen);

                        e.Graphics.DrawLine(rayPen, startX, startY, rayEndX, rayEndY);
                        e.Graphics.FillEllipse(Brushes.Blue, rayEndX - 2f, rayEndY - 2f, 4f, 4f);
                    }
                }
            }
        }

        private void btnConfigSpace_Click(object sender, EventArgs e)
        {
            showConfigSpace = !showConfigSpace;

            if (showConfigSpace)
            {
                UpdatePhysicalParameters();
                BuildConfigSpace();

                btnConfigSpace.Text = "Скрыть карту";
                LogMessage("Карта конфигурации пересчитана и отображена");
            }
            else
            {
                btnConfigSpace.Text = "Показать карту";
            }
            pnlMap.Invalidate();
        }

        private void BuildConfigSpace()
        {
            // считаю радиус робота в клетках
            robotRadiusCells = (robotDiameterMeters / 2.0) / cellSizeMeters;
            configSpace = new bool[ROWS, COLS];

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    bool isPassable = true;

                    // если клетка стена, то центр робота тут быть не может
                    if (grid[r, c] == 1)
                    {
                        isPassable = false;
                    }
                    else
                    {
                        int checkRadius = (int)Math.Ceiling(robotRadiusCells) + 1;

                        for (int dr = -checkRadius; dr <= checkRadius; dr++)
                        {
                            for (int dc = -checkRadius; dc <= checkRadius; dc++)
                            {
                                int nr = r + dr;
                                int nc = c + dc;

                                // если за границой карты это стена
                                if (nr < 0 || nr >= ROWS || nc < 0 || nc >= COLS)
                                {
                                    isPassable = false;
                                    break;
                                }

                                // если рядом стена
                                if (grid[nr, nc] == 1)
                                {
                                    double closestX = Math.Max(nc - 0.5, Math.Min(c, nc + 0.5));
                                    double closestY = Math.Max(nr - 0.5, Math.Min(r, nr + 0.5));
                                    double dist = Math.Sqrt(Math.Pow(c - closestX, 2) + Math.Pow(r - closestY, 2));

                                    // если стена ближе, чем радиус робота клетка заблокирована
                                    if (dist <= robotRadiusCells)
                                    {
                                        isPassable = false;
                                        break;
                                    }
                                }
                            }
                            if (!isPassable) break;
                        }
                    }
                    configSpace[r, c] = isPassable;
                }
            }
            pnlMap.Invalidate();
            LogMessage($"Карта конфигурации построена (Радиус робота: {robotRadiusCells:F2} клетки)");
        }

        private async void btnRunAStar_Click(object sender, EventArgs e)
        {
            if (startPos == null || endPos == null)
            {
                LogMessage("Ошибка: Укажите точки Старта и Финиша!");
                return;
            }

            UpdatePhysicalParameters();
            BuildConfigSpace();

            isSearching = true;
            btnRunAStar.Enabled = false;
            btnRunAStar.Text = "Поиск";
            astarPath.Clear();

            // Инициализация сетки A*
            for (int r = 0; r < ROWS; r++)
                for (int c = 0; c < COLS; c++)
                    astarGrid[r, c] = new AStarNode { X = c, Y = r, G = int.MaxValue, H = 0, F = int.MaxValue, Parent = null, IsClosed = false };

            List<AStarNode> openSet = new List<AStarNode>();
            AStarNode startNode = astarGrid[startPos.Value.Y, startPos.Value.X];
            startNode.G = 0;
            startNode.H = Math.Abs(startPos.Value.X - endPos.Value.X) + Math.Abs(startPos.Value.Y - endPos.Value.Y);
            startNode.F = startNode.H;
            openSet.Add(startNode);

            int maxF = COLS + ROWS;

            while (openSet.Count > 0)
            {
                AStarNode current = openSet.OrderBy(n => n.F).First();
                openSet.Remove(current);
                current.IsClosed = true;

                // если финиш
                if (current.X == endPos.Value.X && current.Y == endPos.Value.Y)
                {
                    ReconstructPath(current);
                    LogMessage($"Путь найден. Длина: {astarPath.Count} клеток.");
                    break;
                }

                // проверка 4 соседей
                int[] dx = { 0, 0, -1, 1 };
                int[] dy = { -1, 1, 0, 0 };

                for (int i = 0; i < 4; i++)
                {
                    int nx = current.X + dx[i];
                    int ny = current.Y + dy[i];

                    if (nx < 0 || nx >= COLS || ny < 0 || ny >= ROWS) continue;
                    AStarNode neighbor = astarGrid[ny, nx];

                    if (neighbor.IsClosed || !configSpace[ny, nx]) continue;

                    int tentativeG = current.G + 1;
                    if (tentativeG < neighbor.G)
                    {
                        neighbor.Parent = current;
                        neighbor.G = tentativeG;
                        neighbor.H = Math.Abs(nx - endPos.Value.X) + Math.Abs(ny - endPos.Value.Y);
                        neighbor.F = neighbor.G + neighbor.H;

                        if (!openSet.Contains(neighbor)) openSet.Add(neighbor);
                    }
                }

                pnlMap.Invalidate();
                await Task.Delay(5);
            }

            isSearching = false;
            btnRunAStar.Enabled = true;
            btnRunAStar.Text = "Найти путь";
            pnlMap.Invalidate();
        }

        // сборка маршрута
        private void ReconstructPath(AStarNode endNode)
        {
            AStarNode current = endNode;
            while (current != null)
            {
                astarPath.Add(new Point(current.X, current.Y));
                current = current.Parent;
            }
            astarPath.Reverse();
        }

        private Color GetGradientColor(int f, int maxF)
        {
            double ratio = (double)f / maxF;

            if (ratio > 1.0) ratio = 1.0;
            if (ratio < 0.0) ratio = 0.0;

            int r = (int)(255 * ratio);
            int g = (int)(255 * (1.0 - ratio));
            int b = 0;

            return Color.FromArgb(150, r, g, b);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (astarPath == null || astarPath.Count < 2)
            {
                LogMessage("Ошибка: Сначала найдите маршрут");
                return;
            }

            if (sfdCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfdCSV.FileName, false, Encoding.UTF8))
                    {
                        // Прохожу по всем точкам кроме последней
                        for (int i = 0; i < astarPath.Count - 1; i++)
                        {
                            Point current = astarPath[i];
                            Point next = astarPath[i + 1];

                            int direction = GetDirection(current, next);

                            sw.WriteLine($"{direction};{current.X};{current.Y}");
                        }

                        Point last = astarPath[astarPath.Count - 1];
                        sw.WriteLine($"0;{last.X};{last.Y}");
                    }

                    LogMessage($"Маршрут сохранен в: {sfdCSV.FileName}");
                }
                catch (Exception ex)
                {
                    LogMessage($"Ошибка сохранения файла: {ex.Message}");
                }
            }
        }

        private int GetDirection(Point current, Point next)
        {
            if (next.Y < current.Y) return 1;
            if (next.X > current.X) return 2;
            if (next.Y > current.Y) return 3;
            if (next.X < current.X) return 4;

            return 0;
        }
    }
}