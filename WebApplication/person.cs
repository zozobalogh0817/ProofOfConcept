using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication
{
    [KnownType(typeof(person))]
    [Serializable]
    public class person
    {
        public int personid { get; set; }
        public List<address> addresses { get; set; }
        public string name { get; set; }
    }
}