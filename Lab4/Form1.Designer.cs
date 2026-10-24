namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlMap = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.ofdMap = new System.Windows.Forms.OpenFileDialog();
            this.sfdMap = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunAStar = new System.Windows.Forms.Button();
            this.btnConfigSpace = new System.Windows.Forms.Button();
            this.txtRobotDiamM = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCellSizeM = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnApplyEnd = new System.Windows.Forms.Button();
            this.txtEndY = new System.Windows.Forms.TextBox();
            this.txtEndX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApplyStart = new System.Windows.Forms.Button();
            this.txtStartY = new System.Windows.Forms.TextBox();
            this.txtStartX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRawData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtL4 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtL2 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtL0 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtL1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtL3 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtD7 = new System.Windows.Forms.TextBox();
            this.txtD6 = new System.Windows.Forms.TextBox();
            this.txtD5 = new System.Windows.Forms.TextBox();
            this.txtD4 = new System.Windows.Forms.TextBox();
            this.txtD3 = new System.Windows.Forms.TextBox();
            this.txtD2 = new System.Windows.Forms.TextBox();
            this.txtD1 = new System.Windows.Forms.TextBox();
            this.txtD0 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBumper = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRightEncoder = new System.Windows.Forms.TextBox();
            this.txtLeftEncoder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlVPP = new System.Windows.Forms.Panel();
            this.btnToggleVPP = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.sfdCSV = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.BackColor = System.Drawing.Color.White;
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Location = new System.Drawing.Point(12, 12);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(1290, 780);
            this.pnlMap.TabIndex = 0;
            this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMap_Paint);
            this.pnlMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PnlMap_MouseClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoad.Location = new System.Drawing.Point(12, 798);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(183, 51);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(201, 798);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 51);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLog.Location = new System.Drawing.Point(12, 855);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(891, 366);
            this.txtLog.TabIndex = 3;
            // 
            // ofdMap
            // 
            this.ofdMap.FileName = "Labyrinth.txt";
            this.ofdMap.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // sfdMap
            // 
            this.sfdMap.FileName = "Labyrinth.txt";
            this.sfdMap.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.groupBox1.Controls.Add(this.btnExportCSV);
            this.groupBox1.Controls.Add(this.btnRunAStar);
            this.groupBox1.Controls.Add(this.btnConfigSpace);
            this.groupBox1.Controls.Add(this.txtRobotDiamM);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtCellSizeM);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.btnApplyEnd);
            this.groupBox1.Controls.Add(this.txtEndY);
            this.groupBox1.Controls.Add(this.txtEndX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnApplyStart);
            this.groupBox1.Controls.Add(this.txtStartY);
            this.groupBox1.Controls.Add(this.txtStartX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(909, 855);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 366);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Точки старта и финиша";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnRunAStar
            // 
            this.btnRunAStar.Location = new System.Drawing.Point(341, 172);
            this.btnRunAStar.Name = "btnRunAStar";
            this.btnRunAStar.Size = new System.Drawing.Size(310, 44);
            this.btnRunAStar.TabIndex = 15;
            this.btnRunAStar.Text = "Найти путь";
            this.btnRunAStar.UseVisualStyleBackColor = true;
            this.btnRunAStar.Click += new System.EventHandler(this.btnRunAStar_Click);
            // 
            // btnConfigSpace
            // 
            this.btnConfigSpace.Location = new System.Drawing.Point(6, 292);
            this.btnConfigSpace.Name = "btnConfigSpace";
            this.btnConfigSpace.Size = new System.Drawing.Size(319, 53);
            this.btnConfigSpace.TabIndex = 14;
            this.btnConfigSpace.Text = "Карта конфигураций";
            this.btnConfigSpace.UseVisualStyleBackColor = true;
            this.btnConfigSpace.Click += new System.EventHandler(this.btnConfigSpace_Click);
            // 
            // txtRobotDiamM
            // 
            this.txtRobotDiamM.Location = new System.Drawing.Point(240, 231);
            this.txtRobotDiamM.Name = "txtRobotDiamM";
            this.txtRobotDiamM.Size = new System.Drawing.Size(85, 38);
            this.txtRobotDiamM.TabIndex = 13;
            this.txtRobotDiamM.Text = "0.6";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 234);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(228, 31);
            this.label33.TabIndex = 12;
            this.label33.Text = "Диаметр робота:";
            // 
            // txtCellSizeM
            // 
            this.txtCellSizeM.Location = new System.Drawing.Point(240, 176);
            this.txtCellSizeM.Name = "txtCellSizeM";
            this.txtCellSizeM.Size = new System.Drawing.Size(85, 38);
            this.txtCellSizeM.TabIndex = 11;
            this.txtCellSizeM.Text = "0.25";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 179);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(213, 31);
            this.label29.TabIndex = 10;
            this.label29.Text = "Размер ячейки:";
            // 
            // btnApplyEnd
            // 
            this.btnApplyEnd.Location = new System.Drawing.Point(341, 109);
            this.btnApplyEnd.Name = "btnApplyEnd";
            this.btnApplyEnd.Size = new System.Drawing.Size(310, 46);
            this.btnApplyEnd.TabIndex = 9;
            this.btnApplyEnd.Text = "Установить финиш";
            this.btnApplyEnd.UseVisualStyleBackColor = true;
            this.btnApplyEnd.Click += new System.EventHandler(this.btnApplyEnd_Click);
            // 
            // txtEndY
            // 
            this.txtEndY.Location = new System.Drawing.Point(225, 114);
            this.txtEndY.Name = "txtEndY";
            this.txtEndY.Size = new System.Drawing.Size(100, 38);
            this.txtEndY.TabIndex = 8;
            // 
            // txtEndX
            // 
            this.txtEndX.Location = new System.Drawing.Point(52, 114);
            this.txtEndX.Name = "txtEndX";
            this.txtEndX.Size = new System.Drawing.Size(100, 38);
            this.txtEndX.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "X:";
            // 
            // btnApplyStart
            // 
            this.btnApplyStart.Location = new System.Drawing.Point(341, 39);
            this.btnApplyStart.Name = "btnApplyStart";
            this.btnApplyStart.Size = new System.Drawing.Size(310, 46);
            this.btnApplyStart.TabIndex = 4;
            this.btnApplyStart.Text = "Установить старт";
            this.btnApplyStart.UseVisualStyleBackColor = true;
            this.btnApplyStart.Click += new System.EventHandler(this.btnApplyStart_Click);
            // 
            // txtStartY
            // 
            this.txtStartY.Location = new System.Drawing.Point(225, 44);
            this.txtStartY.Name = "txtStartY";
            this.txtStartY.Size = new System.Drawing.Size(100, 38);
            this.txtStartY.TabIndex = 3;
            // 
            // txtStartX
            // 
            this.txtStartX.Location = new System.Drawing.Point(52, 44);
            this.txtStartX.Name = "txtStartX";
            this.txtStartX.Size = new System.Drawing.Size(100, 38);
            this.txtStartX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // gbConnection
            // 
            this.gbConnection.BackColor = System.Drawing.Color.Violet;
            this.gbConnection.Controls.Add(this.lblStatus);
            this.gbConnection.Controls.Add(this.btnConnect);
            this.gbConnection.Controls.Add(this.txtLocalPort);
            this.gbConnection.Controls.Add(this.label5);
            this.gbConnection.Controls.Add(this.txtRemotePort);
            this.gbConnection.Controls.Add(this.label6);
            this.gbConnection.Controls.Add(this.txtRemoteIP);
            this.gbConnection.Controls.Add(this.label7);
            this.gbConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbConnection.Location = new System.Drawing.Point(1308, 12);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(881, 211);
            this.gbConnection.TabIndex = 6;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "UDP подключение";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(283, 157);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(257, 31);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Статус: Отключено";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 106);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(240, 58);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Подключится";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(677, 106);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(183, 38);
            this.txtLocalPort.TabIndex = 5;
            this.txtLocalPort.Text = "5001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Локальный порт:";
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(677, 51);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(183, 38);
            this.txtRemotePort.TabIndex = 3;
            this.txtRemotePort.Text = "5000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Порт симулятора:";
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.BackColor = System.Drawing.Color.White;
            this.txtRemoteIP.Location = new System.Drawing.Point(230, 51);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(183, 38);
            this.txtRemoteIP.TabIndex = 1;
            this.txtRemoteIP.Text = "127.0.0.1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "IP симулятора:";
            // 
            // txtRawData
            // 
            this.txtRawData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRawData.Location = new System.Drawing.Point(1308, 560);
            this.txtRawData.Multiline = true;
            this.txtRawData.Name = "txtRawData";
            this.txtRawData.ReadOnly = true;
            this.txtRawData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRawData.Size = new System.Drawing.Size(1013, 232);
            this.txtRawData.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Plum;
            this.groupBox2.Controls.Add(this.txtL4);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtL2);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtL0);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.txtL1);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtL3);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtD7);
            this.groupBox2.Controls.Add(this.txtD6);
            this.groupBox2.Controls.Add(this.txtD5);
            this.groupBox2.Controls.Add(this.txtD4);
            this.groupBox2.Controls.Add(this.txtD3);
            this.groupBox2.Controls.Add(this.txtD2);
            this.groupBox2.Controls.Add(this.txtD1);
            this.groupBox2.Controls.Add(this.txtD0);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtBumper);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtRightEncoder);
            this.groupBox2.Controls.Add(this.txtLeftEncoder);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(1308, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1013, 319);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Приёмные данные";
            // 
            // txtL4
            // 
            this.txtL4.Location = new System.Drawing.Point(512, 261);
            this.txtL4.Name = "txtL4";
            this.txtL4.ReadOnly = true;
            this.txtL4.Size = new System.Drawing.Size(69, 38);
            this.txtL4.TabIndex = 45;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(451, 261);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 31);
            this.label28.TabIndex = 44;
            this.label28.Text = "L4:";
            // 
            // txtL2
            // 
            this.txtL2.Location = new System.Drawing.Point(512, 209);
            this.txtL2.Name = "txtL2";
            this.txtL2.ReadOnly = true;
            this.txtL2.Size = new System.Drawing.Size(69, 38);
            this.txtL2.TabIndex = 43;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(451, 209);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 31);
            this.label27.TabIndex = 42;
            this.label27.Text = "L2:";
            // 
            // txtL0
            // 
            this.txtL0.Location = new System.Drawing.Point(512, 155);
            this.txtL0.Name = "txtL0";
            this.txtL0.ReadOnly = true;
            this.txtL0.Size = new System.Drawing.Size(69, 38);
            this.txtL0.TabIndex = 41;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(451, 155);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 31);
            this.label26.TabIndex = 40;
            this.label26.Text = "L0:";
            // 
            // txtL1
            // 
            this.txtL1.Location = new System.Drawing.Point(512, 102);
            this.txtL1.Name = "txtL1";
            this.txtL1.ReadOnly = true;
            this.txtL1.Size = new System.Drawing.Size(69, 38);
            this.txtL1.TabIndex = 39;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(451, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 31);
            this.label25.TabIndex = 38;
            this.label25.Text = "L1:";
            // 
            // txtL3
            // 
            this.txtL3.Location = new System.Drawing.Point(512, 51);
            this.txtL3.Name = "txtL3";
            this.txtL3.ReadOnly = true;
            this.txtL3.Size = new System.Drawing.Size(69, 38);
            this.txtL3.TabIndex = 37;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(451, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 31);
            this.label24.TabIndex = 36;
            this.label24.Text = "L3:";
            // 
            // txtD7
            // 
            this.txtD7.Location = new System.Drawing.Point(865, 218);
            this.txtD7.Name = "txtD7";
            this.txtD7.ReadOnly = true;
            this.txtD7.Size = new System.Drawing.Size(132, 38);
            this.txtD7.TabIndex = 31;
            // 
            // txtD6
            // 
            this.txtD6.Location = new System.Drawing.Point(865, 162);
            this.txtD6.Name = "txtD6";
            this.txtD6.ReadOnly = true;
            this.txtD6.Size = new System.Drawing.Size(132, 38);
            this.txtD6.TabIndex = 30;
            // 
            // txtD5
            // 
            this.txtD5.Location = new System.Drawing.Point(865, 105);
            this.txtD5.Name = "txtD5";
            this.txtD5.ReadOnly = true;
            this.txtD5.Size = new System.Drawing.Size(132, 38);
            this.txtD5.TabIndex = 29;
            // 
            // txtD4
            // 
            this.txtD4.Location = new System.Drawing.Point(865, 57);
            this.txtD4.Name = "txtD4";
            this.txtD4.ReadOnly = true;
            this.txtD4.Size = new System.Drawing.Size(132, 38);
            this.txtD4.TabIndex = 28;
            // 
            // txtD3
            // 
            this.txtD3.Location = new System.Drawing.Point(662, 216);
            this.txtD3.Name = "txtD3";
            this.txtD3.ReadOnly = true;
            this.txtD3.Size = new System.Drawing.Size(132, 38);
            this.txtD3.TabIndex = 27;
            // 
            // txtD2
            // 
            this.txtD2.Location = new System.Drawing.Point(662, 159);
            this.txtD2.Name = "txtD2";
            this.txtD2.ReadOnly = true;
            this.txtD2.Size = new System.Drawing.Size(132, 38);
            this.txtD2.TabIndex = 26;
            // 
            // txtD1
            // 
            this.txtD1.Location = new System.Drawing.Point(662, 105);
            this.txtD1.Name = "txtD1";
            this.txtD1.ReadOnly = true;
            this.txtD1.Size = new System.Drawing.Size(132, 38);
            this.txtD1.TabIndex = 25;
            // 
            // txtD0
            // 
            this.txtD0.Location = new System.Drawing.Point(662, 56);
            this.txtD0.Name = "txtD0";
            this.txtD0.ReadOnly = true;
            this.txtD0.Size = new System.Drawing.Size(132, 38);
            this.txtD0.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(802, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 31);
            this.label19.TabIndex = 23;
            this.label19.Text = "D7:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(802, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 31);
            this.label18.TabIndex = 22;
            this.label18.Text = "D6:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(802, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 31);
            this.label17.TabIndex = 21;
            this.label17.Text = "D5:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(804, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 31);
            this.label16.TabIndex = 20;
            this.label16.Text = "D4:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(601, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 31);
            this.label15.TabIndex = 19;
            this.label15.Text = "D3:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(601, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 31);
            this.label14.TabIndex = 18;
            this.label14.Text = "D2:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(601, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 31);
            this.label13.TabIndex = 17;
            this.label13.Text = "D1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(601, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 31);
            this.label12.TabIndex = 16;
            this.label12.Text = "D0:";
            // 
            // txtBumper
            // 
            this.txtBumper.Location = new System.Drawing.Point(184, 208);
            this.txtBumper.Name = "txtBumper";
            this.txtBumper.ReadOnly = true;
            this.txtBumper.Size = new System.Drawing.Size(132, 38);
            this.txtBumper.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 31);
            this.label11.TabIndex = 14;
            this.label11.Text = "Бампер (b):";
            // 
            // txtRightEncoder
            // 
            this.txtRightEncoder.Location = new System.Drawing.Point(295, 156);
            this.txtRightEncoder.Name = "txtRightEncoder";
            this.txtRightEncoder.ReadOnly = true;
            this.txtRightEncoder.Size = new System.Drawing.Size(132, 38);
            this.txtRightEncoder.TabIndex = 13;
            // 
            // txtLeftEncoder
            // 
            this.txtLeftEncoder.Location = new System.Drawing.Point(286, 102);
            this.txtLeftEncoder.Name = "txtLeftEncoder";
            this.txtLeftEncoder.ReadOnly = true;
            this.txtLeftEncoder.Size = new System.Drawing.Size(141, 38);
            this.txtLeftEncoder.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(280, 31);
            this.label10.TabIndex = 11;
            this.label10.Text = "Правый энкодер (re):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 31);
            this.label9.TabIndex = 10;
            this.label9.Text = "Левый энкодер (le):";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(131, 49);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(132, 38);
            this.txtCode.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 31);
            this.label8.TabIndex = 4;
            this.label8.Text = "Код (c):";
            // 
            // pnlVPP
            // 
            this.pnlVPP.BackColor = System.Drawing.Color.White;
            this.pnlVPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVPP.Location = new System.Drawing.Point(1578, 855);
            this.pnlVPP.Name = "pnlVPP";
            this.pnlVPP.Size = new System.Drawing.Size(300, 300);
            this.pnlVPP.TabIndex = 11;
            this.pnlVPP.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlVPP_Paint);
            // 
            // btnToggleVPP
            // 
            this.btnToggleVPP.Location = new System.Drawing.Point(1578, 1161);
            this.btnToggleVPP.Name = "btnToggleVPP";
            this.btnToggleVPP.Size = new System.Drawing.Size(300, 60);
            this.btnToggleVPP.TabIndex = 12;
            this.btnToggleVPP.Text = "ВПП: Скрыто";
            this.btnToggleVPP.UseVisualStyleBackColor = true;
            this.btnToggleVPP.Click += new System.EventHandler(this.btnToggleVPP_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(343, 234);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(310, 44);
            this.btnExportCSV.TabIndex = 16;
            this.btnExportCSV.Text = "Экспорт в CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // sfdCSV
            // 
            this.sfdCSV.DefaultExt = "csv";
            this.sfdCSV.FileName = "route.csv";
            this.sfdCSV.Filter = "CSV файлы (*.csv)|*.csv";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.ClientSize = new System.Drawing.Size(2536, 1333);
            this.Controls.Add(this.btnToggleVPP);
            this.Controls.Add(this.pnlVPP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtRawData);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pnlMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Murashkin Ivan 241-324 Lab 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.SaveFileDialog sfdMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartY;
        private System.Windows.Forms.TextBox txtStartX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApplyStart;
        private System.Windows.Forms.Button btnApplyEnd;
        private System.Windows.Forms.TextBox txtEndY;
        private System.Windows.Forms.TextBox txtEndX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRawData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtL4;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtL2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtL0;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtL1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtL3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtD7;
        private System.Windows.Forms.TextBox txtD6;
        private System.Windows.Forms.TextBox txtD5;
        private System.Windows.Forms.TextBox txtD4;
        private System.Windows.Forms.TextBox txtD3;
        private System.Windows.Forms.TextBox txtD2;
        private System.Windows.Forms.TextBox txtD1;
        private System.Windows.Forms.TextBox txtD0;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBumper;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRightEncoder;
        private System.Windows.Forms.TextBox txtLeftEncoder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRobotDiamM;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCellSizeM;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel pnlVPP;
        private System.Windows.Forms.Button btnToggleVPP;
        private System.Windows.Forms.Button btnConfigSpace;
        private System.Windows.Forms.Button btnRunAStar;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.SaveFileDialog sfdCSV;
    }
}

