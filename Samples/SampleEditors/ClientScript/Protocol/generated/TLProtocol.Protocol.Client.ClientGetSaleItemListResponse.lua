
-- Warning: do not edit this file.
-- 警告: 不要编辑此文件

-- ThreeLives.Client.Protocol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
-- TLProtocol.Protocol.Client.ClientGetSaleItemListResponse


local _M = {MessageID = 0x000A000A,Name = 'TLProtocol.Protocol.Client.ClientGetSaleItemListResponse'}
_M.__index = _M
function _M.IsSuccess(self)
	return self.s2c_code == 200
end
Protocol.Serializer[0x000A000A] = _M
Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.ClientGetSaleItemListResponse'] = _M

function _M.Write(output,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.AuctionResponse'].Write(output, data)
	output:PutMap(data.s2c_saleList, output.PutS32, output.PutOBJ,'int', 'TLProtocol.Protocol.Data.AuctionItemSnap')
end


function _M.Read(input,data)
	Protocol.Serializer.StringDefined['TLProtocol.Protocol.Client.AuctionResponse'].Read(input, data)
	data.s2c_saleList = input:GetMap(input.GetS32, input.GetOBJ,'int', 'TLProtocol.Protocol.Data.AuctionItemSnap')
end


