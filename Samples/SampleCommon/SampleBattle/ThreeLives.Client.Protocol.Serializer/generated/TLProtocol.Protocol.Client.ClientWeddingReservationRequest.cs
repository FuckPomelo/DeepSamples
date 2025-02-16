
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientWeddingReservationRequest


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00050033 : 327731
        // base type : DeepMMO.Protocol.Request
        public static void W_TLProtocol_Protocol_Client_ClientWeddingReservationRequest(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientWeddingReservationRequest)msg;
            W_DeepMMO_Protocol_Request(output, data);
            output.PutUTF(data.spouseId);
            output.PutS32(data.weddingType);
            output.PutDateTime(data.date);
            output.PutS32(data.time);
        }
        public static void R_TLProtocol_Protocol_Client_ClientWeddingReservationRequest(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientWeddingReservationRequest)msg;
            R_DeepMMO_Protocol_Request(input, data);
            data.spouseId = input.GetUTF();
            data.weddingType = input.GetS32();
            data.date = input.GetDateTime();
            data.time = input.GetS32();
        }      
    }
}

