using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScannerClerk;
using System.Threading;

class ScanerClerk
{
    Thread t1;
    string ipaddress;
    string port;
    void ScannerClerk()
    {
        while (true)
        {
            new SendIdleMessage(ipaddress, port);
            //Console.WriteLine("IDLE");
            DataReceive dr = new DataReceive("10001");
            string ip = dr.getData();
            string path = dr.getData();
            //Console.WriteLine(ip);
            //Console.WriteLine(path);
            ScanThread st = new ScanThread(@"C:\Program Files\ClamWin\bin\");
            string temp = path;
            //Console.WriteLine("file Path" + temp);
            st.Working = true;
            st.SetWork(temp);
            while (st.Working == true) ;
            //Console.ReadLine();        
        }
    }
    public ScanerClerk(string ipaddress, string port)
    {
        this.ipaddress = ipaddress;
        this.port = port;
        t1 = new Thread(new ThreadStart(ScannerClerk));
        t1.Start();

    }
    public void StopScannerClert()
    {
        t1.Abort();
    }

}