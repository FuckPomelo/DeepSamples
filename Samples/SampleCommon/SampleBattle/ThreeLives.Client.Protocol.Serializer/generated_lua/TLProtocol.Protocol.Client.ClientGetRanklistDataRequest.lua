
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetRanklistDataRequest


local _M = {MessageID = 0x0009B003,Name = 'TLProtocol.Protocol.Client.ClientGetRanklistDataRequest'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009B003] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetRanklistDataRequest'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Write(output, data)
	output:PutS32(data.group_id)
	output:PutS32(data.child_id)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Read(input, data)
	data.group_id = input:GetS32()
	data.child_id = input:GetS32()
end


