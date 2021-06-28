#!/usr/bin/python
# -*- coding: utf-8 -*-
import httplib
import json
import os
import sys
import re
class StaticFlowPusher(object):

  def __init__(self, server):
    self.server = server

  def get(self, data):
    ret = self.rest_call({}, 'GET')
    return json.loads(ret[2])

  def set(self, data):
    ret = self.rest_call(data, 'POST')
    return ret[0] == 200

  def remove(self, objtype, data):
    ret = self.rest_call(data, 'DELETE')
    return ret[0] == 200

  def rest_call(self, data, action):
    path = '/wm/staticflowentrypusher/json'
    headers = {
      'Content-type': 'application/json',
      'Accept': 'application/json',
      }
    body = json.dumps(data)
    conn = httplib.HTTPConnection(self.server, 8080)
    conn.request(action, path, body, headers)
    response = conn.getresponse()
    ret = (response.status, response.reason, response.read())
    print ret
    conn.close()
    return ret

pusher = StaticFlowPusher('192.168.1.215')  
################################## SDNAP2 flows######################################
###### link recovery flows#############
flow100 = {
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-1",
  "cookie":"0",
  "priority":"1000",
  "ingress-port":"3",
  "dst-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"output=1"  	
  }

flow101 ={
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-2",
  "cookie":"0",
  "priority":"1010",
  "ingress-port":"1",
  "src-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"output=3"
  }
#### wireless relay flows#################
flow102 ={
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-3",
  "cookie":"0",
  "priority":"1020",
  "ingress-port":"3",
  "dst-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"output=2"
  }
flow103 ={
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-4",
  "cookie":"0",
  "priority":"1030",
  "ingress-port":"2",
  "src-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"output=3"
  }

######### bandlimit flows######################

#### phone call bandlimit ######

######################-------------->20k
flow104 ={
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-5",
  "cookie":"0",
  "priority":"5050",
  "ingress-port":"3",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.106", #  "src-mac":"c4:6a:b7:ef:61:44",                       # src-ip
  "dst-ip":"192.168.1.218", # "dst-mac":"00:66:4b:c6:70:ee",                      # dst-ip
  "active":"true",
  "actions":"enqueue=1:1"                       # queue number
  }

flow1 = {
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-1",
  "cookie":"0",
  "priority":"1000",
  "ingress-port":"2",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.218",                #"00:66:4b:c6:70:ee",                         # src-ip
  "dst-ip":"192.168.1.106",  		   #"c4:6a:b7:ef:61:44",                         # dst-ip
  "active":"true",
  "actions":"enqueue=3:1"                          # queue number
  }

######################-------------->50k
flow105 ={
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-6",
  "cookie":"0",
  "priority":"5040",
  "ingress-port":"3",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.106",          #  "src-mac":"c4:6a:b7:ef:61:44",                       # src-ip
  "dst-ip":"192.168.1.218",          # "dst-mac":"00:66:4b:c6:70:ee",                      # dst-ip
  "active":"true",
  "actions":"enqueue=1:2"                       # queue number
  }

flow2 =	{
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-2",
  "cookie":"0",
  "priority":"1050",
  "ingress-port":"2",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.218",                         # src-ip
  "dst-ip":"192.168.1.106",                         # dst-ip
  "active":"true",
  "actions":"enqueue=3:2"                          # queue number
  }
########## vedio bandlimit #######
flow106 = {
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-7",
  "cookie":"0",
  "priority":"5060",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.189",                        # dst-ip
  "src-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"enqueue=3:3"                        # queue number
  }

flow107 =	{
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-8",
  "cookie":"0",
  "priority":"5070",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.",                        # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:"                        # queue number
  }

flow108 =	{
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-9",
  "cookie":"0",
  "priority":"5080",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:"                         # queue number
  }
flow109 =	{
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-10",
  "cookie":"0",
  "priority":"5090",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:"                         # queue number
  }

##############################  SDNAP1 flows#######################
########## vedio bandlimit#######  
flow3 = {
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-3",
  "cookie":"0",
  "priority":"1030",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.202",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13",
  "active":"true",
  "actions":"enqueue=3:3"                         # queue number
  }  

flow4 =	{
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-4",
  "cookie":"0",
  "priority":"1020",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.189",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:3"                         # queue number
  }

flow5 = {
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-5",
  "cookie":"0",
  "priority":"1030",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:"                         # queue number
  }
  
flow6 = {
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-6",
  "cookie":"0",
  "priority":"1040",
  "ingress-port":"1",
  "ether-type":"0x0800",
  "src-ip":"192.168.1.215",
  "dst-ip":"192.168.1.",                         # dst-ip
  "src-mac":"80:ee:73:01:8f:13", 
  "active":"true",
  "actions":"enqueue=3:"                         # queue number
  }


I = raw_input('please select the flows, 1 for wireline recovery, 2 for wireless relay, 3 for bandlimit, clear for clear:  ')
os.system('./clear-flows.sh')
if I == '1':
	pusher.set(flow100)
	pusher.set(flow101)
elif I == '2':
	pusher.set(flow102)
	pusher.set(flow103)
elif I == '3':
	T = raw_input('please select which bandlimit flows to be pushed, 31 for phonecall, 32 for vedio:  ')
        if T == 'C1':
		Q = raw_input('please select a value for the band, 20 for 20k, 322 for 50k, free for bandfree:  ')
		if Q == '20': 
			pusher.set(flow104)
			pusher.set(flow1)
		elif Q == '50':
			pusher.set(flow105)
			pusher.set(flow2)
		else:
			os.system('./clear-flows.sh')
	elif T == '32':
		pusher.set(flow3)
		pusher.set(flow4)
		#pusher.set(flow5)
		#pusher.set(flow6)
	else:
		os.system('./clear-flows.sh')
else:
	os.system('./clear-flows.sh')


