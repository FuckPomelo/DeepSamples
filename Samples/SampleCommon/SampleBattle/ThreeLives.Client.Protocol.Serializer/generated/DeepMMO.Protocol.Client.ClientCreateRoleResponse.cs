
// Warning: do not edit this file.
// 警告: 不要编辑此文件

// DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// DeepMMO.Protocol.Client.ClientCreateRoleResponse


using DeepCore;
using DeepCore.IO;
using System.Collections.Generic;

namespace TLClient
{
    // DeepMMO.Protocol.Client
    public partial class Serializer
    {
        // msg id    : 0x00033004 : 208900
        // base type : DeepMMO.Protocol.Response
        public static void W_DeepMMO_Protocol_Client_ClientCreateRoleResponse(IOutputStream output, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientCreateRoleResponse)msg;
            W_DeepMMO_Protocol_Response(output, data);
            if (data.IsSuccess==true) {
            output.PutObj(data.s2c_role);
            }
        }
        public static void R_DeepMMO_Protocol_Client_ClientCreateRoleResponse(IInputStream input, object msg)
        {
            var data = (DeepMMO.Protocol.Client.ClientCreateRoleResponse)msg;
            R_DeepMMO_Protocol_Response(input, data);
            if (data.IsSuccess==true) {
            data.s2c_role = input.GetObj<DeepMMO.Data.RoleSnap>();
            }
        }      
    }
}

