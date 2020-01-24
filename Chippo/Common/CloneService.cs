using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Common
{
    class CloneService : ICloneService
    {
        public T Clone<T>(T val) where T: class
        {
            return (T)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(val), val.GetType())!;
        }
    }
}
