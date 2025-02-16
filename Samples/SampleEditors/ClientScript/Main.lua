import 'UnityEngine'
import 'SLua'

local old_print = print
print = function(...)
    if TLUnityDebug.DEBUG_MODE then
        old_print(...)
    end
end

function table.len(t)
    local ret = 0
    for i, v in pairs(t or {}) do
        ret = ret + 1
    end
    return ret
end

function table.ContainsValue(t, value)
    for k, v in pairs(t) do
        if v == value then
            return true
        end
    end
    return false
end


function string.starts(String, Start)
    return string.sub(String, 1, string.len(Start)) == Start
end

function string.ends(String, End)
    return End == '' or string.sub(String, -string.len(End)) == End
end

local byte    = string.byte
local char    = string.char
local dump    = string.dump
local find    = string.find
local format  = string.format
local len     = string.len
local lower   = string.lower
local rep     = string.rep
local sub     = string.sub
local upper   = string.upper

-- returns the number of bytes used by the UTF-8 character at byte i in s
-- also doubles as a UTF-8 character validator
local function utf8charbytes (s, i)
	-- argument defaults
	i = i or 1

	-- argument checking
	if type(s) ~= "string" then
		error("bad argument #1 to 'utf8charbytes' (string expected, got ".. type(s).. ")")
	end
	if type(i) ~= "number" then
		error("bad argument #2 to 'utf8charbytes' (number expected, got ".. type(i).. ")")
	end

	local c = byte(s, i)

	-- determine bytes needed for character, based on RFC 3629
	-- validate byte 1
	if c > 0 and c <= 127 then
		-- UTF8-1
		return 1

	elseif c >= 194 and c <= 223 then
		-- UTF8-2
		local c2 = byte(s, i + 1)

		if not c2 then
			error("UTF-8 string terminated early")
		end

		-- validate byte 2
		if c2 < 128 or c2 > 191 then
			error("Invalid UTF-8 character")
		end

		return 2

	elseif c >= 224 and c <= 239 then
		-- UTF8-3
		local c2 = byte(s, i + 1)
		local c3 = byte(s, i + 2)

		if not c2 or not c3 then
			error("UTF-8 string terminated early")
		end

		-- validate byte 2
		if c == 224 and (c2 < 160 or c2 > 191) then
			error("Invalid UTF-8 character")
		elseif c == 237 and (c2 < 128 or c2 > 159) then
			error("Invalid UTF-8 character")
		elseif c2 < 128 or c2 > 191 then
			error("Invalid UTF-8 character")
		end

		-- validate byte 3
		if c3 < 128 or c3 > 191 then
			error("Invalid UTF-8 character")
		end

		return 3

	elseif c >= 240 and c <= 244 then
		-- UTF8-4
		local c2 = byte(s, i + 1)
		local c3 = byte(s, i + 2)
		local c4 = byte(s, i + 3)

		if not c2 or not c3 or not c4 then
			error("UTF-8 string terminated early")
		end

		-- validate byte 2
		if c == 240 and (c2 < 144 or c2 > 191) then
			error("Invalid UTF-8 character")
		elseif c == 244 and (c2 < 128 or c2 > 143) then
			error("Invalid UTF-8 character")
		elseif c2 < 128 or c2 > 191 then
			error("Invalid UTF-8 character")
		end

		-- validate byte 3
		if c3 < 128 or c3 > 191 then
			error("Invalid UTF-8 character")
		end

		-- validate byte 4
		if c4 < 128 or c4 > 191 then
			error("Invalid UTF-8 character")
		end

		return 4

	else
		error("Invalid UTF-8 character")
	end
end

-- returns the number of characters in a UTF-8 string
local function utf8len (s)
	-- argument checking
	if type(s) ~= "string" then
		for k,v in pairs(s) do print('"',tostring(k),'"',tostring(v),'"') end
		error("bad argument #1 to 'utf8len' (string expected, got ".. type(s).. ")")
	end

	local pos = 1
	local bytes = len(s)
	local length = 0

	while pos <= bytes do
		length = length + 1
		pos = pos + utf8charbytes(s, pos)
	end

	return length
end

