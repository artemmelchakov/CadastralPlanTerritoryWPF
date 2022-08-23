using CadastralPlanTerritoryWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CadastralPlanTerritoryWPF
{
    public static class Data
    {
        /// <summary>
        /// Объектная модель главного xml-документа
        /// </summary>
        private static extract_cadastral_plan_territory catalog;
        public static extract_cadastral_plan_territory Catalog
        {
            get
            {
                if (catalog == null) Load();
                return catalog;
            }
        }

        /// <summary>
        /// Получаем информацию от главного xml файла и десериализуем его 
        /// в объект типа extract_cadastral_plan_territory
        /// </summary>
        /// <returns></returns>
        public static extract_cadastral_plan_territory Load(string filepath = null)
        {
            XmlSerializer xmlSerializer;
            using
            (
                FileStream fs =
                    new FileStream
                    (
                        filepath ?? Environment.CurrentDirectory + "\\xml\\24_21_1003001_2017-05-29_kpt11.xml",
                        FileMode.OpenOrCreate
                    )
            )
            {
                xmlSerializer = new XmlSerializer(typeof(extract_cadastral_plan_territory));
                catalog = xmlSerializer.Deserialize(fs) as extract_cadastral_plan_territory;
                fs.Close();
            }
            return catalog;
        }

        /// <summary>
        /// Сохранение в xml-файл
        /// </summary>
        /// <param name="obj">Сохраняемый объект</param>
        /// <param name="filename">Имя файла и путь к нему</param>
        public static void Save(object obj, string filename)
        {
            XmlSerializer xmlSerializer;
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer = new XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(fs, obj);
                fs.Close();
            }
        }
    }
}
