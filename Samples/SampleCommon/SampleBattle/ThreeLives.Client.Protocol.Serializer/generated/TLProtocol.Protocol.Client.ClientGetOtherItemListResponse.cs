
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientGetOtherItemListResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x000A000E : 655374
        // base type : TLProtocol.Protocol.Client.AuctionResponse
        public static void W_TLProtocol_Protocol_Client_ClientGetOtherItemListResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetOtherItemListResponse)msg;
            W_TLProtocol_Protocol_Client_AuctionResponse(output, data);
            output.PutList(data.s2c_list, output.PutObj);
        }
        public static void R_TLProtocol_Protocol_Client_ClientGetOtherItemListResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientGetOtherItemListResponse)msg;
            R_TLProtocol_Protocol_Client_AuctionResponse(input, data);
            data.s2c_list = input.GetList<TLProtocol.Protocol.Data.AuctionItemSnap>(input.GetObj<TLProtocol.Protocol.Data.AuctionItemSnap>);
        }      
    }
}

