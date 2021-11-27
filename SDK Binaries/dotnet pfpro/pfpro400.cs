using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Reflection;
using System.Configuration;

// **************************************************************************
// This work product is provided "AS IS" and without warranty.
// **************************************************************************

// Please refer to the post titled "How to post transactions direct via HTTPS " on the 
// PayPal Developer's Forum for the Payflow Gateway.  
//
// Go to http://www.paypaldeveloper.com and "Jump to" Payflow Gateway.
//
// You will also need to reference the Payflow Pro Developer's Guide are that available
// from the Integration Center at
// https://cms.paypal.com/us/cgi-bin/?cmd=_render-content&content_ID=developer/howto_gateway_payflowpro.

namespace PFProHTTPS
{

    class Program
    {
        #region "Properties"

        /// <summary>
        /// Generates Request Id
        /// </summary>
        public static String RequestId
        {
            get
            {
                String RequestId;
                Guid GuidValue = Guid.NewGuid();
                RequestId = GuidValue.ToString("N");
                return RequestId;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            String uri = "";
            String parameters = "";
            int clienttimeout = 100000;
            String gatewaytimeout = "";
            String requestID = "";
            String logfile = "";
            String proxyaddress = "";
            String proxyuser = "";
            String proxypassword = "";
            String proxydomain = "";
            Boolean logging = false;
            Boolean debug = false;
            Boolean proxy = false;
            Boolean domain = false;
            String contenttype = "";
            TextWriter log = null;
            String pfproversion = "1.1";

            //Command line argument parser
            try
            {
                for (int x = 0; x < args.Length; x++)
                {
                    if (args[x].CompareTo("-proxyaddress") == 0) {
                        proxyaddress = args[x + 1];
                        proxy = true;
                    }
                    if (args[x].CompareTo("-proxyuser") == 0)
                        proxyuser = args[x + 1];
                    if (args[x].CompareTo("-proxypassword") == 0)
                        proxypassword = args[x + 1];
                    if (args[x].CompareTo("-proxydomain") == 0)
                    {
                        proxydomain = args[x + 1];
                        domain = true;
                    }
                    if (args[x].CompareTo("-help") == 0)
                        throw new ArgumentNullException();
                    if (args[x].CompareTo("-debug") == 0)
                        debug = true;
                    if (args[x].CompareTo("-host") == 0)
                        uri = args[x + 1];
                    if (args[x].CompareTo("-allowunsafeheader") == 0)                  
                        SetAllowUnsafeHeaderParsing20();
                    if (args[x].CompareTo("-request") == 0)
                        parameters = args[x + 1];
                    if (args[x].CompareTo("-clienttimeout") == 0)
                        clienttimeout = int.Parse(args[x + 1]) * 1000;
                    if (args[x].CompareTo("-gatewaytimeout") == 0)
                        gatewaytimeout = args[x + 1];
                    if (args[x].CompareTo("-requestid") == 0)
                        requestID = args[x + 1];
                    if (args[x].CompareTo("-logfile") == 0)
                    {
                        logfile = args[x + 1];
                        logging = true;
                    }
                    if (args[x].CompareTo("-contenttype") == 0)
                        contenttype = args[x + 1];
                }

                if (args.Length == 0)
                    throw new ArgumentNullException();

                //Log to append to
                if (logging)
                    log = new StreamWriter(logfile, true);
                
            }

            // Could not open log
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }

            //Display the command line help
            catch 
            {
                Console.WriteLine("pfpro400 version " + pfproversion + "\n");
                Console.WriteLine("Usage: pfpro400 [arguments]\n");

                Console.WriteLine("-host https://pilot-payflowpro.paypal.com\n");
                Console.WriteLine("    Specify one of two Payflow hosts:");
                Console.WriteLine("    test: https://pilot-payflowpro.paypal.com");
                Console.WriteLine("    live: https://payflowpro.paypal.com\n");

                Console.WriteLine("-request \"TRXTYPE=S&TENDER=C&STREET=123 Main St&ACCT=...&AMT=1.00\"\n");
                Console.WriteLine("    Specify a quoted NVP or XML transaction string.\n");

                Console.WriteLine("-contenttype text/namevalue\n");
                Console.WriteLine("    Optional. Specify a content-type of the request string.");
                Console.WriteLine("    Values include text/namevalue (default) or text/xml. \n");

                Console.WriteLine("-gatewaytimeout 45\n");
                Console.WriteLine("    Specify a gateway timeout value in seconds. A transaction times out");
                Console.WriteLine("    if the elapsed time between ending the transaction request and");
                Console.WriteLine("    receiving the transaction response exceeds the specified value.\n");

                Console.WriteLine("-clienttimeout 50\n");
                Console.WriteLine("    Optional. Specify a client timeout value in seconds. This value represents");
                Console.WriteLine("    how long this client will wait before issuing a timeout. Default is 100.\n");

                Console.WriteLine("-requestid \"12345678901234567890123456789012\"\n");
                Console.WriteLine("    Optional. The Request ID is a unique identifier for each request made");
                Console.WriteLine("    up of 1 to 32 printable characters used to check for duplicate transaction");
                Console.WriteLine("    attempts.  If you send a transaction with a previously used Request ID,");
                Console.WriteLine("    the server ignores the new data and returns the response to the original");
                Console.WriteLine("    transaction with DUPLICATE=1 appended. If you omit the Request ID, ");
                Console.WriteLine("    pfpro400.exe will generate one.\n");

                Console.WriteLine("-proxyaddress 192.168.1.100:3128\n");
                Console.WriteLine("    Optional. Specify your proxy server IP address if applicable. The port");
                Console.WriteLine("    value if applicable follows the IP address.\n");

                Console.WriteLine("-proxyuser \"user1\"\n");
                Console.WriteLine("    Optional. Specify your proxy server user name.\n");

                Console.WriteLine("-proxypassword \"abc123\"\n");
                Console.WriteLine("    Optional. Specify your proxy server password.\n");

                Console.WriteLine("-proxydomain \"abc123.com\"\n");
                Console.WriteLine("    Optional. Specify your proxy server domain\n");

                Console.WriteLine("-allowunsafeheader\n");
                Console.WriteLine("    Optional. Specify to indicate that unsafe headers are allowed. Use if you");
                Console.WriteLine("    are receiving \"The server committed a protocol violation\" errors.\n");

                Console.WriteLine("-logfile logger.txt\n");
                Console.WriteLine("    Optional. Specify the the file to append trasaction requests and");
                Console.WriteLine("    respopnses. Will create non existant files but not create paths.\n");

                Console.WriteLine("-debug\n");
                Console.WriteLine("    Optional. Specify to indicate that additional data should be written to the");
                Console.WriteLine("    log file including HTTP headers and Status.\n");

                Console.WriteLine("-help\n");
                Console.WriteLine("    Optional. Specify to display these instructions.");

                Environment.Exit(-1);
            }

            //Declare the amount of Retries for non HTTP 200 (OK) responses before giving up
            int retryCount = 3;
        Retry:

            try
            {
                //Generate timestamp for log 
                String timer = DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString();
                
                if (requestID.CompareTo("") == 0)
                    // if no "-requestid" was supplied, generate GUID.
                    requestID = Program.RequestId;            

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

                webRequest.Timeout = clienttimeout;
                if (contenttype == "text/xml") {
                    webRequest.ContentType = "text/xml";
                } else {
                    webRequest.ContentType = "text/namevalue";
                }
                webRequest.Method = "POST";
                // See posting on Developer's Forum for additional headers that can be sent with this request.
                webRequest.Headers.Add("X-VPS-Request-ID: " + requestID);
                webRequest.Headers.Add("X-VPS-Client-Timeout: " + gatewaytimeout);
                webRequest.Headers.Add("X-VPS-VIT-Integration-Product: pfpro400");
                webRequest.Headers.Add("X-VPS-VIT-Integration-Version: " + pfproversion);
                
                //Attach Proxy if applicable
                WebProxy wp = null;
                if (proxy)
                {
                    wp = new WebProxy(proxyaddress, true);
                    if (domain)
                        wp.Credentials = new NetworkCredential(proxyuser, proxypassword, proxydomain);
                    else
                        wp.Credentials = new NetworkCredential(proxyuser, proxypassword);
                    webRequest.Proxy = wp;
                }

                // Only log the Request once in the event retries are done
                if (logging && retryCount == 3)
                {
                    log.WriteLine("[" + timer + "][S]");

                    if (debug)
                    {
                        //Log the Request Headers
                        WebHeaderCollection whcreq = webRequest.Headers;
                        for (int i = 0; i < whcreq.Count; i++)
                        {
                            log.WriteLine(whcreq.GetKey(i) + ": " + whcreq[i]);
                        }
                    }
                    log.WriteLine(parameters);
                }

                byte[] bytes = ASCIIEncoding.ASCII.GetBytes(parameters);

                Stream os = null;

                //Send the Post
                try
                {
                    //Count bytes to send
                    webRequest.ContentLength = bytes.Length;
                    os = webRequest.GetRequestStream();

                    //Send it
                    os.Write(bytes, 0, bytes.Length);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);

                    if (logging)
                    {
                        log.WriteLine("[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString() + "][ERROR]");
                        log.WriteLine(ex.Message);
                        log.Close();
                        Environment.Exit(-1);
                    }
                }

                finally
                {
                    if (os != null)
                        os.Close();
                }

                //Get the response               
                try
                {

                    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                    if (webResponse != null)
                    {
                        StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                        String response = sr.ReadToEnd().Trim();

                        if (logging)
                        {
                            log.WriteLine("[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString() + "][R]");                           
                            if (debug) {
                                //Log HTTP Status
                                HttpStatusCode c = webResponse.StatusCode;
                                log.WriteLine("HTTP Status: " + (int)c + " " + c);

                                //Log Response Headers
                                WebHeaderCollection whc = webResponse.Headers;
                                for (int i = 0; i < whc.Count; i++)
                                {
                                    log.WriteLine(whc.GetKey(i) + ": " + whc[i]);
                                }
                            }

                            log.WriteLine(response);
                        }

                        Console.WriteLine(response);
                    }
                }
                //Will catch non 200 HTTP Status
                catch (WebException ex)
                {   
                    retryCount--;
                    if (retryCount > 0)
                    {
                        // Wait 3 seconds before a retry
                        System.Threading.Thread.Sleep(3000);
                        goto Retry;
                    }
                    //Give up
                    else
                    {
                        Console.WriteLine(ex.Message);
                        if (logging) {
                            log.WriteLine("[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString() + "][ERROR]");
                            log.WriteLine(ex.Message);
                            log.Close();
                        }
                        Environment.Exit(-1);
                    }
                }
                catch
                {
                    if (logging) {
                        log.WriteLine("[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString() + "][ERROR]");
                        log.WriteLine("Unexpected response error");
                        log.Close();
                    }
                    Console.WriteLine("Unexpected response error");
                    Environment.Exit(-1);
                }
            }
            catch (System.UriFormatException ex)
            {
                if (logging)
                {
                    log.WriteLine("[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.TimeOfDay.ToString() + "][ERROR]");
                    log.WriteLine(ex.Message);
                    log.Close();
                }
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }


            catch
            {
                Console.WriteLine("Unexpected general error");
                Environment.Exit(-1);
            }
            if (logging)
                log.Close();
        }

        //Set useUnsafeHeaderParsing to true
        public static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
