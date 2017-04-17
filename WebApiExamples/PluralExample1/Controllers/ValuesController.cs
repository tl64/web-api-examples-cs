using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PluralExample1.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<string> data = new List<string>() {"value1", "value2"}; 
        public IEnumerable<string> Get()
        {
            return data;
        }

        public string Get(int id)
        {
            return data[id];
        }

        public void Post([FromBody] string value)
        {
            data.Add(value);
        }

        public void Put(int id, [FromBody] string value)
        {
            data[id] = value;
        }

        public void Delete(int id)
        {
            data.RemoveAt(id);
        }
    }
}