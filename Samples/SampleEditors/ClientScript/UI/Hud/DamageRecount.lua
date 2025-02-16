---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by xujing.xu.
--- DateTime: 2018/12/25 13:48
---伤害统计

local _M = {}
_M.__index = _M

local UIUtil = require 'UI/UIUtil'


function _M.OnInit(self)
    self.ui:EnableTouchFrameClose(false)
    self.ui.menu.ShowType = UIShowType.Cover
    HudManager.Instance:InitAnchorWithNode(self.comps.cvs_info, bit.bor(HudManager.HUD_TOP,HudManager.HUD_RIGHT))
end


local function ShowName(str)
    local chang= math.modf(tonumber(#str/3))
    if chang <= 4 then
        return str
    else
        return string.sub(str,1,9)..'...'
    end
end

--设置每个node初始化数据
local function SetEachPlayer(self,node,index)
    local lb_rank = node:FindChildByEditName('lb_rank',true)
    lb_rank.Text=index
    
    local lb_player = node:FindChildByEditName('lb_player',true)
    if self.damageRecount[index] then
        lb_player.Text = self.damageRecount[index].name
    end
    
    local gg_num=node:FindChildByEditName('gg_num',true)
    if self.damageRecount[index] then
        gg_num.Value = index == 1 and 100 or (self.damageRecount[index].dps/self.damageRecount[1].dps)*100
        local per = '('..string.format("%.1f",tostring((self.damageRecount[index].dps/self.Total)*100))..'%'..')'
        gg_num.Text = self.damageRecount[index].dps < 10000 and self.damageRecount[index].dps..per or string.format("%.1f", self.damageRecount[index].dps/1000)..'k'..per
    end
end


--初始化列表
local function InitDpsInfo(self)
    local function eachupdatecb(node,index)
        SetEachPlayer(self,node,index)
    end
    UIUtil.ConfigVScrollPan(self.comps.sp_player,self.comps.cvs_player,#self.damageRecount,eachupdatecb)
end

--计算伤害，更新数据
local function CalcDpsRecount(self)
    self.temp={}
    self.damageTime=LuaTimer.Add(0,1000, function()
        
        local temp = TLBattleScene.Instance:GetScenePlayerDamageMap()
        temp = CSharpMap2Table(temp)
                
        self.Total = 0
        self.damageRecount = nil
        self.damageRecount={}
        for k, v in pairs(temp) do
            local player = GameSceneMgr.Instance.BattleScene:GetBattleObject(k)
            if player then
                self.temp[k] = self.temp[k] or {}
                self.temp[k].dps = v
                if self.temp[k].name == nil then
                    self.temp[k].name = ShowName(player:Name())
                end
            end
            self.Total = self.Total + v
        end
        
        for k, v in pairs(self.temp) do
            table.insert(self.damageRecount,v)
        end
        table.sort(self.damageRecount,function (a,b)
            return a.dps > b.dps
        end)

        if #self.damageRecount > 0 and not self.comps.cvs_info.Visible then
            self.comps.cvs_info.Visible=true
        end
        
        if #self.damageRecount > 0 and #self.damageRecount > self.comps.sp_player.Scrollable.Container.NumChildren then
            InitDpsInfo(self)
        else
            self.comps.sp_player:RefreshShowCell()
        end
        
        return true
    end)
end


function _M.OnEnter(self)
    self.comps.cvs_player.Visible=false
    UIUtil.ConfigVScrollPan(self.comps.sp_player,self.comps.cvs_player,0,nil)
    CalcDpsRecount(self)
    self.comps.cvs_info.Visible=false
end


function _M.OnExit(self)
    if self.damageTime then
        LuaTimer.Delete(self.damageTime)
        self.damageTime =nil
    end
end


return _M