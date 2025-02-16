
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientChatRequest


local _M = {MessageID = 0x00092001,Name = 'TLProtocol.Protocol.Client.ClientChatRequest'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00092001] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientChatRequest'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Write(output, data)
	output:PutUTF(data.to_uuid)
	output:PutUTF(data.content)
	output:PutS16(data.channel_type)
	output:PutS16(data.show_type)
	output:PutArray(data.show_channel, output.PutS16,'short')
	output:PutS16(data.func_type)
	output:PutUTF(data.from_name)
	output:PutUTF(data.from_uuid)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Read(input, data)
	data.to_uuid = input:GetUTF()
	data.content = input:GetUTF()
	data.channel_type = input:GetS16()
	data.show_type = input:GetS16()
	data.show_channel = input:GetArray(input.GetS16,'short')
	data.func_type = input:GetS16()
	data.from_name = input:GetUTF()
	data.from_uuid = input:GetUTF()
end


