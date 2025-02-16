
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Data.TLRoleSnap


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00062004 : 401412
        // base type : DeepMMO.Data.RoleSnap
        public static void W_TLProtocol_Data_TLRoleSnap(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Data.TLRoleSnap)msg;
            W_DeepMMO_Data_RoleSnap(output, data);
            output.PutS64(data.FightPower);
            output.PutU8(data.UnitPro);
            output.PutU8(data.Gender);
            output.PutS32(data.PracticeLv);
            output.PutUTF(data.GuildId);
            output.PutUTF(data.GuildName);
            output.PutDateTime(data.LastOfflineTime);
            output.PutUTF(data.ZoneUUID);
            output.PutS32(data.MapTemplateID);
            output.PutList(data.AvatarInfo, output.PutObj);
            output.PutS32(data.AvatarScore);
            output.PutDateTime(data.ExpiredUtc);
            output.PutS32(data.MaxDemonTowerLayer);
            output.PutDateTime(data.MaxDemonTowerDateTime);
            output.PutS32(data.TitleID);
            output.PutS32(data.MasterId);
            output.PutU64(data.Copper);
            output.PutU64(data.Sliver);
            output.PutS64(data.GodScore);
            output.PutS64(data.MountScore);
            output.PutS64(data.ArtifactScore);
            output.PutS64(data.WingScore);
            output.PutS64(data.MeridiansScore);
            output.PutS32(data.CPTowerLayer);
            output.PutMap(data.Options, output.PutUTF, output.PutUTF);
        }
        public static void R_TLProtocol_Data_TLRoleSnap(IInputStream input, object msg)
        {
            var data = (TLProtocol.Data.TLRoleSnap)msg;
            R_DeepMMO_Data_RoleSnap(input, data);
            data.FightPower = input.GetS64();
            data.UnitPro = input.GetU8();
            data.Gender = input.GetU8();
            data.PracticeLv = input.GetS32();
            data.GuildId = input.GetUTF();
            data.GuildName = input.GetUTF();
            data.LastOfflineTime = input.GetDateTime();
            data.ZoneUUID = input.GetUTF();
            data.MapTemplateID = input.GetS32();
            data.AvatarInfo = input.GetList<TLProtocol.Data.AvatarInfoSnap>(input.GetObj<TLProtocol.Data.AvatarInfoSnap>);
            data.AvatarScore = input.GetS32();
            data.ExpiredUtc = input.GetDateTime();
            data.MaxDemonTowerLayer = input.GetS32();
            data.MaxDemonTowerDateTime = input.GetDateTime();
            data.TitleID = input.GetS32();
            data.MasterId = input.GetS32();
            data.Copper = input.GetU64();
            data.Sliver = input.GetU64();
            data.GodScore = input.GetS64();
            data.MountScore = input.GetS64();
            data.ArtifactScore = input.GetS64();
            data.WingScore = input.GetS64();
            data.MeridiansScore = input.GetS64();
            data.CPTowerLayer = input.GetS32();
            data.Options = input.GetMap<string, string>(input.GetUTF, input.GetUTF);
        }      
    }
}

