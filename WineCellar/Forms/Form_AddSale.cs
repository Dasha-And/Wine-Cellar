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
    public partial class Form_AddSale : Form
    {

        // Свойство, которое возращает наш объект
        public Wine w { get; set; }

        // Временная переменная для хранения данных
        private Wine temp;

        public Form_AddSale(Wine w)
        {
            temp = w;
            InitializeComponent();
            textBox2.Text = w.Amount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp = null;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            foreach (Control item in Controls)
            {
                if (item is TextBox || item is MaskedTextBox)
                {
                    if (item.Text == "")
                    {
                        MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            int amount = Convert.ToInt32(textBox2.Text);
            if (amount > temp.Amount)
            {
                MessageBox.Show("У нас нет столько вина!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                temp.Amount -= amount;
            }
            

            w = temp;


            this.Close();
        }
    }
    }

