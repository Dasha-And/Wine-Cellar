using System.Collections.Generic;

namespace WineCellar.Data
{
    class WineMet
    {
        private Loading data = new Loading();

        public WineMet()
        {
            // Коллекция данных имеющейся базы
            Properties = new List<Wine>();
        }

        public WineMet(string path)
        {
            Properties = new List<Wine>();
            Read(path);
        }

        // Открытое свойство для получения доступа к листу 
        public List<Wine> Properties { get; set; }

        // Метод для чтения данных из файла в лист
        public void Read(string path)
        {
            var res = data.Load(path);
            if (res != null)
            {
                Properties = res;
            }
        }

        // Метод для записи данных из листа в файл  
        public void Write(string path)
        {
            data.SaveAs(path, Properties);
        }


    }
}

