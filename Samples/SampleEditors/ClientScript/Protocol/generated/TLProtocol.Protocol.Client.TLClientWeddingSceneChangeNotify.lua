
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientWeddingSceneChangeNotify


local _M = {MessageID = 0x0008206A,Name = 'TLProtocol.Protocol.Client.TLClientWeddingSceneChangeNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0008206A] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientWeddingSceneChangeNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutBool(data.needChangeScene)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.needChangeScene = input:GetBool()
end


