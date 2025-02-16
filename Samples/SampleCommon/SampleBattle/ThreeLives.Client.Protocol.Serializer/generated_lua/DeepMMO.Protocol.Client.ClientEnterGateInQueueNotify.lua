
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- DeepMMO.Protocol.Client.ClientEnterGateInQueueNotify


local _M = {MessageID = 0x00031003,Name = 'DeepMMO.Protocol.Client.ClientEnterGateInQueueNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00031003] = _M
Protocol.Serializer.StringDefined['DeepMMO.Protocol.Client.ClientEnterGateInQueueNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutBool(data.IsEnetered)
	output:PutS32(data.QueueIndex)
	output:PutTimeSpan(data.ExpectTime)
	if data:IsEnetered()==true then
	output:PutUTF(data.s2c_connectHost)
	output:PutS32(data.s2c_connectPort)
	output:PutUTF(data.s2c_connectToken)
	output:PutUTF(data.s2c_lastLoginToken)
	end
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.IsEnetered = input:GetBool()
	data.QueueIndex = input:GetS32()
	data.ExpectTime = input:GetTimeSpan()
	if data:IsEnetered()==true then
	data.s2c_connectHost = input:GetUTF()
	data.s2c_connectPort = input:GetS32()
	data.s2c_connectToken = input:GetUTF()
	data.s2c_lastLoginToken = input:GetUTF()
	end
end


