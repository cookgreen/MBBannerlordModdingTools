﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaModdingTool
{
    public partial class frmImportProject : Form
    {
        private AMProject project;
        public AMProject Project { get { return project; } }
        public frmImportProject()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtModuleLocation.Text = dialog.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                var files = di.EnumerateFiles();
                if (files.Where(o => o.Name == "SubModule.xml").Count() == 0)
                {
                    MessageBox.Show("Invalid Path!");
                    txtModuleLocation.Text = null;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtModuleLocation.Text))
            {
                MessageBox.Show("Please select a valid path");
            }
            project = new AMProject(txtModuleLocation.Text);
            DialogResult = DialogResult.OK;
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
