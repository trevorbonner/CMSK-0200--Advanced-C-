using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class GenericTestList<T>
    {
        public List<T> Container { get; set; }

        public GenericTestList()
        {
            Container = new List<T>();
        }

        public void Add(T newItem)
        {
            Container.Add(newItem);
        }

        public void Update(T newValue, T oldValue)
        {
            for(int i = 0; i < Container.Count; i++)
            {
                if (Container[i] != null && Container[i].Equals(oldValue))
                {
                    Container[i] = newValue;
                }
            }
        }

        public void Remove(T removeItem)
        {
            if (Container.Contains(removeItem))
            {
                Container.Remove(removeItem);
            }
        }

        public T CreateNew()
        {
            var newT = default(T);
            Container.Add(newT);
            return newT;
        }
    }
}
