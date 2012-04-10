using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
public class ScanThread
{
    private string virtualPath = "";
    string database=@"""C:\Program Files\clamWin\DB\main.cvd""";
    char s = '"';
    public bool Working = false;
    private string FileScan;
    public ScanThread(String path) {
        virtualPath = path;

    }
    /*
     * called for add a thread of scan
     * @path file to scan
     */
    public void SetWork(string path)
    {
        FileScan = path;
        Thread t = new Thread(ScanFile);
        t.Start();
    }
    /*
     * the true ClamAV link
     * this will load clamdscan and wait for the result
     */
    private void ScanFile()
    {
        string output = null;
        try
        {
            Working = true;
            Process ClamScan = new Process();
            ClamScan.StartInfo.FileName = virtualPath + "clamscan.exe";
            //ClamScan.StartInfo.Arguments = "--no-summary --move=" + (char)(34) + virtualPath + "quarantene" + (char)(34) + " " + (char)(34) + FileScan + (char)(34);
            ClamScan.StartInfo.Arguments = " -r " + FileScan + " -d " +database;
            ClamScan.StartInfo.CreateNoWindow = true;
            ClamScan.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ClamScan.StartInfo.RedirectStandardOutput = true;
            ClamScan.StartInfo.UseShellExecute = false;
            ClamScan.EnableRaisingEvents = true;
            ClamScan.Start();
            ClamScan.WaitForExit();
            output = ClamScan.StandardOutput.ReadLine();
            //output = ClamScan.StandardOutput.ReadToEnd();
            //Console.WriteLine(" -r "+FileScan+" -d "+database+"hi"+output.ToString());
            Console.WriteLine("output:"+output);
            new insertIntoDatabase("output:" + output);
            while (!ClamScan.HasExited)
            {
                Console.WriteLine("Waiting for thread close");
            }
            ClamScan.Close();
            ClamScan.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
        Working = false;
        if (output != null && output.Length > 0 && !output.EndsWith(": OK") && !output.EndsWith("ERROR") && output.Contains("FOUND"))
        {
            Console.WriteLine(output.EndsWith(":OK").ToString());
            //ThreadHub.VirusFound(output);
        }

        //ThreadHub.EndScanThread(FileScan);
    }
}