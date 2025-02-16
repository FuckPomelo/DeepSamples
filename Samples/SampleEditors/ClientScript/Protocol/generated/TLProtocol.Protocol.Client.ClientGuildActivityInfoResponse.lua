
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGuildActivityInfoResponse


local _M = {MessageID = 0x0009803A,Name = 'TLProtocol.Protocol.Client.ClientGuildActivityInfoResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009803A] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGuildActivityInfoResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.GuildResponse'].Write(output, data)
	output:PutMap(data.s2c_activityInfo, output.PutUTF, output.PutOBJ,'string', 'TLProtocol.Protocol.Data.GuildActivityInfo')
	output:PutUTF(data.s2c_fort)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.GuildResponse'].Read(input, data)
	data.s2c_activityInfo = input:GetMap(input.GetUTF, input.GetOBJ,'string', 'TLProtocol.Protocol.Data.GuildActivityInfo')
	data.s2c_fort = input:GetUTF()
end


