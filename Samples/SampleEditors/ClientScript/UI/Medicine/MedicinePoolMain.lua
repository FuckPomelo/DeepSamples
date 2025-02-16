---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by xujing.xu.
--- DateTime: 2018/10/24 16:27
---血池    MedicinePool
local _M = {}
_M.__index = _M

local MedicineModel = require 'Model/MedicineModel'
local Util = require 'Logic/Util'


local function ValueAction(self)
    self.UpTime = LuaTimer.Add(0,10,function()
        self.effobj.value=self.effobj.value+0.05
        if self.effobj.value >= 1 then
            self.effobj.value=1
            return false
        end
        return true
    end)
end


local function InitBtn(self,node)
    
    local lb_costnum=node:FindChildByEditName('lb_costnum',true)
    lb_costnum.Text=math.abs((self.pooldata.limit-self.now)*self.pooldata.cost_num)
    
    --点击确定保存设置并关闭界面
    local btn_ok =node:FindChildByEditName('btn_ok',true)
    btn_ok.TouchClick=function(sender)
        MedicineModel.SaveOptions(self.ui.comps.tbt_autoheal.IsChecked,
            self.ui.comps.tbt_autoput.IsChecked, 
            self.setting.UseThreshold,
            function(rsp)
                self.ui:Close()
            end)
    end
    
    --一键填充
    local btn_one=node:FindChildByEditName('btn_one',true)
    btn_one.IsGray=self.now >= self.pooldata.limit
    btn_one.IsInteractive=not btn_one.IsGray
    
    btn_one.TouchClick=function(sender)
        if DataMgr.Instance.UserData:GetAttribute(UserData.NotiFyStatus.COPPER) < math.abs((self.pooldata.limit-self.now)*self.pooldata.cost_num) then
            GameAlertManager.Instance:ShowNotify(Util.GetText(Constants.Text.NoEnoughCopper))
        else
            MedicineModel.Recharging=true
            MedicineModel.DoRechargeMedicinePool(function (rsp)
                if rsp:IsSuccess() then
                    ValueAction(self)
                    --回调赋值
                    self.now=rsp.s2c_count
                    MedicineModel.Recharging=false
                    DataMgr.Instance.UserData.MedicinePoolCurCount=rsp.s2c_count
                    --控件重新赋值
                    self.ui.comps.lb_count.Text=tostring(self.now)..'/'..self.pooldata.limit
                    lb_costnum.Text=0
                    --填充按钮置灰
                    btn_one.IsGray=true
                    btn_one.IsInteractive=false
                end
            end)
        end
    end
end


--释放特效
local function Release3DModel(self)
    if self.model then
        RenderSystem.Instance:Unload(self.model)
        self.model = nil
    end
end


--播放血池特效
local function Play3DEffect(self, parentCvs, menuOrder, fileName)
    local transSet = TransformSet()
    transSet.Pos = Vector3(0,0,200)
    transSet.Scale = Vector3(1, 1, 1)
    transSet.Parent = parentCvs.Transform
    transSet.Layer = Constants.Layer.UI
    transSet.LayerOrder = menuOrder
    self.model = RenderSystem.Instance:LoadGameObject(fileName,transSet,function (aoe)
        self.effobj=aoe.gameObject:GetComponent("Slider")
        self.effobj.value=tonumber(self.now/self.pooldata.limit)
    end)
end


local function InitShowCount(self,node)
    
    local lb_count=node:FindChildByEditName('lb_count',true)
    lb_count.Text=tostring(self.now)..'/'..self.pooldata.limit
    
    --加载3D血池特效
    local cvs_anchor=node:FindChildByEditName('cvs_anchor',true)
    Play3DEffect(self,cvs_anchor,
            self.ui.menu.MenuOrder,
            '/res/effect/ui/ef_ui_bloodpool.assetbundles')
end


