using System;
using System.Runtime.Serialization;

namespace WebApplication
{
    [KnownType(typeof(address))]
    [Serializable]
    public class address
    {
        public int id { get; set; }
        public string street { get; set; }
        public int number { get; set; }
    }
}