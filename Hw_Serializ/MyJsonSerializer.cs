using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Hw_Serializ
{
    class MyJsonSerializer<T>   : ISerializer<T> where T:  class 
    {
        public string Path { get; private set; }
        public T SerializibleObject { get;private set; }       

        public MyJsonSerializer(T serializibleObject, string path)
        {
            this.SerializibleObject = serializibleObject;
            this.Path = path;
        }

        public async Task<T> Deserialize()
        {
            T temp = null;

            try
            {
                 
                using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    var objDeserialized = await JsonSerializer.DeserializeAsync(fileStream, SerializibleObject.GetType());

                    temp = objDeserialized as T;
                }

                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} : десериализация из в JSON файла невозможна!!");
            }
   
        }

        public async void Serialize()
        {
            try
            {
                using FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(fileStream, SerializibleObject, SerializibleObject.GetType());
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} : сериализация в JSON файл невозможна!!");

            }

        }

       
    }
}
