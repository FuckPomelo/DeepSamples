
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- DeepMMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- DeepMMO.Data.RoleTemplateData


local _M = {MessageID = 0x00022001,Name = 'DeepMMO.Data.RoleTemplateData'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00022001] = _M
Protocol.Serializer.StringDefined['DeepMMO.Data.RoleTemplateData'] = _M

function _M.Write(output,data)
		
	output:PutS32(data.id)
	output:PutUTF(data.name)
	output:PutU8(data.gender)
	output:PutS32(data.unit_template_id)
end


function _M.Read(input,data)
		
	data.id = input:GetS32()
	data.name = input:GetUTF()
	data.gender = input:GetU8()
	data.unit_template_id = input:GetS32()
end


