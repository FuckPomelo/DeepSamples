---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by xujing.xu.
--- DateTime: 2018/12/14 10:24
---成就弹窗

local _M = {}
_M.__index = _M

local AchievementModel=require('Model/AchievementModel')
local Util=require('Logic/Util')
local UIUtil = require 'UI/UIUtil'


function _M.OnInit(self)
    self.ui:EnableTouchFrameClose(false)
    self.ui.menu.ShowType = UIShowType.Cover
    self.ui.menu:SetCompAnime(self.ui.menu, UIAnimeType.FadeMoveUp)
end


local function DoFadeAction(node,duration,cb)
    local alphaAction = FadeAction()
    alphaAction.TargetAlpha = 0
    alphaAction.Duration = duration
    node:AddAction(alphaAction)
    alphaAction.ActionFinishCallBack = cb
end


function _M.OnEnter(self,params)
    if not params then
        self.ui:Close()
        return
    end
    SoundManager.Instance:PlaySoundByKey('chengjiutips',false)
    self.ach=AchievementModel.GetAchDataByAchId(params.id)
    self.comps.lb_name.Text=Util.GetText(self.ach.name)
    self.comps.lb_num.Text=self.ach.achievement_num
    local ib_level = self.comps.ib_level
    if tonumber(self.ach.achievement_num) < 10 then
        ib_level.Position2D = Vector2(ib_level.Position2D.x,4)
        UIUtil.SetImage(ib_level,AchievementModel.Hexagram.Low,false,UILayoutStyle.IMAGE_STYLE_BACK_4_CENTER)
    elseif tonumber(self.ach.achievement_num) >= 10 and tonumber(self.ach.achievement_num) <20 then
        ib_level.Position2D = Vector2(ib_level.Position2D.x,7)
        UIUtil.SetImage(ib_level,AchievementModel.Hexagram.Mid,false,UILayoutStyle.IMAGE_STYLE_BACK_4_CENTER)
    elseif tonumber(self.ach.achievement_num) >= 20 then
        ib_level.Position2D = Vector2(ib_level.Position2D.x,7)
        UIUtil.SetImage(ib_level,AchievementModel.Hexagram.High,false,UILayoutStyle.IMAGE_STYLE_BACK_4_CENTER)
    end
    self.ui.root.Alpha = 1
     self.Time=LuaTimer.Add(
            1000,
            function()
                DoFadeAction(self.ui.root,0.8,function ()
                    self.ui:Close()
                end)
            end)
end


function _M.OnExit(self)
    if self.Time then
        LuaTimer.Delete(self.Time)
        self.Time = nil
    end
    table.remove(AchievementModel.WaitShowAchievement,1)
    --如果列表里还有成就需要显示，则间隔0.5秒，以免UI的位置一直往前移动
    if next(AchievementModel.WaitShowAchievement) then
        self.waitTime=LuaTimer.Add(
            500,
            function()
                GlobalHooks.UI.OpenMsgBox('AchievementTip',0,AchievementModel.WaitShowAchievement[1])
            end)
    else
        if self.waitTime then
            LuaTimer.Delete(self.waitTime)
            self.waitTime = nil
        end
    end
end


return _M