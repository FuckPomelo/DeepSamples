
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- ThreeLives.Client.Protocol.Data.TLBActivitySnapData


local _M = {MessageID = 0x0009D501,Name = 'ThreeLives.Client.Protocol.Data.TLBActivitySnapData'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009D501] = _M
Protocol.Serializer.StringDefined['ThreeLives.Client.Protocol.Data.TLBActivitySnapData'] = _M

function _M.Write(output,data)
		
	output:PutS32(data.id)
	output:PutS32(data.state)
	output:PutList(data.requireList, output.PutOBJ,'TLProtocol.Data.RequireSnapData')
end


function _M.Read(input,data)
		
	data.id = input:GetS32()
	data.state = input:GetS32()
	data.requireList = input:GetList(input.GetOBJ,'TLProtocol.Data.RequireSnapData')
end


