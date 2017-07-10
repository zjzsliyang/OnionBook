# OnionBook

42028903 Summer2017 Database Systems(Course Design) by Shijin YUAN @ SSE, TJU

![](https://img.shields.io/badge/.NET-4.5.2-blue.svg) 

------

*TA: [Xiang ZHANG](mailto:546919127@qq.com) & [Zhenhao MEI](mailto:546919127@qq.com)*

## Contributors(provisional)

**Full Stack**: 1452669 [李阳](https://github.com/zjzsliyang)

| Front-end                                | Back-end                                 | Database                                 |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| 1552651 [王依睿](https://github.com/Charon0622) | 1552618 [姜逸之](https://github.com/Ginufet) | 1453645 [罗忠金](https://github.com/tjluozhongjin) |
| 1552745 [刘一宁](https://github.com/Eclear) | 1552701 [王晓文](https://github.com/WANGXiaowen0904) | 1451228 [杨国辉](https://github.com/Yghifi) |
| 1552726 [余行健](https://github.com/ThomasFisher196) | 1454091 [倪政](https://github.com/frank1129) | 1552649 [杜若衡](https://github.com/Wortspieldrh) |

## Prerequisites

- Windows 10
- Oracle Database 12c
- Visual Studio 2015(alt: 2013, 2017)

## Functionality

| 用户                 | 管理员            | 系统         |
| ------------------ | -------------- | ---------- |
| 用户注册               | 商品管理（添加、删除、修改） | 排行榜        |
| 用户登录               | 发布广告（添加、删除、查看） | 洋葱钱包       |
| 用户信息修改             | 折扣（添加、删除、修改）   | 洋葱积分       |
| 商品搜索（关键字、分类）       |                | 用户折扣（下单改价） |
| 商品查看（信息、评价、书评）     |                |            |
| 商品评价（评价、写书评）       |                |            |
| 购物车（添加、移除、修改数量、查看） |                |            |
| 收藏夹（添加、移除、查看）      |                |            |
| 未支付订单（创建、删除、查看状态）  |                |            |
| 已支付订单（查看状态、退货）     |                |            |
| 购买记录（查看历史订单）       |                |            |
| 洋葱钱包               |                |            |
| 洋葱积分               |                |            |
| 收货地址（添加、移除、查看）     |                |            |

## Database Design

### E-R Diagram

![ERDiagram](Res/Export/ERDiagram.png)

### Database Model

![DatabaseModel](Res/Export/DatabaseModel.png)



## Book type

- 文学
  - 小说
  - 随笔
  - 散文
  - 诗歌
  - 童话
  - 杂文
  - 儿童文学
  - 名著
- 流行
  - 漫画
  - 绘本
  - 言情
  - 推理
  - 青春
  - 悬疑
  - 科幻
  - 武侠
- 文化
  - 历史
  - 心理
  - 哲学
  - 社会学
  - 艺术
  - 政治
  - 建筑
  - 宗教
- 生活
  - 旅行
  - 摄影
  - 美食
  - 健康
  - 教育
  - 家居
  - 职场
  - 两性
- 经管
  - 经济学
  - 管理
  - 金融
  - 投资
  - 营销
  - 理财
  - 股票
  - 广告
- 科技
  - 科普
  - 科学
  - 互联网
  - 编程
  - 算法
  - 交互设计
  - 通信
  - 神经网络

## Front-end(provisional)

### Page URL

| Pages  | URL                                      | Front->End | End->Front                               |
| :----- | :--------------------------------------- | ---------- | ---------------------------------------- |
| 主页     | /onionbook                               |            | 1. 各一级分类最新出版的4本图书：名字、折前价格、折后价格、图片；2. 所有销量前10的图书：名字、折前价格、折后价格、图片（要知道分别排第几）；3. 所有评分前10的图书：名字、折前价格、折后价格、图片（要知道分别排第几）；4. 各一级分类销量前10的图书：名字、折前价格、折后价格（要知道分别排第几）；5. 各一级分类评分前10的图书：名字、折前价格、折后价格（要知道分别排第几）；6. 各二级分类评分前10的图书、名字、折前价格、折后价格（要知道分别排第几）；7.  图书销量（总和）最高的作者：名字、简介、图片、写所有的其他书。 |
| 登陆     | /onionbook/login/                        |            |                                          |
| 注册     | /onionbook/register/                     |            |                                          |
| 搜索结果页面 | /onionbook/search/?standard=bookname&keyword=书名/ |            |                                          |
|        | /onionbook/search/?standard=author&keyword=作者/ |            |                                          |
|        | /onionbook/search/?standard=publisher&keyword=出版社/ |            |                                          |
|        | /onionbook/search/?standard=isbn&keyword=ISBN号/ |            |                                          |
| 分类页面   | /onionbook/type/?typename=类别名/           |            |                                          |
| 商品详细信息 | /onionbook/bookdetail/?id=图书编号/          |            |                                          |
| 下订单    | /onionbook/order/orderdetail/?id=订单编号/   |            |                                          |
| 支付     | /onionbook/order/pay/?id=订单编号/           |            |                                          |
| 订单完成   | /onionbook/order/complete/               |            |                                          |
| 账户中心   | /onionbook/accountcenter/?id=客户编号/       |            |                                          |
| 购物车    | /onionbook/accountcenter/cart/?id=客户编号/  |            |                                          |
| 收藏     | /onionbook/accountcenter/star/?id=客户编号/  |            |                                          |
| 历史订单列表 | /onionbook/accoutcenter/orderlist/?id=客户编号/ |            |                                          |

## Back-end



