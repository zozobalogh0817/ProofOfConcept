using System.Collections.Generic;

namespace MongoDbPOC
{
    public class Dog
    {
        public override string ToString()
        {
            return $"Dog:{dogid} {name}";
        }

        public int dogid { get; set; }
        public Person person { get; set; }
        public string  name { get; set; }
    }
}