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
using System.IO;

namespace WineCellar.Forms
{
    [Serializable]
    public partial class Form_Wine : Form
    {
        Loading loading = new Loading();
        WineMet methods = null;


        public Form_Wine()
        {
            InitializeComponent();
            methods = new WineMet("wines.wines");

            dataGridView1.DataSource = methods.Properties;
            Set();

        }

        //Добавление нового вина
        private void button1_Click(object sender, EventArgs e)
        {
            Form_AddWine add = new Form_AddWine();
            add.ShowDialog();
            var element = add.NewWine;
            if (element != null)
            {
                // Добавления объекта в коллекцию
                methods.Properties.Add(element);
                Set();
                // Запись нового вина в файл, где содержиться база
                methods.Write("wines.wines");
            }

        }
        public void Set()
        {
            try
            {
                var result = (from i in methods.Properties
                              select new
                              {
                                  // Параметры, которые видно непосредственно на datagridview
                                  Название = i.Name,
                                  Год = i.Year,
                                  Страна = i.Country,
                                  Объем = i.Volume,
                                  Цвет = i.Color,
                                  Вид = i.Type,
                                  Cпирт = i.Alcochol,
                                  Количество = i.Amount,
                                  Цена = i.Price
                              }).ToList();
                dataGridView1.DataSource = result;
            }
            catch (NullReferenceException) { }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Списание вина
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index3 = dataGridView1.SelectedRows[0].Index;
                // Открытие формы, где происходит процесс изменения количества вина
                Form_AddSale add = new Form_AddSale(methods.Properties[index3]);
                add.ShowDialog();
                if (add.w != null)
                {
                    methods.Properties[index3] = add.w;
                    Set();
                    // Запись изменений в файл, с базой
                    methods.Write("wines.wines");
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }
        //Закупка вина
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int index3 = dataGridView1.SelectedRows[0].Index;
                // Открытие формы, где происходит процесс изменения количества вина
                Form_AddSupply add = new Form_AddSupply(methods.Properties[index3]);
                add.ShowDialog();
                if (add.w != null)
                {
                    methods.Properties[index3] = add.w;
                    Set();
                    // Запись изменений в файл с базой
                    methods.Write("wines.wines");
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }
        //Удаление вина
        private void button7_Click(object sender, EventArgs e)
        {

            if (methods.Properties.Count <= 0)
                return;
            // Подтверждение удаления 
            var yesno = MessageBox.Show("Вы действительно хотите удалить выбраное вино ?",
                           "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesno == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int index2 = dataGridView1.SelectedRows[0].Index;
                    methods.Properties.RemoveAt(index2);
                    dataGridView1.DataSource = null;
                    // Возвращает базу, уже без удаленного элемента
                    dataGridView1.DataSource = methods.Properties;
                    Set();
                    // Запись изменений в файл с базой
                    methods.Write("wines.wines");
                }
                catch (ArgumentOutOfRangeException) { }

            }
        }
        //Редактирование информации о вине
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int index3 = dataGridView1.SelectedRows[0].Index;
                // Открытие формы, где происходит процесс изменения данных об объекте
                Form_Edit myform = new Form_Edit(methods.Properties[index3]);
                myform.ShowDialog();
                if (myform.w != null)
                {
                    methods.Properties[index3] = myform.w;
                    Set();
                    // Запись изменений в файл, с базой
                    methods.Write("wines.wines");
                }
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Navigation form = new Form_Navigation();
            form.ShowDialog();
        }
    }
}

