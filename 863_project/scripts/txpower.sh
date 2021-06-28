ovs-vsctl del-br br1

if [ "$1" -ge "0" ] && [ "$1" -le "30" ] ; then
	echo "the txpower is $1"
       uci set wireless.radio0.txpower=$1
       uci commit wireless
       /etc/init.d/network reload
else
	echo "txpower must between 0 and 30 dbm"
fi
sleep 1
./ovs2.sh
echo "!!!!!!!!!!!!!!!!!!!DONE!!!!!!!!!!!!!!!!!!"
