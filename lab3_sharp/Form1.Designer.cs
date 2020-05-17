namespace lab3_sharp
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.labFolder = new System.Windows.Forms.Label();
            this.Фа = new System.Windows.Forms.Label();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDrawMode = new System.Windows.Forms.ComboBox();
            this.butNext = new System.Windows.Forms.Button();
            this.butPrev = new System.Windows.Forms.Button();
            this.butFolder = new System.Windows.Forms.Button();
            this.picMainPicture = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "РАБОЧАЯ ПАПКА:";
            // 
            // labFolder
            // 
            this.labFolder.AutoSize = true;
            this.labFolder.Location = new System.Drawing.Point(466, 111);
            this.labFolder.Name = "labFolder";
            this.labFolder.Size = new System.Drawing.Size(35, 13);
            this.labFolder.TabIndex = 3;
            this.labFolder.Text = "label2";
            // 
            // Фа
            // 
            this.Фа.AutoSize = true;
            this.Фа.Location = new System.Drawing.Point(466, 139);
            this.Фа.Name = "Фа";
            this.Фа.Size = new System.Drawing.Size(140, 13);
            this.Фа.TabIndex = 4;
            this.Фа.Text = "ФАЙЛЫ ИЗОБРАЖЕНИЙ";
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(469, 156);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(120, 95);
            this.listFiles.TabIndex = 5;
            this.listFiles.Click += new System.EventHandler(this.OnImageListClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "СТИЛЬ ПЕРЕБОРА ИЗОБРАЖЕНИЙ:";
            // 
            // cmbDrawMode
            // 
            this.cmbDrawMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrawMode.FormattingEnabled = true;
            this.cmbDrawMode.Items.AddRange(new object[] {
            "Простой вывод изображения",
            "Случайные вертикальные линии",
            "Увеличивающаяся звезда",
            "Рядами сверху вниз",
            "Случайные горизонтальные линии",
            "Случайные квадраты",
            "Случайные треугольники",
            "Столбцами слева направо",
            "Случайные круги",
            "Случайные горизонтальные линии",
            "Случайные круги/квадраты/треугольники",
            "Схлопывание",
            "Заполнение линиями",
            "Случаные прямоугольники",
            "Случайные вертикальные"});
            this.cmbDrawMode.Location = new System.Drawing.Point(472, 275);
            this.cmbDrawMode.Name = "cmbDrawMode";
            this.cmbDrawMode.Size = new System.Drawing.Size(121, 21);
            this.cmbDrawMode.TabIndex = 7;
            this.cmbDrawMode.SelectedIndexChanged += new System.EventHandler(this.OnDrawModeChanged);
            // 
            // butNext
            // 
            this.butNext.Image = global::lab3_sharp.Properties.Resources._1;
            this.butNext.Location = new System.Drawing.Point(554, 358);
            this.butNext.Margin = new System.Windows.Forms.Padding(0);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(75, 75);
            this.butNext.TabIndex = 9;
            this.butNext.UseVisualStyleBackColor = true;
            this.butNext.Click += new System.EventHandler(this.OnNextClick);
            // 
            // butPrev
            // 
            this.butPrev.Image = global::lab3_sharp.Properties.Resources._2;
            this.butPrev.Location = new System.Drawing.Point(472, 358);
            this.butPrev.Name = "butPrev";
            this.butPrev.Size = new System.Drawing.Size(75, 75);
            this.butPrev.TabIndex = 8;
            this.butPrev.UseVisualStyleBackColor = true;
            this.butPrev.Click += new System.EventHandler(this.OnPrevClick);
            // 
            // butFolder
            // 
            this.butFolder.Image = global::lab3_sharp.Properties.Resources.folder1;
            this.butFolder.Location = new System.Drawing.Point(466, 12);
            this.butFolder.Name = "butFolder";
            this.butFolder.Size = new System.Drawing.Size(75, 75);
            this.butFolder.TabIndex = 1;
            this.butFolder.UseVisualStyleBackColor = true;
            this.butFolder.Click += new System.EventHandler(this.onButFolderClick);
            // 
            // picMainPicture
            // 
            this.picMainPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picMainPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picMainPicture.Location = new System.Drawing.Point(-1, -1);
            this.picMainPicture.Margin = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.picMainPicture.Name = "picMainPicture";
            this.picMainPicture.Size = new System.Drawing.Size(450, 450);
            this.picMainPicture.TabIndex = 0;
            this.picMainPicture.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.OnTimer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Controls.Add(this.butNext);
            this.Controls.Add(this.butPrev);
            this.Controls.Add(this.cmbDrawMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.Фа);
            this.Controls.Add(this.labFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butFolder);
            this.Controls.Add(this.picMainPicture);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программа просмотра изображений";
            ((System.ComponentModel.ISupportInitialize)(this.picMainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMainPicture;
        private System.Windows.Forms.Button butFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labFolder;
        private System.Windows.Forms.Label Фа;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDrawMode;
        private System.Windows.Forms.Button butPrev;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Timer timer1;
    }
}

