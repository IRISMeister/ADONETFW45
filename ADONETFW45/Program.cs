using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterSystems.Data.IRISClient;

namespace ADONETFW45
{
    class Program
    {
        static void Main(string[] args)
        {
            String host = "localhost";
            String port = "1972";
            String username = "_SYSTEM";
            String password = "SYS";
            String Namespace = "SAMPLES";

            IRISConnection IRISConnect = new IRISConnection();
            IRISConnect.ConnectionString = "Server = " + host
                + "; Port = " + port + "; Namespace = " + Namespace
                + "; Password = " + password + "; User ID = " + username +";"
                + " Min Pool Size = 2;"
                + " Max Pool Size = 5;"
                + " Connection Reset = true;"
                + " Connection Lifetime = 30;";

            IRISConnect.Open();

            String queryString = "SELECT * FROM Sample.Person";
            IRISCommand cmd4 = new IRISCommand(queryString, IRISConnect);

            //ExecuteReader() is used for SELECT
            IRISDataReader Reader = cmd4.ExecuteReader();

            Console.WriteLine("Printing out contents of SELECT query: ");
            while (Reader.Read())
            {

                Console.WriteLine(Reader.GetValue(0).ToString() + ", " + Reader.GetValue(1).ToString() + ", "+Reader.GetValue(2).ToString());

            }

            Reader.Close();
            cmd4.Dispose();

            Console.WriteLine(IRISPoolManager.ActiveConnectionCount);
            Console.WriteLine(IRISPoolManager.IdleCount());
            Console.WriteLine(IRISPoolManager.InUseCount());


            IRISConnect.Close();

            Console.WriteLine(IRISPoolManager.ActiveConnectionCount);
            Console.WriteLine(IRISPoolManager.IdleCount());
            Console.WriteLine(IRISPoolManager.InUseCount());

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
