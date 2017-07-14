# -*- coding: utf-8 -*-

import sys
import time
import urllib
import urllib2
import requests
import numpy as np
from bs4 import BeautifulSoup
from openpyxl import Workbook
import re

# url = "https://book.douban.com/subject/1775691/?from=tag_all"
# reload(sys)
# sys.setdefaultencoding('utf8')
#
soup = BeautifulSoup(open('photo.html'),"lxml")
# #
infoString = str(soup.find('div', {'id': 'info'}))


match = re.findall(r'出版社:</span> (.*)<br/>',infoString)
if len(match):
    print match[0]

#print infoString

# #
# # print list_soup
#
# req = urllib2.Request(url)
# source_code = urllib2.urlopen(req).read()
# plain_text=str(source_code)
# soup = BeautifulSoup(plain_text,"lxml")
# photo_soup = soup.find('div', {'id': 'mainpic'})
# photoUrl = photo_soup.find('a',{'class':'nbg'})

# info_soup = soup.find('div', {'id': 'info'})
#desc_list = info_soup.split(':')

#
# pattern = re.compile(r'hello<.*1')
# match = pattern.search('hello world! hello<01')
# if match:
#     print match.group()





# for book_info in list_soup.findAll('dd'):
#     title = book_info.find('a', {'class': 'title'}).string.strip()
#     desc = book_info.find('div', {'class': 'desc'}).string.strip()
#     desc_list = desc.split('/')
#     book_url = book_info.find('a', {'class': 'title'}).get('href')
#     print title
#     print book_url