local function InitCvsInfo(self,node)
    --恢复量
    local lb_huinum=node:FindChildByEditName('lb_huinum',true)
    local PracticeLv = DataMgr.Instance.UserData:TryGetIntAttribute(UserData.NotiFyStatus.PRACTICELV, 0)
    local addition = MedicineModel.GetAdditionByPracticeLv(PracticeLv)
    lb_huinum.Text=  math.floor(self.pooldata.heal*(1+addition/10000))

    --血线设置
    local lb_num=node:FindChildByEditName('lb_num',true)
    lb_num.Text=self.setting.UseThreshold
    local btn_less=node:FindChildByEditName('btn_less',true)
    btn_less.event_PointerMove=function(sender)
        self.setting.UseThreshold=(self.setting.UseThreshold-1 <=0 and {0} or {self.setting.UseThreshold-1})[1]
        lb_num.Text=self.setting.UseThreshold
    end
    local btn_more=node:FindChildByEditName('btn_more',true)
    btn_more.event_PointerMove=function(sender)
        self.setting.UseThreshold=(self.setting.UseThreshold+1 >=100 and {100} or {self.setting.UseThreshold+1})[1]
        lb_num.Text=self.setting.UseThreshold
    end
    local cvs_set=node:FindChildByEditName('cvs_set',true)
    cvs_set.TouchClick=function(sender)
        local pos = self.ui.menu:LocalToScreenGlobal(cvs_set)
        local posParam = { pos = { x = pos.x-205 ,y=pos.y +170}, anchor = { x = 0, y = 0.5 } }
        GlobalHooks.UI.OpenUI('NumInput', 0, 0, 100, posParam, function(value)
            self.setting.UseThreshold = value
            lb_num.Text=self.setting.UseThreshold
        end)
    end

    --自动使用血池/自动填充血池
    self.ui.comps.tbt_autoheal.IsChecked=self.setting.AutoUseItem
    self.ui.comps.tbt_autoput.IsChecked=self.setting.AutoRecharge
    
    self.ui.comps.tbt_autoput.TouchClick=function(sender)
        if sender.IsChecked then --off=>on
            if DataMgr.Instance.UserData:GetAttribute(UserData.NotiFyStatus.COPPER) >= (self.pooldata.limit*self.pooldata.cost_num) then
                GameAlertManager.Instance:ShowNotify(Util.GetText('medicine_pool_reopen'))
                sender.IsChecked=true
            else
                GameAlertManager.Instance:ShowAlertDialog(AlertDialog.PRIORITY_NORMAL,Util.GetText('NoEnoughCopperToReopenMedicinePool'),'','',nil,
                    function() 
                        sender.IsChecked=true
                        GameAlertManager.Instance:ShowNotify(Util.GetText('medicine_pool_reopen'))
                    end,
                    function () sender.IsChecked=false end)
            end
        else --on=>off
            sender.IsChecked=false
        end
    end
end


function _M.OnInit(self)
    self.ui.menu.ShowType = UIShowType.Cover
    self.ui.menu:SetCompAnime(self.ui.menu, UIAnimeType.FadeMoveDown)
end


function _M.OnEnter( self )
    self.pooldata=MedicineModel.GetOneDataByPlayerLv(DataMgr.Instance.UserData.Level)
    self.now=DataMgr.Instance.UserData.MedicinePoolCurCount --剩余次数
    self.setting = DataMgr.Instance.UserData.GameOptionsData
    InitBtn(self,self.ui.comps.cvs_btn)
    InitShowCount(self,self.ui.comps.cvs_show)
    InitCvsInfo(self,self.ui.comps.cvs_info)
    
    --点击其他地方关闭并保存设置
    --应小石要求，取消该段逻辑
--[[    self.ui.menu.event_PointerUp = function( ... )
        MedicineModel.SaveOptions(self.ui.comps.tbt_autoheal.IsChecked,
            self.ui.comps.tbt_autoput.IsChecked,
            self.setting.UseThreshold,
            function(rsp)
                self.ui:Close()
            end)
        self.ui:Close()
    end]]
end


function _M.OnExit(self)
    Release3DModel(self)
    if self.UpTime then
        LuaTimer.Delete(self.UpTime)
        self.UpTime=nil
    end
end


return _M