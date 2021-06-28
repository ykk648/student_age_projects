#!/bin/sh
ovs-vsctl del-br br1
if [ "$1" -ge "1" ] && [ "$1" -le "13" ] ; then
	echo "the channel you choose is $1"
       uci set wireless.radio0.channel=$1
       uci commit wireless
  /etc/init.d/network reload
else
	echo "The number of channel must be intger and between 1 and 13"
fi
sleep 1
./ovs2.sh
echo "!!!!!!!!!!!!!!!!!!!DONE!!!!!!!!!!!!!!!!!"
