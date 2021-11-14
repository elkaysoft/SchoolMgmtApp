using System.Configuration;

namespace ShillohHillsCollege.Core.DAC
{
    public class ConnectionManager
    {       
        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.AppSettings["ShilohGroupSettings"];
            return connectionString;
        }

    }
}
