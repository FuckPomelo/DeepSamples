
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- ThreeLives.Client.Protocol.Data.PhotoInfo


local _M = {MessageID = 0x00079601,Name = 'ThreeLives.Client.Protocol.Data.PhotoInfo'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00079601] = _M
Protocol.Serializer.StringDefined['ThreeLives.Client.Protocol.Data.PhotoInfo'] = _M

function _M.Write(output,data)
		
	output:PutUTF(data.photoName)
	output:PutS32(data.status)
end


function _M.Read(input,data)
		
	data.photoName = input:GetUTF()
	data.status = input:GetS32()
end


