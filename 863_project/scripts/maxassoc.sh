ovs-vsctl del-br br1

if [ "$1" -ge "1" ] && [ "$1" -le "30" ]; then
	echo "the maximal of associated client is $1"
       uci set wireless.radio0.maxassoc=$1
       uci commit wireless
        /etc/init.d/network reload
else
        echo "the maximal of  associated client must between 1 and 30"
fi
sleep 1
./ovs2.sh

echo "!!!!!!!!!!!!!!!!!!!!!DONE!!!!!!!!!!!!!!!!!!"
