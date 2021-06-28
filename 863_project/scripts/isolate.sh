ovs-vsctl del-br br1

if [ "$1" -eq "0" ]; then
	echo "the clients can ping each other"
        uci set wireless.@wifi-iface[0].isolate=0
        uci commit wireless
        /etc/init.d/network reload
elif [ "$1" -eq "1" ]; then
	echo "isolate the clients"
        uci set wireless.@wifi-iface[0].isolate=1
        uci commit wireless
        /etc/init.d/network reload
else	echo "the parameter must be 0 or 1"
fi
sleep 1
./ovs2.sh
echo "!!!!!!!!!!!!!DONE!!!!!!!!!!!!!!!!"
