﻿using ArenaModdingTool.ModdingFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaModdingTool.Controls
{
    public partial class ucItemsList : UserControl
    {
        private MBItems items;
        public event Action<MBItem, int> SelectedItemChanged;

        public ucItemsList(MBItems items)
        {
            InitializeComponent();
            this.items = items;
            loadItems();
        }

        private void loadItems()
        {
            treeView1.Nodes.Clear();
            foreach (var item in items.Items)
            {
                var node = treeView1.Nodes.Add(item.name);
                node.Tag = item;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                MBItem item = e.Node.Tag as MBItem;
                SelectedItemChanged?.Invoke(item, treeView1.Nodes.IndexOf(e.Node));
            }
        }
    }
}
