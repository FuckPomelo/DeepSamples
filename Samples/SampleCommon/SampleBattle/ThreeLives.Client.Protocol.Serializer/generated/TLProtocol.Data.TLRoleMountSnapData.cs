
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.TLRoleMountSnapData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00069601 : 431617
        // base type : 
        public static void W_TLProtocol_Data_TLRoleMountSnapData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.TLRoleMountSnapData)msg;
                        
            output.PutList(data.mounts, output.PutS32);
            output.PutS32(data.currentId);
            output.PutS32(data.veinId);
        }
        public static void R_TLProtocol_Data_TLRoleMountSnapData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.TLRoleMountSnapData)msg;
                        
            data.mounts = input.GetList<int>(input.GetS32);
            data.currentId = input.GetS32();
            data.veinId = input.GetS32();
        }      
    }
}

