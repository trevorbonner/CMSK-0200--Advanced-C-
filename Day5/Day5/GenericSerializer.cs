using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class GenericSerializer<T>
    {
        public List<T> Collection { get; set; }

        public GenericSerializer()
        {
            Collection = new List<T>();
        }

        public string Add(T objectToAdd)
        {
            return "Add";
        }

        public T ReturnObject(T objectToReturn)
        {
            return objectToReturn;
        }

        public string Serialize(T objectToSerialize)
        {
            if(objectToSerialize == null)
                return string.Empty;

            Type tType = typeof(T);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tType.Name);
            foreach(var property in tType.GetProperties())
            {
                sb.AppendLine(property.Name);
            }

            return sb.ToString();
        }
    }
}
