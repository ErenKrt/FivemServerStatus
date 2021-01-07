using EpEren.Fivem.ServerStatus.Classes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace EpEren.Fivem.ServerStatus
{
    public static class BaseAPI
    {
        private static RestClient _Client = new RestClient("https://servers-live.fivem.net/api/servers/single/");

        public static BaseServer Get(string Code)
        {
            var Req = new RestRequest(Code);
            var Res = _Client.Get(Req);

            if (Res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Get = JsonConvert.DeserializeObject<BaseServer>(Res.Content);

                if(Get!=null && Get.EndPoint!=null && Get.Data != null)
                {
                    Get.Data.BVars = new List<ValueObject>();

                    if (Get.Data.Vars != null)
                    {
                        foreach (KeyValuePair<string, object> item in Get.Data.Vars)
                        {
                            Get.Data.BVars.Add(new ValueObject()
                            {
                                Name = item.Key.ToString(),
                                Value = item.Value.ToString()
                            });

                        }
                    }
                    

                    if(Get.Data.Players!=null && Get.Data.Players.Count > 0)
                    {
                        foreach (var Player in Get.Data.Players)
                        {
                            var Idens = Player.Identifiers;
                            Player.BIdentifiers = new List<ValueObject>();
                            foreach (var Iden in Idens)
                            {
                                var Exp = Iden.Split(':');
                                Player.BIdentifiers.Add(new ValueObject()
                                {
                                    Name= Exp[0],
                                    Value= Exp[1]
                                });
                            }
                        }
                    }

                    Get.Data.IconUrl = "https://servers-live.fivem.net/servers/icon/"+Code+"/"+Get.Data.IconVersion+".png";

                    return Get;
                }
                else
                {
                    throw new Exception("Unkown server error");
                }

            }
            else
            {
                throw new Exception("Wrong server code");
            }

        }
    }
}
