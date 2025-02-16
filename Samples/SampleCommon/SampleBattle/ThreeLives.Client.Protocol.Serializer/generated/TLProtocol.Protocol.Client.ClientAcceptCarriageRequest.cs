
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientAcceptCarriageRequest


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x0007301D : 471069
        // base type : DeepMMO.Protocol.Request
        public static void W_TLProtocol_Protocol_Client_ClientAcceptCarriageRequest(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAcceptCarriageRequest)msg;
            W_DeepMMO_Protocol_Request(output, data);
            output.PutS32(data.c2s_id);
        }
        public static void R_TLProtocol_Protocol_Client_ClientAcceptCarriageRequest(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAcceptCarriageRequest)msg;
            R_DeepMMO_Protocol_Request(input, data);
            data.c2s_id = input.GetS32();
        }      
    }
}

