#!/usr/bin/python
# -*- coding: utf-8 -*-
import httplib
import json

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
    path = '/wm/staticflowpusher/json'
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

pusher = StaticFlowPusher('192.168.1.101')  
#配置V-SDNAP流表
flow1 =	{
  'switch':"00:00:00:4c:00:00:7f:5e",
  "name":"flow-mod-1",
  "cookie":"0",
  "priority":"2000",
  "in_port":"1",
  "eth_type":"0x0800",
  "ipv4_src":"192.168.1.200/32",
  "ipv4_dst":"192.168.1.218/32",
  "active":"true",
  "actions":"set_queue=3,output=3"
#"actions":"enqueue=2:3"
  
}

flow2 =	{
  'switch':"00:00:00:4c:00:00:7f:5e",
  "name":"flow-mod-2",
  "cookie":"0",
  "priority":"4000",
  "in_port":"1",
  "eth_type":"0x0800",
  "ipv4_src":"192.168.1.200/32",
  "ipv4_dst":"192.168.1.218/32",
  "active":"true",
  "actions":"set_queue=1,output=3"  
}

flow3 =	{
  'switch':"00:00:00:4c:00:00:7f:5e",
  "name":"flow-mod-3",
  "cookie":"0",
  "priority":"3000",
  "in_port":"1",
  "eth_type":"0x0800",
  "ipv4_src":"192.168.1.200/32",
  "ipv4_dst":"192.168.1.218/32",
  "active":"true",
  "actions":"output=2"
}
#配置SDNAP1流表
flow4 =	{
  'switch':"00:00:00:23:45:67:57:ab",
  "name":"flow-mod-4",
  "cookie":"0",
  "priority":"100",
  "in_port":"1",
  "eth_type":"0x0800",
  "ipv4_src":"192.168.1.200/32",
  "ipv4_dst":"192.168.1.218/32",
  "active":"true",
  "actions":"output=2"
}
#配置SDNAP2流表
flow5 =	{
  'switch':"00:00:00:23:45:67:58:ab",
  "name":"flow-mod-5",
  "cookie":"0",
  "priority":"200",
  "in_port":"2",
  "eth_type":"0x0800",
  "ipv4_src":"192.168.1.200/32",
  "ipv4_dst":"192.168.1.218/32",
  "active":"true",
  "actions":"output=3"
}
#下发SDNAP1流表
#pusher.set(flow1)   
#pusher.set(flow2)
pusher.set(flow3)
pusher.set(flow4) 
pusher.set(flow5) 
#pusher.remove(flow2)
