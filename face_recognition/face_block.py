#!/usr/bin/env python
# -*- coding: utf-8 -*-
import math
import random

import cv2

source_path = r"E:\项目\人脸识别-车牌识别\face-recognition\source"


def random_black(x, y, w, h, percent):
    area = w * h
    shrink = area * percent
    i = int(math.sqrt(shrink) / 2)
    xx = random.randint(x, x + w)
    yy = random.randint(y, y + h)
    # xx = x
    # yy = y
    return xx - i, yy - i, 2 * i, 2 * i


def block(filename):
    # face_cascade 为CascadeClassifier对象
    face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')
    img = cv2.imread(filename)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)  # 转化为灰度图

    faces_back = face_cascade.detectMultiScale(gray, 1.3, 5)
    x, y, w, h = faces_back[0]

    percent_list = [0.01, 0.05, 0.1, 0.2, 0.3, 0.4, 0.5]

    for j in percent_list:
        # j = 0.5
        img_back = cv2.imread(filename)

        xx, yy, ww, hh = random_black(x, y, w, h, j)
        print(xx, yy, ww, hh)
        img_back[xx:xx + ww, yy:yy + hh] = (0, 0, 0)

        gray = cv2.cvtColor(img_back, cv2.COLOR_BGR2GRAY)

        # 参数：
        # 待检测的灰度图
        # 每次搜索图像时，搜索窗口的压缩率。1.3表示搜索窗口扩大30%
        # 每个人脸矩形保留近邻数目的最小值
        # faces = face_cascade.detectMultiScale(gray, 1.3, 5) # 返回人脸矩形数组
        # for (x, y, w, h) in faces:
        #     img_back = cv2.rectangle(img, (x,y), (x+w, y+h), (0, 255, 0), 2) #绘制矩形

        # cv2.namedWindow("face detect", 0)
        # cv2.resizeWindow("face detect", 640, 480)

        # cv2.imshow("001detect"+str((j)/10), img_back)
        cv2.imwrite("block_source\\006_detect" + str(j) + ".jpg", img_back)
        # cv2.waitKey(0)


filename = 'Sylvie_Guillem_0001.jpg'
block(filename)
