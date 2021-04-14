using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Hw_Serializ
{
    class Program
    {

        static async Task Main(string[] args)
        {   //не стал замарачиваться на всякие менюшки.. все захардкодил
            // ассинхронность, интерфейс - сугубо для практики сделал
            Truck truck = new Truck(new Owner { Name = "dima123" }, new Owner { Name = "Lesha44" });
            truck.Manufacturer = "BMW";
            truck.Model = "x8";
            truck.State = 60;
            truck.MaxSpeed = 150;

            ////// примерчик json сериализации
            MyJsonSerializer<Car> myCarJsonSerializer = new MyJsonSerializer<Car>(truck, "testj.json");
            myCarJsonSerializer.Serialize();
            Thread.Sleep(2000);
            var deserObjFromJson = await myCarJsonSerializer.Deserialize();
            ShowInfo(deserObjFromJson, "Json");

            Console.WriteLine(new string('=', 60));

            ////// примерчик xml сериализации
            MyXMLSerializer<Car> myCarXmlSerializer = new MyXMLSerializer<Car>(truck, "testXML777.xml");
            myCarXmlSerializer.Serialize();
            Thread.Sleep(2000);
            var deserObjFromXml = await myCarXmlSerializer.Deserialize();
            ShowInfo(deserObjFromXml,"Xml");

            Console.ReadKey();


        }

        private static void ShowInfo(Car deserObjFromXml, string type)
        {
            Console.WriteLine($"Из {type}\nПроизводитель: {deserObjFromXml.Manufacturer}\nМарка: {deserObjFromXml.Model}\nМакс. скор.: {deserObjFromXml.MaxSpeed}\nСостояние: {deserObjFromXml.State}\nВладельцы:\n");
            foreach (var owner in deserObjFromXml.Owners)
            {
                Console.WriteLine($"  {owner.Name}");
            }
        }
    }
}
