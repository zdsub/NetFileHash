﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            fileHash.FileList = new List<string>()
            {
                "C:\\Users\\Master\\Downloads\\孤勇者 - 陈奕迅.flac",
                "C:\\Users\\Master\\Downloads\\hash.exe"
            };

            hashThread = new Thread(fileHash.Hash);
            hashThread.Start();
        }
    }
}
