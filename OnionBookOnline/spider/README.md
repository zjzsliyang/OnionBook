## 数据来源：豆瓣图书

**爬虫**

```
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

**插入函数**

|     过程     |                 作用                 |
| :--------: | :--------------------------------: |
| InsertBook | 保证BOOK表、AUTHOR表、PICTURE、WRITE表同时插入 |

```
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

## 触发器

|      触发器       |  触发条件  |   操作    |
| :------------: | :----: | :-----: |
| BalanceTrigger |  更新余额  |  更新积分   |
|  StockTrigger  |  创建订单  |  更新库存   |
| DStockTrigger  |  删除订单  |  更新库存   |
|  ScoreTrigger  | 插入用户评分 | 更新图书总评分 |
| DScoreTrigger  | 删除用户评分 | 更新图书总评分 |

**BalanceTrigger**

```
CREATE TRIGGER BALANCETRIGGER BEFORE UPDATE OF "Balance" ON "AspNetUsers" 
    for each row
        begin
           if :old."Balance" > :new."Balance" then
                :new."Credits" := :new."Credits" + :old."Balance" - :new."Balance";
           end if;
        end;

```

**StockTrigger**

```
CREATE TRIGGER DSTOCKTRIGGER AFTER DELETE ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK + :old.AMOUNT) WHERE BOOK.BOOKID = :old.BOOKID;
        end;
```

**DStockTrigger**

```
CREATE TRIGGER DSCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 101  - :old.SCORE)/100 WHERE BOOK.BOOKID = :old.BOOKID;
        end;
```

**ScoreTrigger**

```
CREATE TRIGGER SCORETRIGGER AFTER DELETE ON OCOMMENT 
    for each row
        begin
           UPDATE BOOK SET BOOK.SCORE = (BOOK.SCORE * 100 + :new.SCORE)/101 WHERE BOOK.BOOKID = :new.BOOKID;
        end;
```

**DScoreTrigger**

```
CREATE TRIGGER STOCKTRIGGER AFTER INSERT ON CONTAIN 
    for each row
        begin
           UPDATE BOOK SET BOOK.STOCK = (BOOK.STOCK - :new.AMOUNT) WHERE BOOK.BOOKID = :new.BOOKID;
        end;

```

## 视图

|      视图       |   作用   |
| :-----------: | :----: |
| DiscountBook  | 打折书籍视图 |
|    HotBook    | 畅销书籍视图 |
|    NewBook    |  新书视图  |
| RecommendBook | 推荐书籍视图 |