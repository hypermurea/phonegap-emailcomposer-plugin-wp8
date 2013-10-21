using System;
using System.Runtime.Serialization;
using Microsoft.Phone.Tasks;
using WPCordovaClassLib.Cordova.Commands;

namespace WPCordovaClassLib.Cordova.Commands
{
    [DataContract]
    public class Options
    {
        [DataMember]
        public string to;

        [DataMember]
        public string subject;

        [DataMember]
        public string body;
    }

    public class EmailComposer : BaseCommand
    {
        public void show(string options)
        {
            try
            {
                Options opts = WPCordovaClassLib.Cordova.JSON.JsonHelper.Deserialize<Options>(WPCordovaClassLib.Cordova.JSON.JsonHelper.Deserialize<string[]>(options)[0]);

                EmailComposeTask emailcomposer = new EmailComposeTask();
                emailcomposer.To = opts.to;
                emailcomposer.Subject = opts.subject;
                emailcomposer.Body = opts.body;
                emailcomposer.Show();
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK));
            }
            catch (Exception e)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.JSON_EXCEPTION));
            }
        }
    }
}
