#!/usr/bin/env python
# -*- coding: utf-8 -*-
import os
from hyperlpr_py3 import  pipline as  pp
import numpy as np
import HyperLPRLite as pr

import csv

from PIL import ImageFont
from PIL import Image
from PIL import ImageDraw
fontC = ImageFont.truetype("./Font/platech.ttf", 14, 0)

import cv2

def cv_imread(file_path):
    cv_img = cv2.imdecode(np.fromfile(file_path,dtype=np.uint8),cv2.IMREAD_UNCHANGED)
    return cv_img

def drawRectBox(image,rect,addText):
    cv2.rectangle(image, (int(rect[0]), int(rect[1])), (int(rect[0] + rect[2]), int(rect[1] + rect[3])), (0,0, 255), 2,cv2.LINE_AA)
    cv2.rectangle(image, (int(rect[0]-1), int(rect[1])-16), (int(rect[0] + 115), int(rect[1])), (0, 0, 255), -1,
                  cv2.LINE_AA)
    img = Image.fromarray(image)
    draw = ImageDraw.Draw(img)
    draw.text((int(rect[0]+1), int(rect[1]-16)), addText, (255, 255, 255), font=fontC)
    # draw.text((int(rect[0]+1), int(rect[1]-16)), addText.decode("utf-8"), (255, 255, 255), font=fontC)
    imagex = np.array(img)
    return imagex


parent= r"images\xingneng"
# parent= r"images\special\新能源-大车牌"
# parent= r"images\plate-data"


# list = 'images/here/京A88731.jpg'
# list2 = 'images_rec/2_.jpg'
# list3 = list.encode('gbk')
# image =  cv_imread(list)
# print(type(image))
# cv2.imshow("image",image)
model = pr.LPR("model/cascade.xml","model/model12.h5","model/ocr_plate_all_gru.h5")

plate_real_list = []
plate_predict_list = []


def plate_recogniton(real_path):
    plate_real = real_path[:-4].split('\\')[-1][:8]
    plate_real_list.append(plate_real)
    print('plate_real:' + str(plate_real))

    if real_path.endswith(".jpg") or real_path.endswith(".png") or real_path.endswith(".JPG"):
        image =  cv_imread(real_path)
        # print(type(image))
        # image,res  = model.SimpleRecognizePlateByE2E(image)
        res = model.SimpleRecognizePlateByE2E(image)
        max_res = ['null',0,[862.01999999999998, 924.0, 178.03504678726196, 52.0]]
        res.sort(key=lambda x: x[1],reverse=True)
        if len(res) == 0:
            pass
        elif len(res) >= 1:
            max_res = res[0]
        print(res)
        plate_predict = max_res[0]
        print('plate_predict:' + plate_predict)
        plate_predict_list.append(plate_predict)
        # for pstr, confidence, rect in model.SimpleRecognizePlateByE2E(image):
        #     if confidence > 0.7:
        #         image = drawRectBox(image, rect, pstr + " " + str(round(confidence, 3)))
        #         print("plate_str", pstr)
        #         print("plate_confidence", confidence)
        # image = drawRectBox(image, max_res[2], max_res[0] + " " + str(round(max_res[1], 3)))
        # cv2.imshow("image",image)
        # cv2.waitKey(0)

# for filename in os.listdir(parent):
#     path = os.path.join(parent,filename)
#     # print (path)
#     if os.path.isdir(path):
#         for filename_next in os.listdir(path):
#             real_path = os.path.join(path, filename_next)
#             plate_recogniton(real_path)
#     else:
#         real_path = path
#         plate_recogniton(real_path)


import os
for fpathe,dirs,fs in os.walk(parent):
  for f in fs:
    filepath = os.path.join(fpathe,f)
    plate_recogniton(filepath)


print(plate_real_list)
print(plate_predict_list)

# import xlwt



with open('score.csv','w',newline='') as f:
    writer = csv.writer(f)
    for i in range(len(plate_real_list)):
        writer.writerow([plate_real_list[i],plate_predict_list[i]])
    f.close()
