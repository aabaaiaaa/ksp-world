using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.WpfApp
{
    [ServiceContract(Namespace = "http://localhost/message-service-namespace")]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage(string message);
    }
}
