
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetAllPackageResponse


local _M = {MessageID = 0x00037011,Name = 'TLProtocol.Protocol.Client.ClientGetAllPackageResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00037011] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetAllPackageResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Write(output, data)
	output:PutMap(data.s2c_bags, output.PutU8, output.PutOBJ,'byte', 'TLProtocol.Data.BagData')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Read(input, data)
	data.s2c_bags = input:GetMap(input.GetU8, input.GetOBJ,'byte', 'TLProtocol.Data.BagData')
end


