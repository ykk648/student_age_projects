#! /bin/sh

ovs-vsctl -- set port wlan0-1 qos=@newqos -- --id=@newqos create qos type=linux-htb queues=0=@q0,1=@q1 -- --id=@q0 create queue other-config:min-rate=40000000 other-config:max-rate=40000000 -- --id=@q1 create queue other-config:min-rate=2400000 other-config:max-rate=2400000

ovs-vsctl -- set port wlan0-2 qos=@newqos -- --id=@newqos create qos type=linux-htb queues=0=@q0,1=@q1 -- --id=@q0 create queue other-config:min-rate=1200000 other-config:max-rate=1200000 -- --id=@q1 create queue other-config:min-rate=2400000 other-config:max-rate=2400000                      

#ovs-vsctl clear port wlan0-1 qos
#ovs-vsctl clear port wlan0-2 qos
