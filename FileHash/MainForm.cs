using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHash
{
    public partial class MainForm : Form
    {
        private readonly FileHash fileHash = new FileHash();

        public MainForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            fileHash.Hash("C:\\Users\\Master\\Downloads\\孤勇者 - 陈奕迅.flac");
        }
    }
}
