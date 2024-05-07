/* Ping computers every minute 
 * @jussivirkkala
 * 2024-05-06 Periodic timer
 * 2023-08-16 v1.0.0 First version. Using BesaEvt 1.0.3 as template. 
 * 2023-08-16 v1.0.1 Press any key to close scan
 * 2023-08-16 v1.0.2 Intervall as parameter. Corrected memory leak.
 * dotnet publish -r win-x64 -c Release --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true
 */

using System.Net.NetworkInformation;
using System.Diagnostics; // FileVersionInfo
using System.Reflection; // Assembly.

bool[] on;
bool init=true;
on = new bool[255];
Ping pingSender = new Ping();

Line("Ping computers every x seconds v" +
    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion +
    "\ngithub.com/jussivirkkala/ping");
if (args.Length < 2)
{
    Line(@"Provide refresh (s) and computer names separated with space as parameters e.g. ping 10 www.google.com www.facebook.com");
    Line("Press any key or close window...");
    Console.ReadKey();
    return;
}

Line("refresh(s):\t"+args[0]);
Int64 t=Convert.ToInt64(args[0]);

/*
if (t<(args.Length-1))
{
    Line("Minimum refresh is number of computers");
    Line("Press any key or close window...");
    Console.ReadKey();
    return;
}
*/

PingOptions options = new PingOptions
{
    // Set the Time-to-Live (TTL) value for the ping packet (default is 128)
    Ttl = 128,
    // Specify whether to allow fragmentation of the packet
    DontFragment = true
};


var timer = new PeriodicTimer (TimeSpan.FromSeconds (t));
RepeatForEver();

Line("Press any key to close scan...");
Console.ReadKey();
Line(DateTime.Now.ToString("o") + "\tAny key close");
timer.Dispose();

async void RepeatForEver()
{
   while (await timer.WaitForNextTickAsync())


    for (int i = 1; i < args.Length; i++)
    {
        string s;
        s = DateTime.Now.ToString("O")+"\t";
        string t = args[i];
        s += t + "\t";       

        bool b = Ping(pingSender,options,t);
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

static bool Ping(Ping pingSender, PingOptions options,string computer)
{
    // ChatGPT  
    try
        {
            // From 1000->500
            PingReply reply = pingSender.Send(computer, 500, new byte[32], options);
            if (reply.Status == IPStatus.Success)
            {
                return true; //  Console.WriteLine($"Ping to {hostNameOrAddress} succeeded. Roundtrip time: {reply.RoundtripTime} ms");
            }
            else
            {
                return false; // Console.WriteLine($"Ping to {hostNameOrAddress} failed. Status: {reply.Status}");
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