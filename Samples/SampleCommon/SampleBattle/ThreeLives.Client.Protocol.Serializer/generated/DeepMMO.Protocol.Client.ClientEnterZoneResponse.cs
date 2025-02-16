
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// DeepMMO.Protocol.Client.ClientEnterZoneResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // DeepMMO.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00034002 : 212994
        // base type : DeepMMO.Protocol.Response
        public static void W_DeepMMO_Protocol_Client_ClientEnterZoneResponse(IOutputStream output, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientEnterZoneResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            
        }
        public static void R_DeepMMO_Protocol_Client_ClientEnterZoneResponse(IInputStream input, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientEnterZoneResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            
        }      
    }
}

