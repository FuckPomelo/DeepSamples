
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientGetArtifactListResponse


local _M = {MessageID = 0x0006D002,Name = 'TLProtocol.Protocol.Client.TLClientGetArtifactListResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x0006D002] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientGetArtifactListResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Write(output, data)
	output:PutMap(data.artifactMap, output.PutS32, output.PutS32,'int', 'int')
	output:PutS32(data.MainEquipId)
	output:PutS32(data.SecondEquipId)
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Read(input, data)
	data.artifactMap = input:GetMap(input.GetS32, input.GetS32,'int', 'int')
	data.MainEquipId = input:GetS32()
	data.SecondEquipId = input:GetS32()
end


