using System;

namespace Kavenegar
{
 using com.kavenegar.api;
 class Program
 {
	public const string Apikey = "Your APIKey";
	private const string Sender = "Your Sender Number";
	private static v1SoapClient _client;

	static void Main()
	{
	 _client = new v1SoapClient();
		//Send();
		ReceiveByApikey();
	 Console.WriteLine("Press Enter to close");
	 Console.ReadKey();
	}

	public static void Send()
	{
	 try
	 {
		var requestBody = new SendSimpleByApikeyRequestBody
		{
		 apikey = Apikey,
		 message = "خدمات پیام کوتاه کاوه نگار",
		 msgmode = 0,
		 receptor = new ArrayOfString { "receptor" },
		 sender = Sender,
		 status = 0,
		 statusmessage = "",
		 unixdate = 0
		};
		var result = _client.SendSimpleByApikey(requestBody.apikey, requestBody.sender, requestBody.message, requestBody.receptor, requestBody.unixdate, requestBody.msgmode, ref requestBody.status, ref requestBody.statusmessage);
		 if (requestBody.status != 200)
		 {
			 Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
		 }
		 else if (result != null)
		 {
			var smsstatus = Status(result);
			foreach (var st in smsstatus)
			{
			 switch (st)
			 {
				case 1:
				 Console.WriteLine("Queued to send");
				 break;
				case 2:
				 Console.WriteLine("Scheduled");
				 break;
				case 4:
				 Console.WriteLine("Sent to Operator");
				 break;
				case 10:
				 Console.WriteLine("Sent to Receptor (Delivered)");
				 break;
				case 11:
				 Console.WriteLine("Undelivered");
				 break;
				case 14:
				 Console.WriteLine("Receptor number has been blocked..");
				 break;
				case 100:
				 Console.WriteLine("Refrence ID not found");
				 break;
			 }
			}
		 }
		 
	 }
	 catch (Exception ex)
	 {
		Console.WriteLine(ex.Message);
	 }
	}

	public static ArrayOfInt Status(ArrayOfLong ids)
	{
	 try
	 {
		var requestBody = new GetStatusByApikeyRequestBody
		{
		 apikey = Apikey,
		 messageid = ids,
		 status = 0,
		 statusmessage = ""
		};
		var result = _client.GetStatusByApikey(requestBody.apikey, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);
		return result;
	 }
	 catch (Exception ex)
	 {
		Console.Write(ex.Message);
		return null;
	 }
	}

	public static void ReceiveByApikey()
	{
	 try
	 {
		var requestBody = new ReceiveByApikeyRequestBody()
		{
		  apikey = Apikey,
			lineNumber = Sender,
      isread = 1,
		  status = 0,
		  statusmessage = ""
		};
		var result = _client.ReceiveByApikey(requestBody.apikey, requestBody.lineNumber,requestBody.isread, ref requestBody.status, ref requestBody.statusmessage);
		 if (result != null)
		 {
			foreach (var r in result)
			{
			 Console.Write("{0} {1} {2}", r.sender, r.message, Environment.NewLine);
			}
		 }	
	 }
	 catch (Exception ex)
	 {
		Console.Write(ex.Message);
	 }
	}

 }
}