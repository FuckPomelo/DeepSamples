
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetOtherItemListResponse


local _M = {MessageID = 0x000A000E,Name = 'TLProtocol.Protocol.Client.ClientGetOtherItemListResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x000A000E] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetOtherItemListResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.AuctionResponse'].Write(output, data)
	output:PutList(data.s2c_list, output.PutOBJ,'TLProtocol.Protocol.Data.AuctionItemSnap')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.AuctionResponse'].Read(input, data)
	data.s2c_list = input:GetList(input.GetOBJ,'TLProtocol.Protocol.Data.AuctionItemSnap')
end


