
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.CatalogData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x000401F5 : 262645
        // base type : 
        public static void W_TLProtocol_Data_CatalogData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.CatalogData)msg;
                        
            output.PutS32(data.type);
            output.PutS32(data.curVal);
            output.PutS32(data.maxVal);
        }
        public static void R_TLProtocol_Data_CatalogData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.CatalogData)msg;
                        
            data.type = input.GetS32();
            data.curVal = input.GetS32();
            data.maxVal = input.GetS32();
        }      
    }
}

