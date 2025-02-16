
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// ThreeLives.Client.Protocol.Protocol.Client.ClientBuyDailyTicketsResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // ThreeLives.Client.Protocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x0009E206 : 647686
        // base type : DeepMMO.Protocol.Response
        public static void W_ThreeLives_Client_Protocol_Protocol_Client_ClientBuyDailyTicketsResponse(IOutputStream output, object msg)
        {
            var data = (ThreeLives.Client.Protocol.Protocol.Client.ClientBuyDailyTicketsResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            output.PutS32(data.s2c_count);
            output.PutUTF(data.s2c_functionid);
        }
        public static void R_ThreeLives_Client_Protocol_Protocol_Client_ClientBuyDailyTicketsResponse(IInputStream input, object msg)
        {
            var data = (ThreeLives.Client.Protocol.Protocol.Client.ClientBuyDailyTicketsResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            data.s2c_count = input.GetS32();
            data.s2c_functionid = input.GetUTF();
        }      
    }
}

