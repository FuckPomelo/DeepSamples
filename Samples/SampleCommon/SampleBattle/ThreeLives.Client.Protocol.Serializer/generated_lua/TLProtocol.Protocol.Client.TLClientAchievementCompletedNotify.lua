
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientAchievementCompletedNotify


local _M = {MessageID = 0x000401FE,Name = 'TLProtocol.Protocol.Client.TLClientAchievementCompletedNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x000401FE] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientAchievementCompletedNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutList(data.s2c_data, output.PutOBJ,'TLProtocol.Data.AchievementDataSnap')
	output:PutBool(data.ShowTips)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.s2c_data = input:GetList(input.GetOBJ,'TLProtocol.Data.AchievementDataSnap')
	data.ShowTips = input:GetBool()
end


