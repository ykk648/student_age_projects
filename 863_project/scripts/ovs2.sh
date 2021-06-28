
ovs-vsctl del-br br0
ifconfig eth1 0.0.0.0
ovs-vsctl add-br br0
ovs-vsctl add-port br0 eth1
ovs-vsctl add-port br0 eth0.2
ovs-vsctl add-port br0 wlan0-1
ifconfig eth1 0.0.0.0
ovs-vsctl set-controller br0 tcp:222.25.156.80:6653
ifconfig br0 222.25.156.104 netmask 255.255.255.0
#ovs-vsctl set-controller br0 tcp:222.25.156.149:6653
#ifconfig br0 222.25.156.178 netmask 255.255.255.0
ifconfig br0 promisc up
ovs-vsctl set bridge br0 stp_enable=true
#./queue.sh
ovs-vsctl show
