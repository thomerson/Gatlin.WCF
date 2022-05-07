using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Gatlin.WCF.Hosting
{
    public class WCFBinding
    {
        public Binding Binding { get; set; }
        public string PreAddress { get; set; }
        public WCFBinding()
        {
            var bindingName = AppSetting.Get("Binding");
            switch (bindingName)
            {
                case "BasicHttpBinding":
                    this.Binding = new BasicHttpBinding();
                    this.PreAddress = "http://";
                    break;
                case "NetTcpBinding":
                    this.Binding = new NetTcpBinding();
                    this.PreAddress = "net.tcp://";
                    break;
                //case "NetPeerTcpBinding": return new NetPeerTcpBinding();
                case "NetNamedPipeBinding":
                    this.Binding = new NetNamedPipeBinding();
                    this.PreAddress = "net.pipe://";
                    break;
                case "WSHttpBinding":
                    this.Binding = new WSHttpBinding();
                    this.PreAddress = "http://";
                    break;
                case "WSDualHttpBinding":
                    this.Binding = new WSDualHttpBinding();
                    this.PreAddress = "http://";
                    break;
                case "NetMsmqBinding":
                    this.Binding = new NetMsmqBinding();
                    this.PreAddress = "net.msmq://";
                    break;
                default:
                    break;
            }


        }
    }
}
