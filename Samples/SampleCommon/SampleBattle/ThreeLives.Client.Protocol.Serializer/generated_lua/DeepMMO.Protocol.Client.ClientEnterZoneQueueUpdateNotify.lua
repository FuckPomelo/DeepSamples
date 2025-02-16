
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- DeepMMO.Protocol.Client.ClientEnterZoneQueueUpdateNotify


local _M = {MessageID = 0x00034005,Name = 'DeepMMO.Protocol.Client.ClientEnterZoneQueueUpdateNotify'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00034005] = _M
Protocol.Serializer.StringDefined['DeepMMO.Protocol.Client.ClientEnterZoneQueueUpdateNotify'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Write(output, data)
	output:PutS32(data.s2c_queueSize)
	output:PutS32(data.s2c_expectTimeSec)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Notify'].Read(input, data)
	data.s2c_queueSize = input:GetS32()
	data.s2c_expectTimeSec = input:GetS32()
end


