using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEnumerableExcersise
{
    class Salon : IEnumerable<Auto>
    {
       public List<Auto> lista { get; set; }
       public Salon()
        {
            lista = new List<Auto>();
        }
        public IEnumerator<Auto> GetEnumerator()
        {
            return lista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
