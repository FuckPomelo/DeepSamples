
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.MasterIdListData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x000400C8 : 262344
        // base type : 
        public static void W_TLProtocol_Data_MasterIdListData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.MasterIdListData)msg;
                        
            output.PutList(data.masterDataMap, output.PutObj);
            output.PutList(data.battleRecordList, output.PutObj);
            output.PutDateTime(data.challengeCD);
            output.PutDateTime(data.renameCD);
            output.PutDateTime(data.AppointCD);
            output.PutDateTime(data.InviteCD);
            output.PutS32(data.curMasterId);
            output.PutUTF(data.QinXinName);
        }
        public static void R_TLProtocol_Data_MasterIdListData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.MasterIdListData)msg;
                        
            data.masterDataMap = input.GetList<TLProtocol.Data.MasterIdData>(input.GetObj<TLProtocol.Data.MasterIdData>);
            data.battleRecordList = input.GetList<TLProtocol.Data.MasterIdBattleInfoData>(input.GetObj<TLProtocol.Data.MasterIdBattleInfoData>);
            data.challengeCD = input.GetDateTime();
            data.renameCD = input.GetDateTime();
            data.AppointCD = input.GetDateTime();
            data.InviteCD = input.GetDateTime();
            data.curMasterId = input.GetS32();
            data.QinXinName = input.GetUTF();
        }      
    }
}

