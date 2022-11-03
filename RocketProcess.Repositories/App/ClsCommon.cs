using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.App
{
    public class ClsCommon
    {
        public static string Server = "rocketprocess.ddns.net";
        public static string Database = "rocketprocess";
        public static string User = "rocketprocess";
        public static string Password = "rocketprocess";
        public static string ConnectionString = $"DATA SOURCE = {Server}; PASSWORD= {Password}; USER ID= {User};";
    }
}
