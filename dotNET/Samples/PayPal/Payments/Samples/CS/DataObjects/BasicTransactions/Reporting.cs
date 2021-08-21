using System;
using System.Net;
using System.Xml;
using System.Text;
using System.Collections;
using System.IO;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// The Reporting Service is an XML based service that you can use to automate your report queries. 
	/// It allows you to programmatically query in XML the Reporting database to generate a varity of 
	/// reports for your business.
	/// 
	/// PayPal Manager is also a client of the Reporting Service. Everything that Manager can do with
	/// reports is available to you. You can, for example, request a particular report be run within a 
	/// specified date range. The response returns all the data that the report generates.
	/// 
	/// The reporting service encapsulates the information in all the Payflow services reports. You can
	/// store this information in your local database and use it as needed. 
	/// 
	/// To use this service you will be 
	/// </summary>
	public class Reporting
	{
		//public Reporting()
		//{
		//}

		//public static void Main(string[] Args)
		//{
		//	string requestURL = "https://payments-reports.paypal.com/reportingengine";
		//	HttpWebRequest request = HttpWebRequest.Create(requestURL) as HttpWebRequest;
		//	XmlDocument xml = new XmlDocument();
		//	xml.LoadXml("report.xml"); // returns xml as string as shown in earlier post
		//	byte[] reqBytes = UTF8Encoding.UTF8.GetBytes(xml.InnerXml);
		//	request.ContentLength = reqBytes.Length;
		//	request.Method = "POST";
		//	request.ContentType = "text/plain"; // changing this to text/xml returns "Bad content-type: text/xml"

		//	Stream requestStream = request.GetRequestStream();
		//	requestStream.Write(reqBytes, 0, reqBytes.Length);

		//	try 
		//	{
		//		HttpWebResponse response = request.GetResponse() as HttpWebResponse;

		//		Console.WriteLine("########## Response ####################");
   
		//		byte[] respBytes = readServiceResponse(response);
		//		String strResp = UTF8Encoding.UTF8.GetString(respBytes);
		//		XmlDocument responseXML = new System.Xml.XmlDocument();
		//		responseXML.LoadXml(strResp);
		//		Console.WriteLine(responseXML.InnerXml);
		//		Console.In.Read();
		//	} 
		//	catch (Exception ex) 
		//	{
		//		Console.WriteLine("Error: SubmitRequest");
		//		Console.WriteLine(ex.Message);

		//		if (null != ex.InnerException) 
		//		{
		//			Console.WriteLine(ex.InnerException.Message);
		//		}

		//		Console.In.Read();
		//	}

		//}
	}
}