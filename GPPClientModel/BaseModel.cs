using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPPClientModel
{
    public class BaseModel
    {
        protected string CleanString(string s)
        {
            return (s ?? string.Empty).Trim();
        }
    }

    public class CustomModel
    {
        public Messages Messages { get; set; }
        public MessageSettings MessageSettings { get; set; }
        public List<MessageSettings> ListMessageSettings { get; set; }
    }
}
