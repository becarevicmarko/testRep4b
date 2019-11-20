using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList2.models
{
    enum Color {

        black, white, red, notSpecified
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Color Color { get; set; }

        public Car():this("","",Color.notSpecified){}

        public Car(string brand, string model, Color color)
        {
            this.Brand = brand;
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            return this.Brand + " " + this.Model + " " + this.Color;
        }

        public override bool Equals(object obj)
        {
         
            return base.Equals(obj as Car);
        }


        public bool Equals(Car obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Brand == this.Brand &&
                    obj.Model == this.Model &&
                    obj.Color == this.Color)
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            
            var hashCode = -1786895991;  
            hashCode = hashCode * -1521134295 +
                EqualityComparer<string>.Default.GetHashCode(Brand);
            hashCode = hashCode * -1521134295 +
                EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 +
                Color.GetHashCode();


            return hashCode;
        }


    }
}
