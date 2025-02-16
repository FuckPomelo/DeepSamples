
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.CPDemonTowerData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00040005 : 262149
        // base type : 
        public static void W_TLProtocol_Data_CPDemonTowerData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.CPDemonTowerData)msg;
                        
            output.PutS32(data.curPlayTimes);
            output.PutS32(data.maxPlayTimes);
            output.PutS32(data.maxLayer);
            output.PutList(data.giftData, output.PutS32);
        }
        public static void R_TLProtocol_Data_CPDemonTowerData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.CPDemonTowerData)msg;
                        
            data.curPlayTimes = input.GetS32();
            data.maxPlayTimes = input.GetS32();
            data.maxLayer = input.GetS32();
            data.giftData = input.GetList<int>(input.GetS32);
        }      
    }
}

