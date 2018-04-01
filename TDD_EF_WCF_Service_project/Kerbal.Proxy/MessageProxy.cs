using Kerbal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Proxy
{
    public class MessageProxy : ClientBase<IMessageService>, IMessageService
    {
        public void ShowMessage(string message)
        {
            Channel.ShowMessage(message);
        }
    }
}
