
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Client.TLClientMarrySuccessNotify


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00082068 : 532584
        // base type : DeepMMO.Protocol.Notify
        public static void W_TLProtocol_Protocol_Client_TLClientMarrySuccessNotify(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Client.TLClientMarrySuccessNotify)msg;
            W_DeepMMO_Protocol_Notify(output, data);
            output.PutMap(data.data, output.PutUTF, output.PutUTF);
        }
        public static void R_TLProtocol_Protocol_Client_TLClientMarrySuccessNotify(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Client.TLClientMarrySuccessNotify)msg;
            R_DeepMMO_Protocol_Notify(input, data);
            data.data = input.GetMap<string, string>(input.GetUTF, input.GetUTF);
        }      
    }
}

