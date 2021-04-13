using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WineCellar.Forms
{
    public partial class Form_Edit : Form
    {
        // Свойство, которое возращает наш объект
        public Wine w { get; set; }

        // Временная переменная для хранения данных
        private Wine temp;
        public Form_Edit(Wine w)
        {
            temp = w;
            InitializeComponent();
            textBox1.Text = w.Name;
            textBox3.Text = w.Country;
            textBox6.Text = w.Year.ToString();
            textBox2.Text = w.Amount.ToString();
            textBox5.Text = w.Alcochol.ToString();
            textBox4.Text = w.Price.ToString();
            textBox7.Text = w.Volume.ToString();
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(w.Color);
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(w.Type);
            textBox8.Text = w.Rack.ToString();
            textBox9.Text = w.Shelf.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            temp = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка, что бы избежать пустых полей
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


            string type = "";
            string color = "";

            int year = Convert.ToInt32(textBox6.Text);
            decimal price = Convert.ToDecimal(textBox4.Text);
            int amount = Convert.ToInt32(textBox2.Text);
            decimal alcochol = Convert.ToDecimal(textBox5.Text);
            decimal volume = Convert.ToDecimal(textBox7.Text);
            int rack = Convert.ToInt32(textBox8.Text);
            int shelf = Convert.ToInt32(textBox9.Text);


            if (comboBox3.SelectedIndex == 0)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 1)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 2)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 3)
                type = comboBox3.Text;

            if (comboBox2.SelectedIndex == 0)
                color = comboBox2.Text;
            if (comboBox2.SelectedIndex == 1)
                color = comboBox2.Text;
            if (comboBox2.SelectedIndex == 2)
                color = comboBox2.Text;



            temp.Name = textBox1.Text;
            temp.Country = textBox3.Text;
            temp.Year = year;
            temp.Volume = volume;
            temp.Alcochol = alcochol;
            temp.Amount = amount;
            temp.Price = price;
            temp.Color = color;
            temp.Type = type;
            temp.Rack = rack;
            temp.Shelf = shelf;

            w = temp;



            this.Close();
        }
    }
}
