using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// The Reporting Service is an XML based service that you can use to automate your report queries.
	/// It allows you to programmatically query in XML the Reporting database to generate a variety of
	/// reports for your business.
	///
	/// PayPal Manager is also a client of the Reporting Service. Everything that Manager can do with
	/// reports is available to you. You can, for example, request a particular report be run within a
	/// specified date range. The response returns all the data that the report generates.
	///
	/// The reporting service encapsulates the information in all the Payflow services reports. You can
	/// store this information in your local database and use it as needed.
	/// </summary>
	public class Reporting
	{
		public Reporting()
		{
		}

		public static async Task Main(string[] Args)
		{
			string requestURL = "https://payments-reports.paypal.com/reportingengine";
			XmlDocument xml = new XmlDocument();
			xml.Load("report.xml");

			using HttpClient client = new HttpClient();
			using StringContent content = new StringContent(xml.InnerXml, Encoding.UTF8, "text/plain");

			try
			{
				HttpResponseMessage response = await client.PostAsync(requestURL, content);
				string strResp = await response.Content.ReadAsStringAsync();

				Console.WriteLine("########## Response ####################");
				XmlDocument responseXML = new XmlDocument();
				responseXML.LoadXml(strResp);
				Console.WriteLine(responseXML.InnerXml);
				Console.In.Read();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: SubmitRequest");
				Console.WriteLine(ex.Message);

				if (null != ex.InnerException)
				{
					Console.WriteLine(ex.InnerException.Message);
				}

				Console.In.Read();
			}
		}
	}
}
