
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// DeepMMO.Protocol.Client.ClientPing


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // DeepMMO.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00035001 : 217089
        // base type : DeepMMO.Protocol.Request
        public static void W_DeepMMO_Protocol_Client_ClientPing(IOutputStream output, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientPing)msg;
            W_DeepMMO_Protocol_Request(output, data);
            output.PutDateTime(data.time);
            output.PutBytes(data.rawdata);
        }
        public static void R_DeepMMO_Protocol_Client_ClientPing(IInputStream input, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientPing)msg;
            R_DeepMMO_Protocol_Request(input, data);
            data.time = input.GetDateTime();
            data.rawdata = input.GetBytes();
        }      
    }
}

