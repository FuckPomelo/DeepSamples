
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientPartnerEXPChangeNotify


local _M = {MessageID = 0x0009900D,Name = 'TLProtocol.Protocol.Client.ClientPartnerEXPChangeNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009900D] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientPartnerEXPChangeNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutS32(data.s2c_partnerID)
	output:PutU64(data.s2c_exp)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.s2c_partnerID = input:GetS32()
	data.s2c_exp = input:GetU64()
end


