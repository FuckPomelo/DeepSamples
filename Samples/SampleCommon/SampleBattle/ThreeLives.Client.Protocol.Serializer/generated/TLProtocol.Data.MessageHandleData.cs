
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.MessageHandleData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00083005 : 536581
        // base type : 
        public static void W_TLProtocol_Data_MessageHandleData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.MessageHandleData)msg;
                        
            output.PutUTF(data.id);
            output.PutEnum8(data.agree);
        }
        public static void R_TLProtocol_Data_MessageHandleData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.MessageHandleData)msg;
                        
            data.id = input.GetUTF();
            data.agree = input.GetEnum8<TLProtocol.Data.AlertHandlerType>();
        }      
    }
}

