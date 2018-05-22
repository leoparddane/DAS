using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Common
{
    public class DB
    {
        public static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JingMei"].ToString();
        }
    }
}
