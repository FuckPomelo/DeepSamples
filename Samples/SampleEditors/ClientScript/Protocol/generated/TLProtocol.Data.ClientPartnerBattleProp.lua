
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Data.ClientPartnerBattleProp


local _M = {MessageID = 0x00088002,Name = 'TLProtocol.Data.ClientPartnerBattleProp'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x00088002] = _M
Protocol.Serializer.StringDefined['TLProtocol.Data.ClientPartnerBattleProp'] = _M

function _M.Write(output,data)
		
	output:PutS32(data.maxhp)
	output:PutS32(data.attack)
	output:PutS32(data.defend)
	output:PutS32(data.mdef)
	output:PutS32(data.through)
	output:PutS32(data.block)
	output:PutS32(data.crit)
	output:PutS32(data.hit)
end


function _M.Read(input,data)
		
	data.maxhp = input:GetS32()
	data.attack = input:GetS32()
	data.defend = input:GetS32()
	data.mdef = input:GetS32()
	data.through = input:GetS32()
	data.block = input:GetS32()
	data.crit = input:GetS32()
	data.hit = input:GetS32()
end


