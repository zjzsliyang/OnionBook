# -*- coding: utf-8 -*-

import requests
import random

import sys
reload(sys)
sys.setdefaultencoding( "utf-8" )
import time

def getInfomation(id,i,j):
    # with open('test.txt', 'w') as f:
    #     sql = "insert INTO test3 VALUES(NAME ,'99');"
    #     f.close()

    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36'
    }

    url = 'https://api.douban.com/v2/book/' + str(id)

    f = open('ip.txt', 'r')
    ip = f.read()
    f.close()
    proxies = {"https": "http://" + ip}
    print proxies
    res = requests.get(url = url,proxies=proxies,timeout=3)
    time.sleep(1)
    if res.status_code != 200:
        raise Exception("error")
        # print 2;
        # newip = requests.get(url='http://vtp.daxiangdaili.com/ip/?tid=555300480278823&num=1&delay=5').text
        # f = open('ip.txt', 'w')
        # f.write(newip)
        # f.close()
        # proxies = {"https": "http://" + ip}
        # res = requests.get(url=url,proxies=proxies,timeout=3).json()
        # time.sleep(1)
    else:
        print 11
        res = res.json()

    # except:
    #     print 3
    #     newip = requests.get(url='http://vtp.daxiangdaili.com/ip/?tid=555300480278823&num=1&delay=5').text
    #     f = open('ip.txt', 'w')
    #     f.write(newip)
    #     f.close()
    #     proxies = {"https": "http://" + ip}
    #     res = requests.get(url=url,proxies=proxies,timeout=3).json()
    #     time.sleep(1)

    try:
        #name
        name = res['title']
        #author
        author = res["author"]
        #isbn
        isbn = res['isbn13']
        #publisher
        publisher = res['publisher']
        #publishingDate
        publishingDate = res['pubdate']
        #pages
        pages = res['pages']
        #price
        price = res['price']
        #image
        image = res["images"]['large']
        #type
        #discount
        #stock




        #切换
        primaryid = '0'+str(i);
        secondaryid = '0'+str(j);




        discount = round(random.uniform(0.5,1),2)
        stock = random.randint(10,1000)
        score = round(random.uniform(3,5),1)
        sale = random.randint(0,200)
        #summary
        introduction = res['summary'].replace('\n','\\n')

        #sql = "insert INTO book VALUES(\'%s\',\'%s\',\'%s\',\'%s\',\'%s\',\'%s\',\'%s\',\'%s\',,\'%s\',,\'%s\',,\'%s\',,\'%s\');\n" \
         #     % (isbn, name, primaryid,secondaryid,publisher, price[0:5],pages, discount, stock,score,sale,publishingDate)
        sql = "exec INSERTBOOK(\'%s\',\'%s\',\'%s\',\'%s\',\'%s\',%s,%s,%s,%s,%s,\'%s\',%s,\'%s\',\'%s\',\'%s\');\n" \
              % (isbn, name, primaryid, secondaryid, publisher, price[0:5], pages, discount, stock, score,publishingDate, sale, introduction,
                 author[0],image)
        print name
        print author[0]
        print isbn
        print publisher
        print publishingDate
        print pages
        print price.strip()[0:5]
        print image
        print sql
        #print introduction
        return sql
    except:
        print 'e'
        return '\n'

if __name__ == '__main__':
    temp = 1775691
    getInfomation(temp)