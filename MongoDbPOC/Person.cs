using System;
using System.Collections.Generic;

namespace MongoDbPOC
{
    public class Person
    {
        public override string ToString()
        {
            var r = $"Person:{id}";
            foreach (var dog in dogs)
            {
                r += dog.ToString();
            }

            r += $"Name:{name}";
            return r;
        }

        public int id { get; set; }
        public IEnumerable<Dog> dogs { get; set; }
        public string name { get; set; }
    }
}