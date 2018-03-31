using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Kerbal.Contracts
{
    [DataContract]
    public class KerbalData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastMission { get; set; }
    }
}
