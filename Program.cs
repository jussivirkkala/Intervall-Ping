/* Ping computers every minute 
 * @jussivirkkala
 * 2023-08-16 v1.0.0 First version. Using BesaEvt 1.0.3 as template. 
 * 2023-08-16 v1.0.1 Press any key to close scan
 
 * dotnet publish -r win-x64 -c Release --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true
 */

using System.Net.NetworkInformation;
using System.Diagnostics; // FileVersionInfo
using System.Reflection; // Assembly.


bool[] on;
bool init=true;
on = new bool[255];


Line("Ping computers every minute v" +
    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion +
    "\ngithub.com/jussivirkkala/Ping");
if (args.Length < 1)
{
    Line(@"Provide computer names separated with space as parameters e.g. ping www.google.com www.facebook.com");
    Line("Press any key or close window...");
    Console.ReadKey();
    return;
}


TimerCallback(init);
Timer timer = new Timer(TimerCallback,null,0,60000);
Line("Press any key to close scan...");
Console.ReadKey();
Line(DateTime.Now.ToString("o") + "\tAny key close");



void TimerCallback(object state)
{
    for (int i = 0; i < args.Length; i++)
    {
        string s;
        s = DateTime.Now.ToString("O")+"\t";
        string t = args[i];
        s += t + "\t";
        bool b = Ping(t);
        if (init) on[i] = !b;
        if (b != on[i])
        {
            if (b)
                s += "on";
            else
                s += "off";
            on[i] = b;
            Line(s);
        }
    }
    init = false;
}


static bool Ping(string computer)
{
    // ChatGPT
    string hostNameOrAddress = computer; // Replace with the host you want to ping
    Ping pingSender = new Ping();
    PingOptions options = new PingOptions
    {
        // Set the Time-to-Live (TTL) value for the ping packet (default is 128)
        Ttl = 128,
        // Specify whether to allow fragmentation of the packet
        DontFragment = true
    };

    try
    {
        PingReply reply = pingSender.Send(hostNameOrAddress, 1000, new byte[32], options);

        if (reply.Status == IPStatus.Success)
        {
            return true; //  Console.WriteLine($"Ping to {hostNameOrAddress} succeeded. Roundtrip time: {reply.RoundtripTime} ms");
        }
        else
        {
            return false; ;  Console.WriteLine($"Ping to {hostNameOrAddress} failed. Status: {reply.Status}");
        }
    }
    catch (PingException ex)
    {
        return false; // Console.WriteLine($"An error occurred: {ex.Message}");
    }
}


// Display line
static string Line(string s)
{
    Console.WriteLine(s);
    return s + "\n";
}

// End
