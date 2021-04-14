using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hw_Serializ
{
    class MyXMLSerializer<T> : ISerializer<T> where T: class
    {

        public string Path { get; private set; }
        public T SerializibleObject { get; private set; }
        private XmlSerializer XmlSerializer { get; set; }


        public MyXMLSerializer(T serializibleObject, string path)
        {
            this.SerializibleObject = serializibleObject;
            this.Path = path;
            this.XmlSerializer = new XmlSerializer(serializibleObject.GetType());
        }

        public async Task<T> Deserialize()
        {
            T temp = null;

            try
            {

                using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                   var objDeserialized = await Task.Run(() => XmlSerializer.Deserialize(fileStream));

                    temp = objDeserialized as T;
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} : десериализация из XML невозможна!!");
            }

        }

        public async void Serialize()
        {
            try
            {
                using FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate);
                await Task.Run(() => this.XmlSerializer.Serialize(fileStream, SerializibleObject));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} : сериализация в XML невозможна!!");

            }
            
        }
    }
}
