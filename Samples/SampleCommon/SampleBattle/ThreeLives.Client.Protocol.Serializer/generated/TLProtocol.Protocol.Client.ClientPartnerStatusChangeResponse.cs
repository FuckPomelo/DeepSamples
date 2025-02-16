
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientPartnerStatusChangeResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x0009901A : 626714
        // base type : DeepMMO.Protocol.Response
        public static void W_TLProtocol_Protocol_Client_ClientPartnerStatusChangeResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientPartnerStatusChangeResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            output.PutS32(data.s2c_partnerID);
            output.PutU8(data.s2c_status);
        }
        public static void R_TLProtocol_Protocol_Client_ClientPartnerStatusChangeResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientPartnerStatusChangeResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            data.s2c_partnerID = input.GetS32();
            data.s2c_status = input.GetU8();
        }      
    }
}

