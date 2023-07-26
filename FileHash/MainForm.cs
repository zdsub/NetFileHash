using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
                string[] files = openFileDialog.FileNames;
                fileHash.FileList = files.ToList();

                totalProgressBar.Value = 0;
                totalProgressBar.Maximum = fileHash.FileList.Count;
                currentProgressBar.Value = 0;

                hashThread = new Thread(fileHash.Hash);
                hashThread.Start();

                hashTimer.Enabled = true;
            }
        }

        private void hashTimer_Tick(object sender, EventArgs e)
        {
            currentProgressBar.Value = fileHash.Progress;
            totalProgressBar.Value = fileHash.Index;
            messageTextBox.Text = fileHash.Result;
            messageTextBox.SelectionStart = messageTextBox.Text.Length;
            messageTextBox.ScrollToCaret();

            Debug.WriteLine($"progress: {fileHash.Progress}");
            Debug.WriteLine($"index: {fileHash.Index}");
            Debug.WriteLine($"result: {fileHash.Result}");

            if (!hashThread.IsAlive)
            {
                hashTimer.Enabled = false;
            }
        }
    }
}
