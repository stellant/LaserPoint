using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Xml;

namespace LaserPoint_Keyence_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITemperature" in both code and config file together.
    [ServiceContract]
    public interface ITemperature
    {
        [OperationContract]
        [WebGet(UriTemplate = "/input?port={port}&baudRate={baudRate}")]
        XmlElement GetTemperature(string port, string baudRate);
    }
}
