
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientMarrySuccessNotify


local _M = {MessageID = 0x00082068,Name = 'TLProtocol.Protocol.Client.TLClientMarrySuccessNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00082068] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientMarrySuccessNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutMap(data.data, output.PutUTF, output.PutUTF,'string', 'string')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.data = input:GetMap(input.GetUTF, input.GetUTF,'string', 'string')
end