-- functions identically to string.sub except that i and j are UTF-8 characters
-- instead of bytes
local function utf8sub (s, i, j)
	-- argument defaults
	j = j or -1

	local pos = 1
	local bytes = len(s)
	local length = 0

	-- only set l if i or j is negative
	local l = (i >= 0 and j >= 0) or utf8len(s)
	local startChar = (i >= 0) and i or l + i + 1
	local endChar   = (j >= 0) and j or l + j + 1

	-- can't have start before end!
	if startChar > endChar then
		return ""
	end

	-- byte offsets to pass to string.sub
	local startByte,endByte = 1,bytes

	while pos <= bytes do
		length = length + 1

		if length == startChar then
			startByte = pos
		end

		pos = pos + utf8charbytes(s, pos)

		if length == endChar then
			endByte = pos - 1
			break
		end
	end

	if startChar > length then startByte = bytes+1   end
	if endChar   < 1      then endByte   = 0         end

	return sub(s, startByte, endByte)
end

--[[
-- replace UTF-8 characters based on a mapping table
local function utf8replace (s, mapping)
	-- argument checking
	if type(s) ~= "string" then
		error("bad argument #1 to 'utf8replace' (string expected, got ".. type(s).. ")")
	end
	if type(mapping) ~= "table" then
		error("bad argument #2 to 'utf8replace' (table expected, got ".. type(mapping).. ")")
	end
	local pos = 1
	local bytes = len(s)
	local charbytes
	local newstr = ""
	while pos <= bytes do
		charbytes = utf8charbytes(s, pos)
		local c = sub(s, pos, pos + charbytes - 1)
		newstr = newstr .. (mapping[c] or c)
		pos = pos + charbytes
	end
	return newstr
end
-- identical to string.upper except it knows about unicode simple case conversions
local function utf8upper (s)
	return utf8replace(s, utf8_lc_uc)
end
-- identical to string.lower except it knows about unicode simple case conversions
local function utf8lower (s)
	return utf8replace(s, utf8_uc_lc)
end
]]

-- identical to string.reverse except that it supports UTF-8
local function utf8reverse (s)
	-- argument checking
	if type(s) ~= "string" then
		error("bad argument #1 to 'utf8reverse' (string expected, got ".. type(s).. ")")
	end

	local bytes = len(s)
	local pos = bytes
	local charbytes
	local newstr = ""

	while pos > 0 do
		local c = byte(s, pos)
		while c >= 128 and c <= 191 do
			pos = pos - 1
			c = byte(s, pos)
		end

		charbytes = utf8charbytes(s, pos)

		newstr = newstr .. sub(s, pos, pos + charbytes - 1)

		pos = pos - 1
	end

	return newstr
end

-- http://en.wikipedia.org/wiki/Utf8
-- http://developer.coronalabs.com/code/utf-8-conversion-utility
local function utf8char(unicode)
	if unicode <= 0x7F then return char(unicode) end

	if (unicode <= 0x7FF) then
		local Byte0 = 0xC0 + math.floor(unicode / 0x40);
		local Byte1 = 0x80 + (unicode % 0x40);
		return char(Byte0, Byte1);
	end;

	if (unicode <= 0xFFFF) then
		local Byte0 = 0xE0 +  math.floor(unicode / 0x1000);
		local Byte1 = 0x80 + (math.floor(unicode / 0x40) % 0x40);
		local Byte2 = 0x80 + (unicode % 0x40);
		return char(Byte0, Byte1, Byte2);
	end;

	if (unicode <= 0x10FFFF) then
		local code = unicode
		local Byte3= 0x80 + (code % 0x40);
		code       = math.floor(code / 0x40)
		local Byte2= 0x80 + (code % 0x40);
		code       = math.floor(code / 0x40)
		local Byte1= 0x80 + (code % 0x40);
		code       = math.floor(code / 0x40)
		local Byte0= 0xF0 + code;

		return char(Byte0, Byte1, Byte2, Byte3);
	end;

	error 'Unicode cannot be greater than U+10FFFF!'
end

local shift_6  = 2^6
local shift_12 = 2^12
local shift_18 = 2^18

