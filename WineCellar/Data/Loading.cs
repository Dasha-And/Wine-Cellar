using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WineCellar.Data
{
    class Loading
    {
        // Загрузка данных из файла
        public List<Wine> Load(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Wine>)bf.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
        // Метод  сохранения данных в файл
        public void SaveAs(string path, List<Wine> wines)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, wines);
                }
            }
            catch (ArgumentException) { }
        }
    }
}
