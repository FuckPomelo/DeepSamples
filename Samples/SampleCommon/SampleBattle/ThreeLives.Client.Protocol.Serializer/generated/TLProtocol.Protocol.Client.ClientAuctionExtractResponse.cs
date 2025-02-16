
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientAuctionExtractResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x000A0012 : 655378
        // base type : TLProtocol.Protocol.Client.AuctionResponse
        public static void W_TLProtocol_Protocol_Client_ClientAuctionExtractResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAuctionExtractResponse)msg;
            W_TLProtocol_Protocol_Client_AuctionResponse(output, data);
            output.PutU64(data.s2c_goldMax);
        }
        public static void R_TLProtocol_Protocol_Client_ClientAuctionExtractResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientAuctionExtractResponse)msg;
            R_TLProtocol_Protocol_Client_AuctionResponse(input, data);
            data.s2c_goldMax = input.GetU64();
        }      
    }
}

