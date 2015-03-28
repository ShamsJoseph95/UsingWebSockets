using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;

namespace UsingWebSockets
{
    public class MicrosoftWebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();

        public override void OnOpen()
        { 
            //const string names = "<div ng-init=\"friends = [{name:\'John\'},{name:\'Mary\'},{name:\'Mike\'},{name:\'Adam\'},{name:\'Julie\'},{name:\'Juliette\'}]\"></div>";
            const string names = "<div ng-init='friends = [{name:'Yashar'}]'></div>";
            clients.Add(this);
            clients.Broadcast("connected.<br/><hr/>");
            string allNames = JsonConvert.SerializeObject(names);
            clients.Broadcast(allNames);                  
            /********************************************************************/
            //Dictionary<string, string> someNames = new Dictionary<string, string>();

            //someNames.Add("name", "Yashar, Maral, Negin, Siamak");
            //string js = JsonConvert.SerializeObject(someNames);
            //clients.Broadcast(js);
        }
     
        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("Bye!"));
        }

    }
}