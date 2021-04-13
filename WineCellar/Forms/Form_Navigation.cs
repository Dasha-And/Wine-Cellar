using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineCellar.Data;

namespace WineCellar.Forms
{
    public partial class Form_Navigation : Form
    {
        WineMet methods = null;
        public Form_Navigation()
        {
            InitializeComponent();
            methods = new WineMet("wines.wines");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Wine> result = new List<Wine>();
            string name = textBox1.Text.ToLower();
            var byName = methods.Properties.Find(p => p.Name.ToLower().Contains(name));
            result.Add(byName);
            if (byName != null)
            {
                label2.Text = "Вино находится на стеллаже № " + byName.Rack + ", полка № " + byName.Shelf;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
