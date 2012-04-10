using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SendIdleMessage
{
    private string ipaddress;
    private string port;

    public SendIdleMessage(string ipaddress, string port)
    {
        // TODO: Complete member initialization
        this.ipaddress = ipaddress;
        this.port = port;
        Send();
    }
    void Send()
    {
        DataSend ds = new DataSend(ipaddress, port);
        ds.sendData("Free");

    }
}
