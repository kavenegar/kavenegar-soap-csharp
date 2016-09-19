using System;

namespace Kavenegar
{
 using com.kavenegar.api;
 class Program
 {
	public const string Apikey = "your Apikey";
	private const string Sender = "10006707323323";
	private static v1SoapClient _client;

	static void Main()
	{
	 _client = new v1SoapClient();
	 var requestBody = new SendSimpleByApikeyRequestBody
	 {
		apikey = Apikey,
		message = "خدمات پیام کوتاه کاوه نگار",
		msgmode = 0,
		receptor = new ArrayOfString { " receptor" },
		sender = Sender,
		status = 0,
		statusmessage = "",
		unixdate = 0
	 };
	 var sendResult = Send(requestBody);
	 if (sendResult == null) return;
	 foreach (var smsRefrenceId in sendResult)
	 {
		Console.WriteLine("SmsRefrenceID:" + smsRefrenceId);
	 }
	 var ids = new ArrayOfLong();
	 ids.AddRange(sendResult);
	 var smsstatus = Status(ids);
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
	 Console.WriteLine("Press Enter to close");
	 Console.ReadKey();
	}

	public static ArrayOfLong Send(SendSimpleByApikeyRequestBody requestBody)
	{
	 try
	 {
		var result = _client.SendSimpleByApikey(requestBody.apikey, requestBody.sender, requestBody.message, requestBody.receptor, requestBody.unixdate, requestBody.msgmode, ref requestBody.status, ref requestBody.statusmessage);
		if (requestBody.status != 200)
		{
		 Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
		 return null;
		}
		else return result;
	 }
	 catch (Exception ex)
	 {
		Console.WriteLine(ex.Message);
		return null;
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
 }
}