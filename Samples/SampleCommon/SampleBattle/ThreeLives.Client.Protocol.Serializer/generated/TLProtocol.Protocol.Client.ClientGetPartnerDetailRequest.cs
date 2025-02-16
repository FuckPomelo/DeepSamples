
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientGetPartnerDetailRequest


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00099003 : 626691
        // base type : DeepMMO.Protocol.Request
        public static void W_TLProtocol_Protocol_Client_ClientGetPartnerDetailRequest(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetPartnerDetailRequest)msg;
            W_DeepMMO_Protocol_Request(output, data);
            output.PutList(data.c2s_idLt, output.PutS32);
        }
        public static void R_TLProtocol_Protocol_Client_ClientGetPartnerDetailRequest(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetPartnerDetailRequest)msg;
            R_DeepMMO_Protocol_Request(input, data);
            data.c2s_idLt = input.GetList<int>(input.GetS32);
        }      
    }
}

