using MediaCatalog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaCatalog.UI.WinForms.Forms
{
    public partial class SelectTagForm : Form
    {
        public Tag? SelectedTag { get; private set; }

        public SelectTagForm(IEnumerable<Tag> tags)
        {
            InitializeComponent();
            listBox1.DataSource = tags.ToList();
            listBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedTag = listBox1.SelectedItem as Tag;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
