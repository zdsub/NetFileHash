using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHash
{
    public partial class MainForm : Form
    {
        private readonly FileHash fileHash = new FileHash();
        private Thread hashThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StartHash(openFileDialog.FileNames);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            messageTextBox.Clear();

            clearButton.Enabled = false;
            copyButton.Enabled = false;
            saveButton.Enabled = false;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(messageTextBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, messageTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("导出失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            
            fileHash.IsStop = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hashTimer_Tick(object sender, EventArgs e)
        {
            currentProgressBar.Value = fileHash.Progress;
            currentProgressBar.PerformStep();

            totalProgressBar.Value = fileHash.Index;
            totalProgressBar.PerformStep();

            messageTextBox.Text = fileHash.Result;
            messageTextBox.SelectionStart = messageTextBox.Text.Length;
            messageTextBox.ScrollToCaret();

            if (messageTextBox.Text != "")
            {
                clearButton.Enabled = true;
                copyButton.Enabled = true;
                saveButton.Enabled = true;
            }

            if (!hashThread.IsAlive)
            {
                hashTimer.Enabled = false;

                openButton.Enabled = true;
                stopButton.Enabled = false;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (hashThread == null || !hashThread.IsAlive)
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null)
                {
                    int i = 0;

                    while (i < files.Length)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);

                        if (!fileInfo.Attributes.HasFlag(FileAttributes.Archive))
                            break;

                        i++;
                    }

                    if (i == files.Length)
                    {
                        e.Effect = DragDropEffects.All;
                        return;
                    }
                }
            }
            
            e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            StartHash(files);
        }

        /// <summary>
        /// 开始校验文件
        /// </summary>
        /// <param name="files">待校验文件路径数组</param>
        public void StartHash(string[] files)
        {
            openButton.Enabled = false;
            stopButton.Enabled = true;

            totalProgressBar.Value = 0;
            totalProgressBar.Maximum = files.Length;
            currentProgressBar.Value = 0;

            fileHash.FileList = files.ToList();

            hashThread = new Thread(fileHash.Hash);
            hashThread.Start();

            hashTimer.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hashThread != null && hashThread.IsAlive)
            {
                fileHash.IsStop = true;
                hashThread.Join();
            }
        }
    }
}
