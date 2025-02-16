
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientChangeNoticeResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00098008 : 622600
        // base type : TLProtocol.Protocol.Client.GuildResponse
        public static void W_TLProtocol_Protocol_Client_ClientChangeNoticeResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientChangeNoticeResponse)msg;
            W_TLProtocol_Protocol_Client_GuildResponse(output, data);
            output.PutUTF(data.s2c_context);
        }
        public static void R_TLProtocol_Protocol_Client_ClientChangeNoticeResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientChangeNoticeResponse)msg;
            R_TLProtocol_Protocol_Client_GuildResponse(input, data);
            data.s2c_context = input.GetUTF();
        }      
    }
}

