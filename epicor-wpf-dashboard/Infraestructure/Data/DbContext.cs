
using System.Configuration;

namespace Infraestructure.Data
{
    public  class DbContext
    {

        private static readonly string _strConnecion =
         ConfigurationManager.ConnectionStrings["EpicorConnection"].ConnectionString;
  
        public static string ConnectionString()
        {
            return _strConnecion;
        }
    }
}
