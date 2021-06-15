#!/usr/bin/env python
# -*- coding: utf-8 -*-

from PIL import ImageFont
from PIL import Image
from PIL import ImageDraw
fontC = ImageFont.truetype("./Font/platech.ttf", 14, 0)

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


import HyperLPRLite as pr
import cv2
import numpy as np
grr = cv_imread("甘000666.JPG")
model = pr.LPR("model/cascade.xml","model/model12.h5","model/ocr_plate_all_gru.h5")

for pstr,confidence,rect in model.SimpleRecognizePlateByE2E(grr):
        if confidence>0.7:
            image = drawRectBox(grr, rect, pstr+" "+str(round(confidence,3)))
            print("plate_str",pstr)
            print("plate_confidence",confidence)


cv2.imshow("image",image)
cv2.waitKey(0)