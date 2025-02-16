---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by xujing.xu.
--- DateTime: 2019/1/16 13:28
---春节商店

local _M = {}
_M.__index = _M

local Util = require 'Logic/Util'
local UIUtil = require 'UI/UIUtil'
local ItemModel = require 'Model/ItemModel'
local ShopModel = require 'Model/ShopModel'


function _M.OnInit(self)
    self.shopData = unpack(GlobalHooks.DB.Find('Store_Type',{store_id = 6}))
    --覆盖/无动画/黑底
    self.ui.menu.ShowType = UIShowType.Cover
    self.ui.menu:SetCompAnime(self.ui.menu, UIAnimeType.NoAnime)
    self.ui.menu:SetFullBackground(UILayout.CreateUILayoutColor(UnityEngine.Color(0,0,0,0.5),UnityEngine.Color(0,0,0,0.5)))
end


local function SetEachItemInfo(self,node)
    
    local item = ItemModel.GetDetailByTemplateID(self.store[node.UserTag].item_id)
    
    --物品图片&名字
    local cvs_itemicon =node:FindChildByEditName('cvs_itemicon',true)
    local lb_itemname=node:FindChildByEditName('lb_itemname',true)
    lb_itemname.Text=Util.GetText(item.static.name)
    local itshow=UIUtil.SetItemShowTo(cvs_itemicon,item.static.atlas_id,item.static.quality,1)
    itshow.EnableTouch = true
    itshow.TouchClick = function()
        UIUtil.ShowNormalItemDetail({x= node.UserTag%4 ~= 0 and node.X+250 or node.X-170,y=node.Y+120,detail = item,itemShow = itshow,autoHeight = true,autoWeight=true})
    end
    
    --价格&icon
    local lb_fubinum =node:FindChildByEditName('lb_fubinum',true)
    lb_fubinum.Text = self.store[node.UserTag].cost_num
    local ib_fubibg = node:FindChildByEditName('ib_fubibg',true)
    local cost = ItemModel.GetDetailByTemplateID(Constants.VirtualItems.GoodFortune)
    MenuBase.SetImageBox(ib_fubibg,'static/item/'..cost.static.atlas_id,UILayoutStyle.IMAGE_STYLE_BACK_4_CENTER,8)
    
    --购买
    local btn_buy =node:FindChildByEditName('btn_buy',true)
    btn_buy.TouchClick =function ()
        if self.fortuneCount >= self.store[node.UserTag].cost_num then
            ShopModel.RequestBuyItem(self.shopData.store_type,self.store[node.UserTag].item_id,1,function(rsp)
                --刷新剩余的福气币
                self.fortuneCount = self.fortuneCount - self.store[node.UserTag].cost_num
                self.comps.lb_act.Text = self.fortuneCount
                GameAlertManager.Instance:ShowNotify(Constants.Text.shop_buysucc)
                EventManager.Fire('Event.SpringFestival.BuyItem',{})
            end)
        else
            GameAlertManager.Instance:ShowNotify(Constants.SpringFestival.NotEnoughCoin)
        end
    end
end


local function InitMainScrollPan(self,node,index)
    for i = 1, node.NumChildren do
        local cvs = node:FindChildByEditName('cvs_'..i,true)
        cvs.UserTag = index*node.NumChildren + i
        cvs.Visible = cvs.UserTag <= #self.store
        if cvs.Visible then
            SetEachItemInfo(self,cvs)
        end
    end
end
local function MoveEndFun(self,index)
    self.comps.bt_up.Visible = index > 0
    self.comps.bt_down.Visible = index < self.pageCount-1
end

local function InitStoreInfo(self)
    self.comps.cvs_itemInfo.Visible =false
    self.pageCount = #self.store % self.comps.cvs_itemInfo.NumChildren == 0
            and #self.store/self.comps.cvs_itemInfo.NumChildren 
            or math.floor(#self.store/self.comps.cvs_itemInfo.NumChildren) +1
    local function eachCreateCb(node, index)
        InitMainScrollPan(self,node,index)
    end
    local function eachUpdateCB(index)
        MoveEndFun(self,index)
    end
    UIUtil.ConfigPageScrollPan(self.comps.sp_itemlist, self.comps.cvs_itemInfo, self.pageCount,true, eachCreateCb, eachUpdateCB)
    --按钮翻页
    self.comps.bt_up.TouchClick=function()
        self.comps.sp_itemlist:ShowPrevPage()
    end
    self.comps.bt_down.TouchClick=function()
        self.comps.sp_itemlist:ShowNextPage()
    end
end

local function InitTopInfo(self)
    self.fortuneCount = ItemModel.CountItemByTemplateID(Constants.VirtualItems.GoodFortune)
    self.comps.lb_act.Text = self.fortuneCount
end


function _M.OnEnter(self)
    InitTopInfo(self)
    ShopModel.RequestGetStoreBoughtInfo(self.shopData.store_type,function (rsp)
        self.store=ShopModel.GetStoreData(self.shopData.store_type,rsp.s2c_data)
        InitStoreInfo(self)
    end)
end

function _M.OnExit(self)
    
end


return _M