local utf8unicode
utf8unicode = function(str, i, j, byte_pos)
	i = i or 1
	j = j or i

	if i > j then return end

	local ch,bytes

	if byte_pos then
		bytes = utf8charbytes(str,byte_pos)
		ch  = sub(str,byte_pos,byte_pos-1+bytes)
	else
		ch,byte_pos = utf8sub(str,i,i), 0
		bytes       = #ch
	end

	local unicode

	if bytes == 1 then unicode = byte(ch) end
	if bytes == 2 then
		local byte0,byte1 = byte(ch,1,2)
		local code0,code1 = byte0-0xC0,byte1-0x80
		unicode = code0*shift_6 + code1
	end
	if bytes == 3 then
		local byte0,byte1,byte2 = byte(ch,1,3)
		local code0,code1,code2 = byte0-0xE0,byte1-0x80,byte2-0x80
		unicode = code0*shift_12 + code1*shift_6 + code2
	end
	if bytes == 4 then
		local byte0,byte1,byte2,byte3 = byte(ch,1,4)
		local code0,code1,code2,code3 = byte0-0xF0,byte1-0x80,byte2-0x80,byte3-0x80
		unicode = code0*shift_18 + code1*shift_12 + code2*shift_6 + code3
	end

	return unicode,utf8unicode(str, i+1, j, byte_pos+bytes)
end

-- Returns an iterator which returns the next substring and its byte interval
local function utf8gensub(str, sub_len)
	sub_len        = sub_len or 1
	local byte_pos = 1
	local length   = #str
	return function(skip)
		if skip then byte_pos = byte_pos + skip end
		local char_count = 0
		local start      = byte_pos
		repeat
			if byte_pos > length then return end
			char_count  = char_count + 1
			local bytes = utf8charbytes(str,byte_pos)
			byte_pos    = byte_pos+bytes

		until char_count == sub_len

		local last  = byte_pos-1
		local slice = sub(str,start,last)
		return slice, start, last
	end
end

local function binsearch(sortedTable, item, comp)
	local head, tail = 1, #sortedTable
	local mid = math.floor((head + tail)/2)
	if not comp then
		while (tail - head) > 1 do
			if sortedTable[tonumber(mid)] > item then
				tail = mid
			else
				head = mid
			end
			mid = math.floor((head + tail)/2)
		end
	end
	if sortedTable[tonumber(head)] == item then
		return true, tonumber(head)
	elseif sortedTable[tonumber(tail)] == item then
		return true, tonumber(tail)
	else
		return false
	end
end
local function classMatchGenerator(class, plain)
	local codes = {}
	local ranges = {}
	local ignore = false
	local range = false
	local firstletter = true
	local unmatch = false

	local it = utf8gensub(class)

	local skip
	for c, _, be in it do
		skip = be
		if not ignore and not plain then
			if c == "%" then
				ignore = true
			elseif c == "-" then
				table.insert(codes, utf8unicode(c))
				range = true
			elseif c == "^" then
				if not firstletter then
					error('!!!')
				else
					unmatch = true
				end
			elseif c == ']' then
				break
			else
				if not range then
					table.insert(codes, utf8unicode(c))
				else
					table.remove(codes) -- removing '-'
					table.insert(ranges, {table.remove(codes), utf8unicode(c)})
					range = false
				end
			end
		elseif ignore and not plain then
			if c == 'a' then -- %a: represents all letters. (ONLY ASCII)
				table.insert(ranges, {65, 90}) -- A - Z
				table.insert(ranges, {97, 122}) -- a - z
			elseif c == 'c' then -- %c: represents all control characters.
				table.insert(ranges, {0, 31})
				table.insert(codes, 127)
			elseif c == 'd' then -- %d: represents all digits.
				table.insert(ranges, {48, 57}) -- 0 - 9
			elseif c == 'g' then -- %g: represents all printable characters except space.
				table.insert(ranges, {1, 8})
				table.insert(ranges, {14, 31})
				table.insert(ranges, {33, 132})
				table.insert(ranges, {134, 159})
				table.insert(ranges, {161, 5759})
				table.insert(ranges, {5761, 8191})
				table.insert(ranges, {8203, 8231})
				table.insert(ranges, {8234, 8238})
				table.insert(ranges, {8240, 8286})
				table.insert(ranges, {8288, 12287})
			elseif c == 'l' then -- %l: represents all lowercase letters. (ONLY ASCII)
				table.insert(ranges, {97, 122}) -- a - z
			elseif c == 'p' then -- %p: represents all punctuation characters. (ONLY ASCII)
				table.insert(ranges, {33, 47})
				table.insert(ranges, {58, 64})
				table.insert(ranges, {91, 96})
				table.insert(ranges, {123, 126})
			elseif c == 's' then -- %s: represents all space characters.
				table.insert(ranges, {9, 13})
				table.insert(codes, 32)
				table.insert(codes, 133)
				table.insert(codes, 160)
				table.insert(codes, 5760)
				table.insert(ranges, {8192, 8202})
				table.insert(codes, 8232)
				table.insert(codes, 8233)
				table.insert(codes, 8239)
				table.insert(codes, 8287)
				table.insert(codes, 12288)
			elseif c == 'u' then -- %u: represents all uppercase letters. (ONLY ASCII)
				table.insert(ranges, {65, 90}) -- A - Z
			elseif c == 'w' then -- %w: represents all alphanumeric characters. (ONLY ASCII)
				table.insert(ranges, {48, 57}) -- 0 - 9
				table.insert(ranges, {65, 90}) -- A - Z
				table.insert(ranges, {97, 122}) -- a - z
			elseif c == 'x' then -- %x: represents all hexadecimal digits.
				table.insert(ranges, {48, 57}) -- 0 - 9
				table.insert(ranges, {65, 70}) -- A - F
				table.insert(ranges, {97, 102}) -- a - f
			else
				if not range then
					table.insert(codes, utf8unicode(c))
				else
					table.remove(codes) -- removing '-'
					table.insert(ranges, {table.remove(codes), utf8unicode(c)})
					range = false
				end
			end
			ignore = false
		else
			if not range then
				table.insert(codes, utf8unicode(c))
			else
				table.remove(codes) -- removing '-'
				table.insert(ranges, {table.remove(codes), utf8unicode(c)})
				range = false
			end
			ignore = false
		end

		firstletter = false
	end

	table.sort(codes)

	local function inRanges(charCode)
		for _,r in ipairs(ranges) do
			if r[1] <= charCode and charCode <= r[2] then
				return true
			end
		end
		return false
	end
	if not unmatch then
		return function(charCode)
			return binsearch(codes, charCode) or inRanges(charCode)
		end, skip
	else
		return function(charCode)
			return charCode ~= -1 and not (binsearch(codes, charCode) or inRanges(charCode))
		end, skip
	end
