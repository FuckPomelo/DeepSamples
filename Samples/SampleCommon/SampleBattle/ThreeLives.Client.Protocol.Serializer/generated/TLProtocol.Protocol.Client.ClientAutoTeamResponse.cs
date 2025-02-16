
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientAutoTeamResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00095010 : 610320
        // base type : TLProtocol.Protocol.Client.TeamResponse
        public static void W_TLProtocol_Protocol_Client_ClientAutoTeamResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAutoTeamResponse)msg;
            W_TLProtocol_Protocol_Client_TeamResponse(output, data);
            
        }
        public static void R_TLProtocol_Protocol_Client_ClientAutoTeamResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAutoTeamResponse)msg;
            R_TLProtocol_Protocol_Client_TeamResponse(input, data);
            
        }      
    }
}

