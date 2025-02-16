
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientSetGuildAttackResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00098038 : 622648
        // base type : TLProtocol.Protocol.Client.GuildResponse
        public static void W_TLProtocol_Protocol_Client_ClientSetGuildAttackResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientSetGuildAttackResponse)msg;
            W_TLProtocol_Protocol_Client_GuildResponse(output, data);
            
        }
        public static void R_TLProtocol_Protocol_Client_ClientSetGuildAttackResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientSetGuildAttackResponse)msg;
            R_TLProtocol_Protocol_Client_GuildResponse(input, data);
            
        }      
    }
}

