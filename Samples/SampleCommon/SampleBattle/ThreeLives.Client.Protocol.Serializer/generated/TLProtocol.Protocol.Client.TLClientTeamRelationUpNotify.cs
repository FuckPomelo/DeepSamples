
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00082067 : 532583
        // base type : DeepMMO.Protocol.Notify
        public static void W_TLProtocol_Protocol_Client_TLClientTeamRelationUpNotify(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify)msg;
            W_DeepMMO_Protocol_Notify(output, data);
            output.PutMap(data.players, output.PutUTF, output.PutUTF);
            output.PutS32(data.addRelation);
        }
        public static void R_TLProtocol_Protocol_Client_TLClientTeamRelationUpNotify(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify)msg;
            R_DeepMMO_Protocol_Notify(input, data);
            data.players = input.GetMap<string, string>(input.GetUTF, input.GetUTF);
            data.addRelation = input.GetS32();
        }      
    }
}

