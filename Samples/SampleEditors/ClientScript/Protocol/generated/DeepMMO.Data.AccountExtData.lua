
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- DeepMMO.Data.AccountExtData


local _M = {MessageID = 0x00021003,Name = 'DeepMMO.Data.AccountExtData'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00021003] = _M
Protocol.Serializer.StringDefined['DeepMMO.Data.AccountExtData'] = _M

function _M.Write(output,data)
		
	output:PutMap(data.data, output.PutUTF, output.PutUTF,'string', 'string')
end


function _M.Read(input,data)
		
	data.data = input:GetMap(input.GetUTF, input.GetUTF,'string', 'string')
end


