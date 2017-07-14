# OnionBook

42028903 Summer2017 Database Systems(Course Design) by Shijin YUAN @ SSE, TJU

![](https://img.shields.io/badge/.NET-4.5.2-blue.svg) ![test](https://img.shields.io/badge/build-passing-brightgreen.svg)

------

*TA: [Xiang ZHANG](mailto:546919127@qq.com) & [Zhenhao MEI](mailto:546919127@qq.com)*

## Contributors

| Front-end                                | Back-end                                 | Database                                 |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| 1452669 [李阳](https://github.com/zjzsliyang) | 1552618 [姜逸之](https://github.com/Ginufet) | 1453645 [罗忠金](https://github.com/tjluozhongjin) |
| 1552651 [王依睿](https://github.com/Charon0622) | 1552701 [王晓文](https://github.com/WANGXiaowen0904) | 1451228 [杨国辉](https://github.com/Yghifi) |
|                                          | 1454091 [倪政](https://github.com/frank1129) | 1552649 [杜若衡](https://github.com/Wortspieldrh) |
|                                          | 1552726 [余行健](https://github.com/ThomasFisher196) |                                          |
|                                          | 1552745 [刘一宁](https://github.com/Eclear) |                                          |

## Prerequisites

- Windows 10
- Oracle Database 12c
- Visual Studio 2015(alt: 2013, 2017)

## How to Run

1. Clone the Repository
2. Change Directory(cd) to ``OnionBookOnline`` folder
3. Open ``OnionBookOnline.sln`` with Visual Studio(test passing on 2015 & 2017 version)
4. Restore the package with NuGet
5. Run with Google Chrome(recommended)

## Functionality

| 用户                 | 管理员            | 系统         |
| ------------------ | -------------- | ---------- |
| 用户注册               | 商品管理（添加、删除、修改） | 排行榜        |
| 用户登录               | 发布广告（添加、删除、查看） | 用户折扣（下单改价） |
| 用户信息修改             | 折扣（添加、删除、修改）   |            |
| 商品搜索（关键字、分类）       |                |            |
| 商品查看（信息、评价、书评）     |                |            |
| 商品评价（评价、写书评）       |                |            |
| 购物车（添加、移除、修改数量、查看） |                |            |
| 收藏夹（添加、移除、查看）      |                |            |
| 未支付订单（创建、删除、查看状态）  |                |            |
| 已支付订单（查看状态、退货）     |                |            |
| 购买记录（查看历史订单）       |                |            |
| 收货地址（添加、移除、查看）     |                |            |

## Database Design

### E-R Diagram

![ERDiagram](Res/Export/ERDiagram(c).png)

### Database Model

![DatabaseModel](Res/Export/DatabaseModel(c).png)

### Book Type

| 文学   | 流行   | 文化   | 生活   | 经管   | 科技   |
| ---- | ---- | ---- | ---- | ---- | ---- |
| 小说   | 漫画   | 历史   | 旅行   | 经济   | 科普   |
| 随笔   | 绘本   | 心理   | 摄影   | 管理   | 科学   |
| 散文   | 言情   | 社会   | 美食   | 金融   | 交互   |
| 诗歌   | 推理   | 哲学   | 健康   | 投资   | 编程   |
| 童话   | 科幻   | 艺术   | 教育   | 营销   | 算法   |
| 杂文   | 武侠   | 政治   | 家居   | 理财   | 通信   |
| 儿童   | 青春   | 建筑   | 职场   | 股票   | 程序   |
| 名著   | 悬疑   | 宗教   | 两性   | 广告   | 互联网  |

## Data Access

> 数据来源：豆瓣图书

### Spider Code

```python
# -*- coding: utf-8 -*-
import sys
import re
import detailInfo
import time
import urllib
import urllib2
import requests
import numpy as np
from bs4 import BeautifulSoup
from openpyxl import Workbook
reload(sys)
sys.setdefaultencoding('utf8')
sqls = []
# Some User Agents
hds = [{'User-Agent': 'Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6'}, \
       {
           'User-Agent': 'Mozilla/5.0 (Windows NT 6.2) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.12 Safari/535.11'}, \
       {'User-Agent': 'Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)'}]


def book_spider(book_tag,i,j):
    page_num = 0;
    book_list = []
    try_times = 0
    id = 1
    while (1):
        url = 'http://www.douban.com/tag/' + urllib.quote(book_tag) + '/book?start=' + str(8 * 15)
        time.sleep(np.random.rand() * 5)
        # Last Version
        try:
            #req = urllib2.Request(url, headers=hds[page_num % len(hds)])
            #source_code = urllib2.urlopen(req).read()

            req = requests.get(url=url)

            source_code = req.text
            plain_text = str(source_code)
        except (urllib2.HTTPError, urllib2.URLError), e:
            print e
            continue

        ##Previous Version, IP is easy to be Forbidden
        # source_code = requests.get(url)
        # plain_text = source_code.text

        soup = BeautifulSoup(plain_text,'lxml')
        list_soup = soup.find('div', {'class': 'mod book-list'})


        try_times += 1;
        if list_soup == None and try_times < 200:
            continue
        elif list_soup == None or len(list_soup) <= 1:
            break  # Break when no informatoin got after 200 times requesting

        books = list_soup.findAll('dd')
        length = len(books)
        current = 0;
        while current<length:
            book_info = books[current]
            book_url = book_info.find('a', {'class': 'title'}).get('href')
            book_id = re.findall(r'https://book.douban.com/subject/(.*)/\?from=tag_all', book_url)
            try:
                sqls.append(detailInfo.getInfomation(book_id[0], i, j))
                current = current + 1
            except:
                print "change ip"
                newip = requests.get(url='http://vtp.daxiangdaili.com/ip/?tid=555300480278823&num=1&delay=5&filter=on').text
                f = open('ip.txt', 'w')
                f.write(newip)
                f.close()
                continue
            time.sleep(1)
        page_num += 1
        print 'Downloading Information From Page %d' % page_num
        break
    return book_list

def get_people_num(url):
    # url='http://book.douban.com/subject/6082808/?from=tag_all' # For Test
    try:
        req = urllib2.Request(url, headers=hds[np.random.randint(0, len(hds))])
        source_code = urllib2.urlopen(req).read()
        plain_text = str(source_code)
    except (urllib2.HTTPError, urllib2.URLError), e:
        print e
    soup = BeautifulSoup(plain_text)
    people_num = soup.find('div', {'class': 'rating_sum'}).findAll('span')[1].string.strip()
    return people_num

def do_spider(book_tag_lists,i,j):
    book_lists = []
    for book_tag in book_tag_lists:
        book_list = book_spider(book_tag,i,j)
        book_list = sorted(book_list, key=lambda x: x[1], reverse=True)
        book_lists.append(book_list)
    return book_lists

def print_book_lists_excel(book_lists, book_tag_lists):
    wb = Workbook(optimized_write=True)
    ws = []
    for i in range(len(book_tag_lists)):
        ws.append(wb.create_sheet(title=book_tag_lists[i].decode()))  # utf8->unicode
    for i in range(len(book_tag_lists)):
        ws[i].append(['序号', '书名', '评分', '评价人数', '作者', '出版社'])
        count = 1
        for bl in book_lists[i]:
            ws[i].append([count, bl[0], float(bl[1]), int(bl[2]), bl[3], bl[4]])
            count += 1
    save_path = 'book_list'
    for i in range(len(book_tag_lists)):
        save_path += ('-' + book_tag_lists[i].decode())
    save_path += '.xlsx'
    wb.save(save_path)

if __name__ == '__main__':
    book_tags = [
        ['小说','随笔','散文','诗歌','童话','杂文','儿童','名著'],
        ['漫画','绘本','言情','推理','科幻','武侠','青春','悬疑'],
        ['历史','心理','社会','哲学','艺术','政治','建筑','宗教'],
        ['旅行','摄影','美食','健康','教育','家居','职场','两性'],
        ['经济','管理','金融','投资','营销','理财','股票','广告'],
        ['科普','科学','交互','编程','算法','通信','程序','互联网']
    ]
    i = 0
    j = 0
    k = 0

    while i < 6:
        while j < 8:
            try:
                print book_tags[i][j]+'------------------------------------------------'
                book_tag_lists = [book_tags[i][j]]
                book_lists = do_spider(book_tag_lists,i+1,j+1)
                f = open(book_tags[i][j]+'.txt', 'w')
                for sql in sqls:
                    f.write(sql)
                f.close()
                sqls=[]
                j = j + 1;
                k = k + 1
                if k >= 48:
                    break
            except:
                # print "error"
                # newip = requests.get(url='http://vtp.daxiangdaili.com/ip/?tid=555300480278823&num=1').text
                # f = open('ip.txt', 'w')
                # f.write(newip)
                # f.close()
                # sqls = []
                continue;
        j = 0;
        i = i+1;
```

### Insert Function

|     过程     |                 作用                 |
| :--------: | :--------------------------------: |
| InsertBook | 保证BOOK表、AUTHOR表、PICTURE、WRITE表同时插入 |

```sql
CREATE PROCEDURE INSERTBOOK (
    pisbn in VARCHAR2,
    pname in VARCHAR2,
    pprimaryid in VARCHAR2,
    psecondaryid in VARCHAR2,
    ppublisher in VARCHAR2,
    pprice in NUMBER,
    ppages in NUMBER,
    pdiscount in NUMBER,
    pstock in NUMBER,
    pscore in NUMBER,
    ppublishingdate in VARCHAR2,
    psale in NUMBER,
    pintroduction in CLOB,
    pauthorname in VARCHAR2,
    ppath in VARCHAR2
    ) 
AS 
countN1 int;
countN2 int;
newauthorid VARCHAR2(20);
newbookid VARCHAR2(20);
BEGIN
  select count(*) into countN1 from book where isbn = pisbn;
  if countN1 = 0 then
    INSERT INTO BOOK(isbn,name,primaryid,secondaryid,publisher,price,pages,discount,stock,score,publishingdate,sale,introduction)  VALUES(pisbn,pname,pprimaryid,psecondaryid,ppublisher,pprice,ppages,pdiscount,pstock,pscore,ppublishingdate,psale,pintroduction);
    select bookid into newbookid from book where isbn = pisbn;
    insert into picture values(newbookid,'00',ppath);
    
    select count(*) into countN2 from author where name = pauthorname;
    if countN2 = 0 then
      insert into AUTHOR(NAME) values(pauthorname);
    end if;
    select AUTHORID into newauthorid from AUTHOR WHERE NAME = pauthorname;
    insert into WRITE values(newauthorid,newbookid);
  end if;
END INSERTBOOK;
```

### Trigger

|      触发器       |  触发条件  |   操作    |
| :------------: | :----: | :-----: |
| BalanceTrigger |  更新余额  |  更新积分   |
|  StockTrigger  |  创建订单  |  更新库存   |
| DStockTrigger  |  删除订单  |  更新库存   |
|  ScoreTrigger  | 插入用户评分 | 更新图书总评分 |
| DScoreTrigger  | 删除用户评分 | 更新图书总评分 |

#### BalanceTrigger

```sql
CREATE TRIGGER BALANCETRIGGER BEFORE UPDATE OF "Balance" ON "AspNetUsers" 
    for each row
        begin
           if :old."Balance" > :new."Balance" then
                :new."Credits" := :new."Credits" + :old."Balance" - :new."Balance";
           end if;
        end;
```

#### StockTrigger

```sql
CREATE TRIGGER DSTOCKTRIGGER AFTER DELETE ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK + :old.AMOUNT) WHERE BOOK.BOOKID = :old.BOOKID;
        end;
```

#### DStockTrigger

```sql
CREATE TRIGGER DSCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 101  - :old.SCORE)/100 WHERE BOOK.BOOKID = :old.BOOKID;
        end;
```

#### ScoreTrigger

```sql
CREATE TRIGGER SCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 100 + :new.SCORE)/101 WHERE BOOK.BOOKID = :new.BOOKID;
        end;
```

#### DScoreTrigger

```sql
CREATE TRIGGER STOCKTRIGGER AFTER INSERT ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK - :new.AMOUNT) WHERE BOOK.BOOKID = :new.BOOKID;
        end;
```

### View

|      视图       |   作用   |
| :-----------: | :----: |
| DiscountBook  | 打折书籍视图 |
|    HotBook    | 畅销书籍视图 |
|    NewBook    |  新书视图  |
| RecommendBook | 推荐书籍视图 |

## Front-end(provisional)

### Page URL

| Page   | URL                                      | Front-Back                 | Back->Front                              |
| ------ | ---------------------------------------- | -------------------------- | ---------------------------------------- |
| 主页     | /onionbook/home/                         |                            | 1. 各一级分类的5本打折的图书：名字、折后价格、图片、评分；2. 10本销量最高的图书：名字、折后价格、图片、评分；3. 评分前10的图书：名字、折后价格、图片、评分（要知道分别排第几、并且排好顺序）；34 最新出版的16本图书：名字、折后价格、图片（要知道分别排第几、并且排好顺序）；4.  图书销量（总和）最高的作者：名字、简介、图片。 |
|        | /onionbook/home/contact                  |                            |                                          |
| 登陆     | /onionbook/account/login/                | 1. 客户：客户编号、密码              | 登陆是否成功                                   |
| 注册     | /onionbook/account/register/             | 1. 客户：客户姓名、密码              | 返回                                       |
| 搜索结果页面 | /onionbook/book/search/?standard=bookname&keywords=书名/ | 1. 搜索标准（图书）；2 . 关键词：书名     | 所有搜索结果的图书：名字、折前价格、折后价格、图片、评分、销量；         |
|        | /onionbook/book/search/?standard=author&keywords=作者/ | 1. 搜索标准（作者）；2 . 关键词：作者     | 所有搜索结果的图书：名字、折前价格、折后价格、图片、评分、销量；         |
|        | /onionbook/book/search/?standard=publisher&keywords=出版社/ | 1. 搜索标准（出版社）；2 . 关键词：出版社   | 所有搜索结果的图书：名字、折前价格、折后价格、图片、评分、销量；         |
|        | /onionbook/book/search/?standard=isbn&keywords=ISBN号/ | 1. 搜索标准（ISBN）；2 . 关键词：ISBN | 所有搜索结果的图书：名字、折前价格、折后价格、图片、评分、销量；         |
| 分类页面   | /onionbook/book/type/?typename=类别名/      | 类别                         | 所有搜索结果的图书：名字、折前价格、折后价格、图片、评分、销量；         |
| 商品详细信息 | /onionbook/book/bookdetail/?id=图书编号/     | 图书编号                       | 图书：名字、isbn、折前价格、折后价格、出版商、页数、销量、库存、图片、作者名字、第一二级分类、所有评论：客户编号、评分、内容、时间。 |
| 创建订单   | /onionbook/account/order/createorder/    | 商品编号、数量                    | 是否创建成功                                   |
| 支付     | /onionbook/account/order/pay/?id=订单编号/   | 订单编号                       | 是否支付成功                                   |
| 订单完成   | /onionbook/account/order/complete/       |                            | 支付是否完成                                   |
| 账户中心   | /onionbook/account/?id=客户编号/             | 客户编号                       | 客户：姓名、邮件、头像、账户余额、积分                      |
| 购物车    | /onionbook/accountr/cart/?id=客户编号/       | 客户编号                       | 所有商品：图片、名字、数量、折后价格                       |
| 收藏     | /onionbook/account/star/?id=客户编号/        | 客户编号                       | 所有商品：图片、名字、作者、出版商、折后价格                   |
| 历史订单列表 | /onionbook/accout/orderlist/?id=客户编号/    | 客户编号                       | 所有订单：编号、状态、总价；每个订单所有商品：图片、名字、数量、折后价格。    |

### Others

| 操作    | 前端->后端  | 后端->前端 |
| ----- | ------- | ------ |
| 加入购物车 | 商品编号、数量 | 加入是否成功 |

