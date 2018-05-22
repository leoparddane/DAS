using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class result
    {
        bool success;

        public bool Success
        {
            get
            {
                return success;
            }

            set
            {
                success = value;
            }
        }
        public result()
        {
            success = false;
        }
    }
}
