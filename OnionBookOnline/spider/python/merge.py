# -*- coding: utf-8 -*-

if __name__ == '__main__':
    book_tags = [
        ['小说','随笔','散文','诗歌','童话','杂文','儿童','名著'],
        ['漫画','绘本','言情','推理','科幻','武侠','青春','悬疑'],
        ['历史','心理','社会','哲学','艺术','政治','建筑','宗教'],
        ['旅行','摄影','美食','健康','教育','家居','职场','两性'],
        ['经济','管理','金融','投资','营销','理财','股票','广告'],
        ['科普','科学','交互','编程','算法','通信','程序','互联网']
    ]
    f = open('total8' + '.txt', 'w')

    i = 0
    j = 0
    k = 0
    while i < 6:
        while j < 8:
            try:
                f2 = open(book_tags[i][j] + '.txt', 'r')
            except:
                continue
            while True:
                line =  f2.readline()
                if not line:
                    break
                f.write(line)
                print line
            k = k + 1
            j = j + 1
            f2.close()
            if k >= 48:
                break
        j = 0;
        i = i+1;
        f2.close()
    f.close()