using System;

namespace Kavenegar
{
    using com.kavenegar.api;
    class Program
    {
        public const string Apikey = "your api code";
        private const string Sender = "your line number";
        private const string UserName = "your username";
        private const string Password = "your password";
        private const string receptor = "Phone number of receptor";
        private const string message = "your message";
        private const long postalcode = 12124;//your postal code



        private static v1SoapClient _client;

        static void Main()
        {
            _client = new v1SoapClient();

            SendSimpleByApikey();
            //RemainCreditByApiKey();
            //RemainCreditByLoginInfo();
            //SendSimpleByApikey();
            //ReceiveByApikey();
            //SendArrayByApikey();
            //SendPostalCodeByApikey();
            //GetStatusByApikey();
            //SelectByApikey();


            Console.WriteLine("Press Enter to close");
            Console.ReadKey();
        }

        public static void SendSimpleByApikey()
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
                    var smsstatus = GetStatusByApikey();
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

        public static void SendSimpleByLoginInfo()
        {
            try
            {
                var requestBody = new SendSimpleByLoginInfoRequestBody
                {
                    userName = UserName,
                    password=Password,
                    message = "خدمات پیام کوتاه کاوه نگار",
                    msgmode = 0,
                    receptor = new ArrayOfString { "receptor" },
                    sender = Sender,
                    status = 0,
                    statusmessage = "",
                    unixdate = 0
                };
                var result = _client.SendSimpleByLoginInfo(requestBody.userName,requestBody.password, requestBody.sender, requestBody.message, requestBody.receptor, requestBody.unixdate, requestBody.msgmode, ref requestBody.status, ref requestBody.statusmessage);
                if (requestBody.status != 200)
                {
                    Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
                }
                else if (result != null)
                {
                    var smsstatus = GetStatusByApikey();
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

        public static void SendArrayByApikey() { 
            try
            {
                var requestBody = new SendArrayByApikeyRequestBody
                {
                    apikey = Apikey,                    
                    message = new ArrayOfString { message },
                    sender=new ArrayOfString { Sender },
                    msgmode = new ArrayOfInt { 0},
                    receptor =new ArrayOfString { receptor},
                    status = 0,
                    statusmessage = "",
                    unixdate = 0
                };
                var result = _client.SendArrayByApikey(requestBody.apikey, requestBody.sender, requestBody.message, requestBody.receptor, requestBody.unixdate, requestBody.msgmode, ref requestBody.status, ref requestBody.statusmessage);
                if (requestBody.status != 200)
                {
                    Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
                }
                else if (result != null)
                {
                    var smsstatus = GetStatusByApikey();
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

        public static void SendArrayByLoginInfo()
        {
            try
            {
                var requestBody = new SendArrayByLoginInfoRequestBody
                {
                    userName = UserName,
                    password=Password,
                    message = new ArrayOfString { message },
                    sender = new ArrayOfString { Sender},
                    msgmode = new ArrayOfInt { 0 },
                    receptor = new ArrayOfString { receptor},
                    status = 0,
                    statusmessage = "",
                    unixdate = 0
                };
                var result = _client.SendArrayByLoginInfo(requestBody.userName,requestBody.password, requestBody.sender, requestBody.message, requestBody.receptor, requestBody.unixdate, requestBody.msgmode, ref requestBody.status, ref requestBody.statusmessage);
                if (requestBody.status != 200)
                {
                    Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
                }
                else if (result != null)
                {
                    var smsstatus = GetStatusByApikey();
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


        public static void SendPostalCodeByApikey()
        {
            try
            {
                var requestBody = new SendPostalCodeByApikeyRequestBody
                {
                    apikey=Apikey,
                    postalcode=postalcode,
                    count=2,
                    random=true,
                    startindex=5000,
                    message=message,
                    msgmode=0,
                    sender=Sender,
                    status = 0,
                    statusmessage = "",
                    unixdate = 0
                };
                var result = _client.SendPostalCodeByApikey(requestBody.apikey,requestBody.sender,requestBody.message,requestBody.unixdate,requestBody.msgmode,requestBody.postalcode,requestBody.startindex,requestBody.count,requestBody.random, ref requestBody.status, ref requestBody.statusmessage);
                if (requestBody.status != 200)
                {
                    Console.WriteLine("Returned [{0}] Message:[{1}]", requestBody.status, requestBody.statusmessage);
                }
                else if (result != null)
                {
                    var smsstatus = GetStatusByApikey();
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

       
        public static ArrayOfInt GetStatusByApikey()
        {
            try
            {
                var requestBody = new GetStatusByApikeyRequestBody
                {
                    apikey = Apikey,
                    messageid = new ArrayOfLong { 123123123},
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

        public static ArrayOfInt GetStatusByLoginInfo()
        {
            try
            {
                var requestBody = new GetStatusByLoginInfoRequestBody
                {
                    userName = UserName,
                    password=Password,
                    messageid = new ArrayOfLong { 123123123 },
                    status = 0,
                    statusmessage = ""
                };
                var result = _client.GetStatusByLoginInfo(requestBody.userName,requestBody.password, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);
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
                var result = _client.ReceiveByApikey(requestBody.apikey, requestBody.lineNumber, requestBody.isread, ref requestBody.status, ref requestBody.statusmessage);
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

        public static void ReceiveByLoginInfo()
        {
            try
            {
                var requestBody = new ReceiveByLoginInfoRequestBody()
                {
                    userName = UserName,
                    password = Password,
                    lineNumber = Sender,
                    isread = 0,
                    status=0,
                    statusmessage="" 
                };

                var result = _client.ReceiveByLoginInfo(requestBody.userName,requestBody.password,requestBody.lineNumber,requestBody.isread,ref requestBody.status,ref requestBody.statusmessage);
                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1} {2}", r.sender, r.message, r.date);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


        public static void RemainCreditByApiKey()
        {
            try
            {
                var requestBody = new RemainCreditByApiKeyRequestBody()
                {
                    apikey = Apikey,
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.RemainCreditByApiKey(requestBody.apikey, ref requestBody.status, ref requestBody.statusmessage);

                Console.WriteLine("{0}", result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemainCreditByLoginInfo()
        {
            try
            {
                var requestBody = new RemainCreditByLoginInfoRequestBody()
                {
                    userName = UserName,
                    password = Password,
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.RemainCreditByLoginInfo(requestBody.userName, requestBody.password, ref requestBody.status, ref requestBody.statusmessage);

                Console.WriteLine("{0}", result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SelectByApikey()
        {
            try
            {
                
                var requestBody = new SelectByApikeyRequestBody()
                {
                    apikey = Apikey,
                    messageid= new ArrayOfLong { 12312312},
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectByApikey(requestBody.apikey, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach(var r in result)
                    {
                        Console.WriteLine("{0} {1}",r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectByLoginInfo( )
        {
            try
            {
                var requestBody = new SelectByLoginInfoRequestBody()
                {
                    username = UserName,
                    password = Password,                    
                    messageid = new ArrayOfLong { 12312312},
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectByLoginInfo(requestBody.username,requestBody.password, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1}", r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectlatestByLoginInfo()
        {
            try
            {
                var requestBody = new SelectlatestByLoginInfoRequestBody()
                {
                    username = UserName,
                    password = Password,
                    pagesize = 4,                  
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectlatestByLoginInfo(requestBody.username, requestBody.password, requestBody.pagesize, ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1}", r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectlatestByApikey( )
        {
            try
            {
                var requestBody = new SelectlatestByApikeyRequestBody()
                {
                    apikey = Apikey,                    
                    pagesize = 4,
                    
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectlatestByApikey(requestBody.apikey, requestBody.pagesize, ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1}", r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void SelectoutboxByApikey()
        {
            try
            {
                var requestBody = new SelectoutboxByApikeyRequestBody()
                {
                    apikey = Apikey,
                    startUnixdate= 1412132123,
                    endUnixdate= 12312312312,
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectoutboxByApikey(requestBody.apikey, requestBody.startUnixdate, requestBody.endUnixdate , ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1}", r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SelectoutboxByLoginInfo()
        {
            try
            {
                var requestBody = new SelectoutboxByLoginInfoRequestBody()
                {
                    username = UserName,
                    password=Password,
                    startUnixdate = 12121212121,
                    endUnixdate = 12121312123,
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.SelectoutboxByLoginInfo(requestBody.username,requestBody.password, requestBody.startUnixdate, requestBody.endUnixdate, ref requestBody.status, ref requestBody.statusmessage);

                if (result != null)
                {
                    foreach (var r in result)
                    {
                        Console.WriteLine("{0} {1}", r.messageid, r.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CancelByApikey()
        {
            try
            {
                var requestBody = new CancelByApikeyRequestBody()
                {
                    apikey = Apikey,
                    messageid = new ArrayOfLong { 231231321},
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.CancelByApikey(requestBody.apikey, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);

                foreach (var r in result)
                {
                    Console.WriteLine("{0} ", r.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CancelByLoginInfo()
        {
            try
            {
                var requestBody = new CancelByLoginInfoRequestBody()
                {
                    userName = UserName,
                    password=Password,
                    messageid = new ArrayOfLong { 231231321 },
                    status = 0,
                    statusmessage = ""
                };

                var result = _client.CancelByLoginInfo(requestBody.userName,requestBody.password, requestBody.messageid, ref requestBody.status, ref requestBody.statusmessage);

                foreach (var r in result)
                {
                    Console.WriteLine("{0} ", r.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }







    }
}