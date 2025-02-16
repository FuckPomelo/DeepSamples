
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// DeepMMO.Data.ClientInfo


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace SampleRPG
{
    // DeepMMO.Data
    public partial class Serializer
    {
        // msg id    : 0x00020001 : 131073
        // base type : 
        public static void W_DeepMMO_Data_ClientInfo(IOutputStream output, object msg)
        {
            var data = (DeepMMO.Data.ClientInfo)msg;
                        
            output.PutUTF(data.userAgent);
            output.PutUTF(data.mac);
            output.PutUTF(data.osType);
            output.PutUTF(data.channel);
            output.PutUTF(data.userSource1);
            output.PutUTF(data.userSource2);
            output.PutUTF(data.deviceId);
            output.PutUTF(data.deviceType);
            output.PutUTF(data.clientRegion);
            output.PutUTF(data.clientChannel);
            output.PutUTF(data.clientVersion);
            output.PutUTF(data.deviceModel);
        }
        public static void R_DeepMMO_Data_ClientInfo(IInputStream input, object msg)
        {
            var data = (DeepMMO.Data.ClientInfo)msg;
                        
            data.userAgent = input.GetUTF();
            data.mac = input.GetUTF();
            data.osType = input.GetUTF();
            data.channel = input.GetUTF();
            data.userSource1 = input.GetUTF();
            data.userSource2 = input.GetUTF();
            data.deviceId = input.GetUTF();
            data.deviceType = input.GetUTF();
            data.clientRegion = input.GetUTF();
            data.clientChannel = input.GetUTF();
            data.clientVersion = input.GetUTF();
            data.deviceModel = input.GetUTF();
        }      
    }
}

