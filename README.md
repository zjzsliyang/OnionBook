# OnionBook

42024402 Spring2017 Database Systems(Course Design) by Shijin YUAN @ SSE, TJU

------

*Summer 2017, Prof. YUAN, TA: [Xiang ZHANG](mailto:546919127@qq.com) & [Zhenhao MEI](mailto:546919127@qq.com)*

## Contributors(provisional)

- Full Stack
  - 1452669 [李阳](https://github.com/zjzsliyang)


- Front-end
  - 1552651 [王依睿](https://github.com/Charon0622)
  - 1552745 刘一宁
  - 1552726 余行健
- Back-end
  - 1552618 [姜逸之](https://github.com/Ginufet)
  - 1552701 [王晓文](https://github.com/WANGXiaowen0904)
  - 1454091 [倪政](https://github.com/frank1129)
- Database
  - 1453645 [罗忠金](https://github.com/tjluozhongjin)
  - 1451228 [杨国辉](https://github.com/Yghifi)
  - 1552649 杜若衡

## Prerequisites

- Windows 10(or VM with Win10)
- Oracle Database 12c
- Visual Studio 2015(or 2013/2017)

## Functionality

### 用户

- 用户注册
- 用户登陆
- 用户信息修改
- 商品搜索
  - 关键字搜索
  - 分类搜索
- 商品查看
  - 查看商品信息
  - 查看商品评价
  - 查看书评
- 商品评价
  - 评价商品
  - 写书评
- 购物车
  - 添加商品
  - 移除商品
  - 修改数量
  - 查看购物车
- 收藏夹
  - 添加商品
  - 移除商品
  - 查看收藏夹
- 订单(未支付)
  - 创建订单
  - 删除订单(不买了)
  - 查看订单状态(支付状态)
- 订单(已支付)
  - 查看订单状态(发货状态、签收状态)
  - 退货
- 购买记录
  - 查看历史订单列表
- 洋葱钱包(平台自身支付功能，与用户绑定)
  - 支付后减少账户余额
  - 银行卡转入增加账户余额
  - 退货后增加账户余额
- 洋葱积分
  - 用积分兑换商品
- 收货地址
  - 添加收货地址
  - 移除收货地址
  - 查看收货地址

### 管理员

- 商品管理
  - 增加商品
  - 删除商品
  - 修改商品信息
- 发布广告
  - 增加广告
  - 删除广告
  - 查看广告列表
- 折扣
  - 增加折扣
  - 删除折扣
  - 修改折扣

### 系统

- 排行榜
  - 修改排行榜
- 洋葱钱包
  - 用户支付后扣除用户账户余额
- 系统账户
  - 用户支付后增加系统账户金额
  - 用户退款后减少系统账户金额
- 洋葱积分
  - 用户支付后增加用户积分
  - 用户退单后扣除用户积分
- 活动折扣
  - 用户下单后修改价格

## Database Design

### E-R Diagram

![ERDiagram](Res/Export/ERDiagram.png)

### Database Model

![DatabaseModel](Res/Export/DatabaseModel.png)