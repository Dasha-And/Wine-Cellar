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

    public partial class Form_AddWine : Form
    {
        int year;
        decimal volume;
        string color;
        string type;
        decimal alcochol;
        int amount;
        decimal price;
        int rack;
        int shelf;
  public Wine NewWine { set; get; }
        public Form_AddWine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
                color = comboBox2.Text;
            if (comboBox2.SelectedIndex == 1)
                color = comboBox2.Text;
            if (comboBox2.SelectedIndex == 2)
                color = comboBox2.Text;

            if (comboBox3.SelectedIndex == 0)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 1)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 2)
                type = comboBox3.Text;
            if (comboBox3.SelectedIndex == 3)
                type = comboBox3.Text;


            Int32.TryParse(textBox6.Text, out year);
            Int32.TryParse(textBox2.Text, out amount);
            Decimal.TryParse(textBox5.Text, out alcochol);
            Decimal.TryParse(textBox4.Text, out price);
            Decimal.TryParse(textBox7.Text, out volume);
            Int32.TryParse(textBox8.Text, out rack);
            Int32.TryParse(textBox9.Text, out shelf);

            Wine w = new Wine()
            {
                Name = textBox1.Text,
                Country = textBox3.Text,
                Year = year,
                Volume = volume,
                Color = color,
                Type = type,
                Alcochol = alcochol,
                Amount = amount,
                Price = price,
                Rack = rack,
                Shelf = shelf
            };
            NewWine = w;
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

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewWine = null;
            this.Close();
        }
    }
 }
            

    

