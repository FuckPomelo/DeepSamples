
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetDailyRechargeGiftInfoNotify


local _M = {MessageID = 0x0009D00C,Name = 'TLProtocol.Protocol.Client.ClientGetDailyRechargeGiftInfoNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009D00C] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetDailyRechargeGiftInfoNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutList(data.s2c_list, output.PutOBJ,'ThreeLives.Client.Protocol.Data.TLDailyRechargeProductInfo')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.s2c_list = input:GetList(input.GetOBJ,'ThreeLives.Client.Protocol.Data.TLDailyRechargeProductInfo')
end


