using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win.ViewModel
{
    public class loginModel
    {
        bool success;

        public bool Success { get => success; set => success = value; }
        public loginModel()
        {
            Success = false;
        }
    }
}
