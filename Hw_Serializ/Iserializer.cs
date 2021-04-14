using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hw_Serializ
{
    /// <summary>
    /// в данной программе излишен .. для практики 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ISerializer<T>
    {
        void Serialize();
        Task<T> Deserialize();

    }
}
