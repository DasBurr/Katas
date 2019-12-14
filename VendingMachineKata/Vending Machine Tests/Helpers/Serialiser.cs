using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vending_Machine_Tests.Helpers
{
    public static class Serialiser
    {
        public static string SerializeObjectJson<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
    }
}
