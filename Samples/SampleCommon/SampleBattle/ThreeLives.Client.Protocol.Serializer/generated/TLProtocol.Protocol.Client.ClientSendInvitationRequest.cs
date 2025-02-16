
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientSendInvitationRequest


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00050027 : 327719
        // base type : DeepMMO.Protocol.Request
        public static void W_TLProtocol_Protocol_Client_ClientSendInvitationRequest(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientSendInvitationRequest)msg;
            W_DeepMMO_Protocol_Request(output, data);
            output.PutS32(data.slotIndex);
            output.PutMap(data.friendIds, output.PutUTF, output.PutUTF);
        }
        public static void R_TLProtocol_Protocol_Client_ClientSendInvitationRequest(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientSendInvitationRequest)msg;
            R_DeepMMO_Protocol_Request(input, data);
            data.slotIndex = input.GetS32();
            data.friendIds = input.GetMap<string, string>(input.GetUTF, input.GetUTF);
        }      
    }
}

