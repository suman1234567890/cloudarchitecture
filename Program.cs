using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace ScannerClerk
{
    class Program
    {
        
        static void Main(string[] args)
        {
            String ScannerManagerIpAddress = "172.16.52.125";
            String ScannerManagerPort = "11000";
            new ScanerClerk(ScannerManagerIpAddress, ScannerManagerPort);
          
        }
       
    }
}
