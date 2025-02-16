
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.GridGemData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00089003 : 561155
        // base type : 
        public static void W_TLProtocol_Data_GridGemData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.GridGemData)msg;
                        
            output.PutS32(data.EquipPos);
            output.PutList(data.Slots, output.PutObj);
        }
        public static void R_TLProtocol_Data_GridGemData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.GridGemData)msg;
                        
            data.EquipPos = input.GetS32();
            data.Slots = input.GetList<TLProtocol.Data.GridGemSlotData>(input.GetObj<TLProtocol.Data.GridGemSlotData>);
        }      
    }
}

