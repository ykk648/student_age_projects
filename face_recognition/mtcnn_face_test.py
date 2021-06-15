#!/usr/bin/env python
# -*- coding: utf-8 -*-
import cv2
from mtcnn.mtcnn import MTCNN
import os

detector = MTCNN(min_face_size=20)

# image = cv2.imread("detect0.2.jpg")
# image = cv2.imread("Darrell_Dickey_0001.jpg")
# result = detector.detect_faces(image)

# Result is an array with all the bounding boxes detected. We know that for 'ivan.jpg' there is only one.
filepath = 'block_source/'
fs = os.listdir(filepath)
for f1 in fs:
    tem_path = os.path.join(filepath, f1)
    image = cv2.imread(tem_path)
    result = detector.detect_faces(image)

    for i in range(len(result)):
        bounding_box = result[i]['box']
        keypoints = result[i]['keypoints']

        cv2.rectangle(image,
                      (bounding_box[0], bounding_box[1]),
                      (bounding_box[0] + bounding_box[2], bounding_box[1] + bounding_box[3]),
                      (0, 155, 255),
                      2)

        cv2.circle(image, (keypoints['left_eye']), 2, (0, 155, 255), 2)
        cv2.circle(image, (keypoints['right_eye']), 2, (0, 155, 255), 2)
        cv2.circle(image, (keypoints['nose']), 2, (0, 155, 255), 2)
        cv2.circle(image, (keypoints['mouth_left']), 2, (0, 155, 255), 2)
        cv2.circle(image, (keypoints['mouth_right']), 2, (0, 155, 255), 2)

    cv2.imwrite("mtcnn_face\\" + str(f1), image)
    # cv2.namedWindow("enhanced",0)
    # cv2.resizeWindow("enhanced", 640, 480)
    #     cv2.imshow("enhanced", image)
    cv2.waitKey(0)

# print(result)
