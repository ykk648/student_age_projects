#!/usr/bin/env python
# -*- coding: utf-8 -*-
# !/usr/bin/env python
# -*- coding: utf-8 -*-
import math
import random
import os
import cv2


def random_black(x, y, w, h, percent):
    area = w * h
    shrink = area * percent
    i = int(math.sqrt(shrink) / 2)
    xx = random.randint(x, x + w)
    yy = random.randint(y, y + h)
    # xx = x
    # yy = y
    return xx, yy, 2 * i, 2 * i


def detect(filepath):
    fs = os.listdir(filepath)
    for f1 in fs:
        tem_path = os.path.join(filepath, f1)
        print(tem_path)
        # face_cascade 为CascadeClassifier对象
        face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

        img = cv2.imread(tem_path)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)  # 转化为灰度图

        faces = face_cascade.detectMultiScale(gray, 1.3, 5)
        # x, y, w, h = faces[0]

        for (x, y, w, h) in faces:
            img = cv2.rectangle(img, (x, y), (x + w, y + h), (0, 255, 0), 2)  # 绘制矩形

        # cv2.namedWindow("face detect", 0)
        # cv2.resizeWindow("face detect", 640, 480)

        # cv2.imshow("detect", img)
        cv2.imwrite("opencv_face\\" + str(f1), img)
        cv2.waitKey(0)


# for i in range(5):
#     filename = 'detect0.'+str(i+1)+'.jpg'
#     print(filename)
#     detect(filename)

detect('block_source/')
