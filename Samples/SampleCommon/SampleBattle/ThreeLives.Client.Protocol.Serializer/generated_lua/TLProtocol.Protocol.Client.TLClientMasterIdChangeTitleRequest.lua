
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientMasterIdChangeTitleRequest


local _M = {MessageID = 0x000400D8,Name = 'TLProtocol.Protocol.Client.TLClientMasterIdChangeTitleRequest'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x000400D8] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientMasterIdChangeTitleRequest'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Write(output, data)
	output:PutUTF(data.roleID)
	output:PutUTF(data.rename)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Request'].Read(input, data)
	data.roleID = input:GetUTF()
	data.rename = input:GetUTF()
end


