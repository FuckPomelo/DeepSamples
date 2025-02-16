
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientGetRechargeOrderResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x0009E004 : 647172
        // base type : DeepMMO.Protocol.Response
        public static void W_TLProtocol_Protocol_Client_ClientGetRechargeOrderResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetRechargeOrderResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            output.PutUTF(data.s2c_order_id);
            output.PutUTF(data.s2c_notify_url);
            output.PutMap(data.s2c_ext_data, output.PutUTF, output.PutUTF);
        }
        public static void R_TLProtocol_Protocol_Client_ClientGetRechargeOrderResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetRechargeOrderResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            data.s2c_order_id = input.GetUTF();
            data.s2c_notify_url = input.GetUTF();
            data.s2c_ext_data = input.GetMap<string, string>(input.GetUTF, input.GetUTF);
        }      
    }
}

