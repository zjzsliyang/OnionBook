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


reload(sys)
sys.setdefaultencoding('utf8')

soup = BeautifulSoup(open('test.html'),"lxml")

list_soup = soup.find('div', {'class': 'mod book-list'})

for book_info in list_soup.findAll('dd'):
    title = book_info.find('a', {'class': 'title'}).string.strip()
    desc = book_info.find('div', {'class': 'desc'}).string.strip()
    desc_list = desc.split('/')
    book_url = book_info.find('a', {'class': 'title'}).get('href')
    book_id = re.findall(r'https://book.douban.com/subject/(.*)/\?from=tag_all', book_url)
    print title
    print book_id[0]



