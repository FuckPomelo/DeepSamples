
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify


local _M = {MessageID = 0x00082067,Name = 'TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00082067] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientTeamRelationUpNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutMap(data.players, output.PutUTF, output.PutUTF,'string', 'string')
	output:PutS32(data.addRelation)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.players = input:GetMap(input.GetUTF, input.GetUTF,'string', 'string')
	data.addRelation = input:GetS32()
end


