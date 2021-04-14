using System;
using System.Collections.Generic;
using System.Text;

namespace Hw_Serializ
{
    //[Serializable]
    abstract public class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxSpeed { get;  set; }
        public List<Owner> Owners { get; set; }
        public int State { get; set; }
    }

    public class Owner
    {
        public string Name { get; set; }
    }
    //[Serializable]
    public class Truck : Car
    {
        public Truck()
        {

        }

        public Truck(params Owner[] owners)
        {
            base.Owners = new List<Owner>();

            base.Owners.AddRange(owners);
        }
    }



}
