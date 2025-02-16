
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetTeamSnapResponse


local _M = {MessageID = 0x00095006,Name = 'TLProtocol.Protocol.Client.ClientGetTeamSnapResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00095006] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetTeamSnapResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TeamResponse'].Write(output, data)
	output:PutArray(data.s2c_teamList, output.PutOBJ,'TLProtocol.Data.TeamData')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TeamResponse'].Read(input, data)
	data.s2c_teamList = input:GetArray(input.GetOBJ,'TLProtocol.Data.TeamData')
end


