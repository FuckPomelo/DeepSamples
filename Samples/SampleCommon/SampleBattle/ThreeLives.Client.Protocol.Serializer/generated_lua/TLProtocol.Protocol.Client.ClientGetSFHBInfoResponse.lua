
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetSFHBInfoResponse


local _M = {MessageID = 0x0009D022,Name = 'TLProtocol.Protocol.Client.ClientGetSFHBInfoResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009D022] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetSFHBInfoResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Write(output, data)
	output:PutU32(data.s2c_currency_count)
	output:PutU32(data.s2c_item_count)
	output:PutU32(data.s2c_cumulative_count)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Read(input, data)
	data.s2c_currency_count = input:GetU32()
	data.s2c_item_count = input:GetU32()
	data.s2c_cumulative_count = input:GetU32()
end


