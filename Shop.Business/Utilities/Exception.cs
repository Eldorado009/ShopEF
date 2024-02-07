using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Utilities
{
    public class Exception
    {
        private string message;

        public Exception(string message)
        {
            this.message = message;
        }
    }
}
