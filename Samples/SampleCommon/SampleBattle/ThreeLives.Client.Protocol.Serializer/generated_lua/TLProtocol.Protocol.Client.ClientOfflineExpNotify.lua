
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientOfflineExpNotify


local _M = {MessageID = 0x00096025,Name = 'TLProtocol.Protocol.Client.ClientOfflineExpNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00096025] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientOfflineExpNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutS32(data.c2s_exp)
	output:PutS32(data.c2s_extra_exp)
	output:PutTimeSpan(data.c2s_time)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.c2s_exp = input:GetS32()
	data.c2s_extra_exp = input:GetS32()
	data.c2s_time = input:GetTimeSpan()
end


