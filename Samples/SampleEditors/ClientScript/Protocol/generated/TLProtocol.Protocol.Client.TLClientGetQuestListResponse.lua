
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.TLClientGetQuestListResponse


local _M = {MessageID = 0x00073016,Name = 'TLProtocol.Protocol.Client.TLClientGetQuestListResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00073016] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.TLClientGetQuestListResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Write(output, data)
	output:PutList(data.snaplist, output.PutOBJ,'TLProtocol.Data.QuestDataSnap')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['DeepMMO.Protocol.Response'].Read(input, data)
	data.snaplist = input:GetList(input.GetOBJ,'TLProtocol.Data.QuestDataSnap')
end


