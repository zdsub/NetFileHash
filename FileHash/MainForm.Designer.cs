namespace FileHash
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.currentLabel = new System.Windows.Forms.Label();
            this.currentProgressBar = new System.Windows.Forms.ProgressBar();
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.hashTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTextBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.messageTextBox.Location = new System.Drawing.Point(12, 12);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(630, 215);
            this.messageTextBox.TabIndex = 0;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 233);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(100, 30);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "打开(&O)...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Location = new System.Drawing.Point(118, 233);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 30);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清除(&L)";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Enabled = false;
            this.copyButton.Location = new System.Drawing.Point(224, 233);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(100, 30);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "复制(&C)";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(330, 233);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "保存(&S)...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(436, 233);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 30);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "停止(&T)";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(542, 233);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 30);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "退出(&X)";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(12, 302);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(52, 15);
            this.totalLabel.TabIndex = 7;
            this.totalLabel.Text = "总计：";
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(12, 273);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(52, 15);
            this.currentLabel.TabIndex = 8;
            this.currentLabel.Text = "当前：";
            // 
            // currentProgressBar
            // 
            this.currentProgressBar.Location = new System.Drawing.Point(70, 269);
            this.currentProgressBar.Name = "currentProgressBar";
            this.currentProgressBar.Size = new System.Drawing.Size(572, 23);
            this.currentProgressBar.TabIndex = 9;
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Location = new System.Drawing.Point(70, 298);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(572, 23);
            this.totalProgressBar.TabIndex = 10;
            // 
            // hashTimer
            // 
            this.hashTimer.Interval = 15;
            this.hashTimer.Tick += new System.EventHandler(this.hashTimer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "所有文件 (*.*)|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "hash.txt";
            this.saveFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 333);
            this.Controls.Add(this.totalProgressBar);
            this.Controls.Add(this.currentProgressBar);
            this.Controls.Add(this.currentLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.messageTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "文件校验";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.ProgressBar currentProgressBar;
        private System.Windows.Forms.ProgressBar totalProgressBar;
        private System.Windows.Forms.Timer hashTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

