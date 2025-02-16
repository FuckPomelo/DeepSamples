
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.ClientPackagePackUpResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00037005 : 225285
        // base type : DeepMMO.Protocol.Response
        public static void W_TLProtocol_Protocol_Client_ClientPackagePackUpResponse(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientPackagePackUpResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            
        }
        public static void R_TLProtocol_Protocol_Client_ClientPackagePackUpResponse(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.ClientPackagePackUpResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            
        }      
    }
}

