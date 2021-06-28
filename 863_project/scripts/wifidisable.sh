if [ $1 -eq "0" ]; then	
	echo "wireless network is now working"
        uci set wireless.@wifi-iface[0].disabled=0
        uci commit wireless
        /etc/init.d/network reload
	sleep 1
	./ovsshut.sh
	sleep 1
	./ovsinit.sh
	uci set network.wifi.ipaddr=192.168.5.$2
	uci commit network
	/etc/init.d/network reload
elif [ $1 -eq "1" ]; then
        echo "wireless network is disabled"
        uci set wireless.@wifi-iface[0].disabled=1
        uci commit wireless
        /etc/init.d/network reload
else
        echo "the value must be 0 or 1"
fi

echo "!!!!!!!!!!!!!!!!!!!!DONE!!!!!!!!!!!!!!!!!!"

