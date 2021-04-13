using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WineCellar.Forms;

namespace WineCellar
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form_Wine winecollection = new Form_Wine();
            _ = winecollection.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" \nПосле запуска программы вы можете перейти к списку вин. В него вы можете добавлять новые вина, затем удалять их и редактировать, выбрав необходимое наименование и нажав кнопку Удалить/Редактировать. Так же выбрав вино и нажав кнопки Списать/Закупить вы можете изменить количество бутылок. Если вы забыли местонахождение вина в погребе, то можете нажать кнопку Навигация. Введите название вина и нажмите Поиск, программа сообщит номер сталлежа и полки.", " Справка", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author a = new Author();
            a.ShowDialog();
        }
    }

}