end

--[[
-- utf8sub with extra argument, and extra result value
local function utf8subWithBytes (s, i, j, sb)
	-- argument defaults
	j = j or -1
	local pos = sb or 1
	local bytes = len(s)
	local length = 0
	-- only set l if i or j is negative
	local l = (i >= 0 and j >= 0) or utf8len(s)
	local startChar = (i >= 0) and i or l + i + 1
	local endChar   = (j >= 0) and j or l + j + 1
	-- can't have start before end!
	if startChar > endChar then
		return ""
	end
	-- byte offsets to pass to string.sub
	local startByte,endByte = 1,bytes
	while pos <= bytes do
		length = length + 1
		if length == startChar then
			startByte = pos
		end
		pos = pos + utf8charbytes(s, pos)
		if length == endChar then
			endByte = pos - 1
			break
		end
	end
	if startChar > length then startByte = bytes+1   end
	if endChar   < 1      then endByte   = 0         end
	return sub(s, startByte, endByte), endByte + 1
end
]]

local cache = setmetatable({},{
	__mode = 'kv'
})
local cachePlain = setmetatable({},{
	__mode = 'kv'
})
local function matcherGenerator(regex, plain)
	local matcher = {
		functions = {},
		captures = {}
	}
	if not plain then
		cache[regex] =  matcher
	else
		cachePlain[regex] = matcher
	end
	local function simple(func)
		return function(cC)
			if func(cC) then
				matcher:nextFunc()
				matcher:nextStr()
			else
				matcher:reset()
			end
		end
	end
	local function star(func)
		return function(cC)
			if func(cC) then
				matcher:fullResetOnNextFunc()
				matcher:nextStr()
			else
				matcher:nextFunc()
			end
		end
	end
	local function minus(func)
		return function(cC)
			if func(cC) then
				matcher:fullResetOnNextStr()
			end
			matcher:nextFunc()
		end
	end
	local function question(func)
		return function(cC)
			if func(cC) then
				matcher:fullResetOnNextFunc()
				matcher:nextStr()
			end
			matcher:nextFunc()
		end
	end

	local function capture(id)
		return function(_)
			local l = matcher.captures[id][2] - matcher.captures[id][1]
			local captured = utf8sub(matcher.string, matcher.captures[id][1], matcher.captures[id][2])
			local check = utf8sub(matcher.string, matcher.str, matcher.str + l)
			if captured == check then
				for _ = 0, l do
					matcher:nextStr()
				end
				matcher:nextFunc()
			else
				matcher:reset()
			end
		end
	end
	local function captureStart(id)
		return function(_)
			matcher.captures[id][1] = matcher.str
			matcher:nextFunc()
		end
	end
	local function captureStop(id)
		return function(_)
			matcher.captures[id][2] = matcher.str - 1
			matcher:nextFunc()
		end
	end

	local function balancer(str)
		local sum = 0
		local bc, ec = utf8sub(str, 1, 1), utf8sub(str, 2, 2)
		local skip = len(bc) + len(ec)
		bc, ec = utf8unicode(bc), utf8unicode(ec)
		return function(cC)
			if cC == ec and sum > 0 then
				sum = sum - 1
				if sum == 0 then
					matcher:nextFunc()
				end
				matcher:nextStr()
			elseif cC == bc then
				sum = sum + 1
				matcher:nextStr()
			else
				if sum == 0 or cC == -1 then
					sum = 0
					matcher:reset()
				else
					matcher:nextStr()
				end
			end
		end, skip
	end

	matcher.functions[1] = function(_)
		matcher:fullResetOnNextStr()
		matcher.seqStart = matcher.str
		matcher:nextFunc()
		if (matcher.str > matcher.startStr and matcher.fromStart) or matcher.str >= matcher.stringLen then
			matcher.stop = true
			matcher.seqStart = nil
		end
	end

	local lastFunc
	local ignore = false
	local skip = nil
	local it = (function()
		local gen = utf8gensub(regex)
		return function()
			return gen(skip)
		end
	end)()
	local cs = {}
	for c, bs, be in it do
		skip = nil
		if plain then
			table.insert(matcher.functions, simple(classMatchGenerator(c, plain)))
		else
			if ignore then
				if find('123456789', c, 1, true) then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
						lastFunc = nil
					end
					table.insert(matcher.functions, capture(tonumber(c)))
				elseif c == 'b' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
						lastFunc = nil
					end
					local b
					b, skip = balancer(sub(regex, be + 1, be + 9))
					table.insert(matcher.functions, b)
				else
					lastFunc = classMatchGenerator('%' .. c)
				end
				ignore = false
			else
				if c == '*' then
					if lastFunc then
						table.insert(matcher.functions, star(lastFunc))
						lastFunc = nil
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '+' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
						table.insert(matcher.functions, star(lastFunc))
						lastFunc = nil
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '-' then
					if lastFunc then
						table.insert(matcher.functions, minus(lastFunc))
						lastFunc = nil
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '?' then
					if lastFunc then
						table.insert(matcher.functions, question(lastFunc))
						lastFunc = nil
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '^' then
					if bs == 1 then
						matcher.fromStart = true
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '$' then
					if be == len(regex) then
						matcher.toEnd = true
					else
						error('invalid regex after ' .. sub(regex, 1, bs))
					end
				elseif c == '[' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
					end
					lastFunc, skip = classMatchGenerator(sub(regex, be + 1))
				elseif c == '(' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
						lastFunc = nil
					end
					table.insert(matcher.captures, {})
					table.insert(cs, #matcher.captures)
					table.insert(matcher.functions, captureStart(cs[#cs]))
					if sub(regex, be + 1, be + 1) == ')' then matcher.captures[#matcher.captures].empty = true end
				elseif c == ')' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
						lastFunc = nil
					end
					local cap = table.remove(cs)
					if not cap then
						error('invalid capture: "(" missing')
					end
					table.insert(matcher.functions, captureStop(cap))
				elseif c == '.' then
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
					end
					lastFunc = function(cC) return cC ~= -1 end
				elseif c == '%' then
					ignore = true
				else
					if lastFunc then
						table.insert(matcher.functions, simple(lastFunc))
					end
					lastFunc = classMatchGenerator(c)
				end
			end
		end
	end
	if #cs > 0 then
		error('invalid capture: ")" missing')
	end
	if lastFunc then
		table.insert(matcher.functions, simple(lastFunc))
	end

	table.insert(matcher.functions, function()
		if matcher.toEnd and matcher.str ~= matcher.stringLen then
			matcher:reset()
		else
			matcher.stop = true
		end
	end)

	matcher.nextFunc = function(self)
		self.func = self.func + 1
	end
	matcher.nextStr = function(self)
		self.str = self.str + 1
	end
	matcher.strReset = function(self)
		local oldReset = self.reset
		local str = self.str
		self.reset = function(s)
			s.str = str
			s.reset = oldReset
		end
	end
	matcher.fullResetOnNextFunc = function(self)
		local oldReset = self.reset
		local func = self.func +1
		local str = self.str
		self.reset = function(s)
			s.func = func
			s.str = str
			s.reset = oldReset
		end
	end
	matcher.fullResetOnNextStr = function(self)
		local oldReset = self.reset
		local str = self.str + 1
		local func = self.func
		self.reset = function(s)
			s.func = func
			s.str = str
			s.reset = oldReset
		end
	end

	matcher.process = function(self, str, start)

		self.func = 1
		start = start or 1
		self.startStr = (start >= 0) and start or utf8len(str) + start + 1
		self.seqStart = self.startStr
		self.str = self.startStr
		self.stringLen = utf8len(str) + 1
		self.string = str
		self.stop = false

		self.reset = function(s)
			s.func = 1
		end

		-- local lastPos = self.str
		-- local lastByte
		local ch
		while not self.stop do
			if self.str < self.stringLen then
				--[[ if lastPos < self.str then
					print('last byte', lastByte)
					ch, lastByte = utf8subWithBytes(str, 1, self.str - lastPos - 1, lastByte)
					ch, lastByte = utf8subWithBytes(str, 1, 1, lastByte)
					lastByte = lastByte - 1
				else
					ch, lastByte = utf8subWithBytes(str, self.str, self.str)
				end
				lastPos = self.str ]]
				ch = utf8sub(str, self.str,self.str)
				--print('char', ch, utf8unicode(ch))
				self.functions[self.func](utf8unicode(ch))
			else
				self.functions[self.func](-1)
			end
		end

		if self.seqStart then
			local captures = {}
			for _,pair in pairs(self.captures) do
				if pair.empty then
					table.insert(captures, pair[1])
				else
					table.insert(captures, utf8sub(str, pair[1], pair[2]))
				end
			end
			return self.seqStart, self.str - 1, unpack(captures)
		end
	end

	return matcher
end

-- string.find
local function utf8find(str, regex, init, plain)
	local matcher = cache[regex] or matcherGenerator(regex, plain)
	return matcher:process(str, init)
end

-- string.match
local function utf8match(str, regex, init)
	init = init or 1
	local found = {utf8find(str, regex, init)}
	if found[1] then
		if found[3] then
			return unpack(found, 3)
		end
		return utf8sub(str, found[1], found[2])
	end
end

-- string.gmatch
local function utf8gmatch(str, regex, all)
	regex = (utf8sub(regex,1,1) ~= '^') and regex or '%' .. regex
	local lastChar = 1
	return function()
		local found = {utf8find(str, regex, lastChar)}
		if found[1] then
			lastChar = found[2] + 1
			if found[all and 1 or 3] then
				return unpack(found, all and 1 or 3)
			end
			return utf8sub(str, found[1], found[2])
		end
	end
end

local function replace(repl, args)
	local ret = ''
	if type(repl) == 'string' then
		local ignore = false
		local num
		for c in utf8gensub(repl) do
			if not ignore then
				if c == '%' then
					ignore = true
				else
					ret = ret .. c
				end
			else
				num = tonumber(c)
				if num then
					ret = ret .. args[num]
				else
					ret = ret .. c
				end
				ignore = false
			end
		end
	elseif type(repl) == 'table' then
		ret = repl[args[1] or args[0]] or ''
	elseif type(repl) == 'function' then
		if #args > 0 then
			ret = repl(unpack(args, 1)) or ''
		else
			ret = repl(args[0]) or ''
		end
	end
	return ret
end
-- string.gsub
local function utf8gsub(str, regex, repl, limit)
	limit = limit or -1
	local ret = ''
	local prevEnd = 1
	local it = utf8gmatch(str, regex, true)
	local found = {it()}
	local n = 0
	while #found > 0 and limit ~= n do
		local args = {[0] = utf8sub(str, found[1], found[2]), unpack(found, 3)}
		ret = ret .. utf8sub(str, prevEnd, found[1] - 1)
		.. replace(repl, args)
		prevEnd = found[2] + 1
		n = n + 1
		found = {it()}
	end
	return ret .. utf8sub(str, prevEnd), n
end
string.utf8len = utf8len
string.utf8sub = utf8sub
string.utf8reverse = utf8reverse
string.utf8char = utf8char
string.utf8unicode = utf8unicode
string.utf8gensub = utf8gensub
string.utf8unicode = utf8unicode
string.utf8find    = utf8find
string.utf8match   = utf8match
string.utf8gmatch  = utf8gmatch
string.utf8gsub    = utf8gsub
string.utf8charbytes = utf8charbytes
string.utf8replace = utf8replace

local luarequire = require
local function ddrequire(modname)
    if string.ends(modname, '.lua') then
        print('require 以.lua结尾了， 建议修改', modname)
    end
    modname = string.gsub(modname, '%.lua$', '')
    return luarequire(modname)
end

_G.require = ddrequire
Events = require('Events')
CSEventManager = EventManager
EventManager = require('EventManager')

local UI
local Model

--所有全局调用的父
GlobalHooks = {
    InitModules = function()
        Model.InitModules()
    end,
    InitNetWork = function(initNotify)
        -- UI.InitNetWork()
        Model.InitNetWork(initNotify)
	end,
	BagInitOk = function()
		Model.BagInitOk()
	end,
    Init = function()
        print('GlobalHooks.init')
        Model.initial()
        UI.initial()
    end,
    OnEnterScene = function()
        print('GlobalHooks.OnEnterScene')
        Model.OnEnterScene()
        UI.OnEnterScene()
    end,
    Fin = function(relogin, reconnect)
        UI.OnExitScene(reconnect)
        Model.OnExitScene(reconnect)
        if relogin then
            UI.fin()
            Model.fin()
        end
    end,
    OnKeyDown = function(keyCode)
        --print('OnKeyDown', keyCode)
        if keyCode == 'F12' then
            GlobalHooks.Drama.HotReload()
        else
            GlobalHooks.Drama.OnKeyDown(keyCode)
        end
    end,
    UnsubscribeAll = EventManager.UnsubscribeAll
}

function main()
    UI = require 'UI/InitUI'
    Model = require 'Model/InitModel'
    require 'Protocol/NetClient'
    require 'Logic/Drama/DramaManger'
end

function PrintTable(root)
    if not root then
        return 'nil'
    end
    local cache = {[root] = '.'}
    local function _dump(t, space, name)
        local temp = {}
        for k, v in pairs(t) do
            local key = tostring(k)
            if cache[v] then
                table.insert(temp, '+' .. key .. ' {' .. cache[v] .. '}')
            elseif type(v) == 'table' then
                local new_key = name .. '.' .. key
                cache[v] = new_key
                table.insert(temp, '+' .. key .. _dump(v, space .. (next(t, k) and '|' or ' ') .. string.rep(' ', #key), new_key))
            else
                table.insert(temp, '+' .. key .. ' [' .. tostring(v) .. ']')
            end
        end
        return table.concat(temp, '\n' .. space)
    end
    return '\n' .. _dump(root, '', '')
end

local function get_print_string(deep, ...)
    local p = {...}
    local ret = ''
    for k, v in ipairs(p) do
        local t = type(v)
        if t == 'table' then
            ret = deep and ret .. PrintTable(v) or ret .. tostring(v)
        else
            ret = ret .. tostring(v) .. '\t'
        end
    end
    return ret
end

function print_r(...)
    if not TLUnityDebug.DEBUG_MODE then
        return
    end
    local ret = get_print_string(true, ...)
    print(ret)
end

pprint = print_r

function string.trim(str)
    return (string.gsub(str, '^%s*(.-)%s*$', '%1'))
end
function string.empty(str)
    return str == nil or str == ''
end

function string.IsNullOrEmpty(str)
    return not str or str == ''
end

function string.split(str, sep, canEmpty, itemFunc, isPattern)
    if canEmpty and string.empty(str) then
        return {}
    end
    local sep, fields = sep or ':', {}
    local pattern = isPattern and sep or string.format('([^%s]+)', sep)
    str:gsub(
        pattern,
        function(c)
            if itemFunc then
                c = itemFunc(c)
            end
            if c then
                table.insert(fields, c)
            end
        end
    )
    return fields
end

function table.removeItem(t, item)
    for i, v in ipairs(t) do
        if v == item then
            table.remove(t, i)
            return i, v
        end
    end
    return nil, nil
end

function table.appendList(t1, t2)
    for i, v in ipairs(t2) do
        table.insert(t1, v)
    end
end

function table.indexOf(t, value, fromIdx, toIdx)
    fromIdx = fromIdx or 1
    toIdx = toIdx or #t
    for i = fromIdx, toIdx do
        if t[i] == value then
            return i
        end
    end
    return nil
end

-- return index, value
function table.indexOfKey(t, key, value, fromIdx, toIdx)
    fromIdx = fromIdx or 1
    toIdx = toIdx or #t
    for i = fromIdx, toIdx do
        if t[i] and t[i][key] == value then
            return i, t[i]
        end
    end
    return nil, nil
end

function table.Values(t)
    if not t then
        return
    end
    local ret = {}
    for k, v in pairs(t) do
        table.insert(ret, v)
    end
    return ret
end

function table.Keys(t)
    if not t then
        return
    end
    local ret = {}
    for k, v in pairs(t) do
        table.insert(ret, k)
    end
    return ret
end

function CSharpArray2Table(arr)
    local ret = {}
    for i = 1, arr.Length do
        table.insert(ret, arr[i])
    end
    return ret
end

function CSharpList2Table(list)
    local ret = {}
    for i = 0, list.Count - 1 do
        local m = list:getItem(i)
        table.insert(ret, m)
    end
    return ret
end

function CSharpMap2Table(map)
    local ret = {}
    for t in Slua.iter(map) do
        ret[t.Key] = t.Value
    end
    return ret
end

------------------------Depend property-----------------------
local Dep = {}
Dep.__index = Dep
local dep_target_fn
local function PushTarget(fn)
    dep_target_fn = fn
end
local function PopTarget()
    dep_target_fn = nil
end
local function PeekTarget()
    return dep_target_fn
end

function Dep.depend(self)
    local dep_target = PeekTarget()
    if dep_target and not self._subscribers[dep_target] then
        self._subscribers[dep_target] = true
    end
end
function Dep.notify(self)
    for fn, v in pairs(self._subscribers) do
        fn()
    end
end
function Dep.Create()
    return setmetatable({_subscribers = {}}, Dep)
end

local function SetPropertyMeta(t, deep, getter, setter)
    local mt = getmetatable(t)
    local new_mt = {data = {}, _iswatchingtable = true}
    for k, v in pairs(t) do
        new_mt.data[k] = v
        if deep and type(v) == 'table' then
            SetPropertyMeta(v, deep, getter, setter)
        end
    end
    setmetatable(t, new_mt)
    for k, v in pairs(new_mt.data) do
        t[k] = nil
    end
    setmetatable(new_mt.data, mt)
    new_mt.__index = function(self, key)
        getter(self, key)
        return new_mt.data[key]
    end
    new_mt.__newindex = function(self, key, val)
        new_mt.data[key] = val
        if deep and type(val) == 'table' then
            SetPropertyMeta(val, deep, getter, setter)
        end
        setter(self, key, val)
    end
    new_mt.__pairs = function(self)
        return next, new_mt.data, nil
    end
    new_mt.__len = function(self)
        return #new_mt.data
    end
    return t
end

local function GetterDepend(self, key)
    if not PeekTarget() or key == '_dep_' then
        return false
    end
    local mt = getmetatable(self)
    mt._dep_ = mt._dep_ or {}
    mt._dep_[key] = mt._dep_[key] or Dep.Create()
    mt._dep_[key]:depend()
end

local function SetterNotify(self, key, val)
    local mt = getmetatable(self)
    mt._dep_ = mt._dep_ or {}
    local dep = mt._dep_[key]
    if dep then
        dep:notify()
    end
end

function Watch(val, fn, deep)
    local t = type(val)
    if t ~= 'table' then
        error('error val')
    end
    local mt = getmetatable(val)
    if not mt or not mt._iswatchingtable then
        if deep == nil then
            deep = true
        end
        SetPropertyMeta(val, deep, GetterDepend, SetterNotify)
    end
    PushTarget(fn)
    fn()
    PopTarget()
end

if not _ENV then
	-- lua version <= 5.1
    local inner_pairs = pairs
    local inner_ipairs = ipairs
    local function extra_pairs(t)
        local mt = getmetatable(t)
        if mt and rawget(mt,'_iswatchingtable') then
            return inner_pairs(mt.data)
        else
            return inner_pairs(t)
        end
    end

    local function extra_ipairs(t)
        local mt = getmetatable(t)
        if mt and rawget(mt,'_iswatchingtable') then
            return inner_ipairs(mt.data)
        else
            return inner_ipairs(t)
        end
    end
    pairs = extra_pairs
    ipairs = extra_ipairs
end

------------------------------------------------------------------------

function update(deltaTime)
end
