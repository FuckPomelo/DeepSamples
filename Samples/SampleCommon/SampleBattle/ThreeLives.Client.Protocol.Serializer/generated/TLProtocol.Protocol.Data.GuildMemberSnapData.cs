
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// TLProtocol.Protocol.Data.GuildMemberSnapData


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // TLProtocol.Protocol.Data
    public partial class Serializer
    {
        // msg id    : 0x00087004 : 552964
        // base type : 
        public static void W_TLProtocol_Protocol_Data_GuildMemberSnapData(IOutputStream output, object msg)
        {
            var data = (TLProtocol.Protocol.Data.GuildMemberSnapData)msg;
                        
            output.PutUTF(data.name);
            output.PutUTF(data.roleId);
            output.PutS32(data.level);
            output.PutS32(data.pro);
            output.PutS32(data.gender);
            output.PutS64(data.power);
            output.PutS32(data.donate);
            output.PutDateTime(data.leaveTime);
            output.PutUTF(data.guildId);
            output.PutS32(data.position);
            output.PutS32(data.contributionDay);
            output.PutS32(data.contributionMax);
            output.PutDateTime(data.ExpiredUtc);
        }
        public static void R_TLProtocol_Protocol_Data_GuildMemberSnapData(IInputStream input, object msg)
        {
            var data = (TLProtocol.Protocol.Data.GuildMemberSnapData)msg;
                        
            data.name = input.GetUTF();
            data.roleId = input.GetUTF();
            data.level = input.GetS32();
            data.pro = input.GetS32();
            data.gender = input.GetS32();
            data.power = input.GetS64();
            data.donate = input.GetS32();
            data.leaveTime = input.GetDateTime();
            data.guildId = input.GetUTF();
            data.position = input.GetS32();
            data.contributionDay = input.GetS32();
            data.contributionMax = input.GetS32();
            data.ExpiredUtc = input.GetDateTime();
        }      
    }
}

