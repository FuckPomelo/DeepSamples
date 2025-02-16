
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetGodBookInfoResponse


local _M = {MessageID = 0x0009950A,Name = 'TLProtocol.Protocol.Client.ClientGetGodBookInfoResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0009950A] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetGodBookInfoResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Write(output, data)
	output:PutList(data.s2c_books, output.PutS32,'int')
	output:PutS64(data.s2c_fightpower)
	output:PutMap(data.s2c_props, output.PutUTF, output.PutS32,'string', 'int')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Read(input, data)
	data.s2c_books = input:GetList(input.GetS32,'int')
	data.s2c_fightpower = input:GetS64()
	data.s2c_props = input:GetMap(input.GetUTF, input.GetS32,'string', 'int')
end


