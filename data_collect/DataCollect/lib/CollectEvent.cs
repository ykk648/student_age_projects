using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace DataCollect.Lib
{

    public class CollectEvent
    {

        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void DataReceivedHandler(object sender,byte[] data);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="data"></param>
        public delegate bool DataSendHandler(byte[] data);

        ///<summary>
        ///发送随机序列
        ///</summary>
        public delegate void SendRandomSequence();

        public delegate void Md5check(string md5);

        public delegate void Send_query();
        public delegate void report(string report);
        public delegate void Config_ack(string period);
        public delegate void History(string start,string end);

        public delegate void DownLAN(byte[] lan);
        public delegate void DownPort(byte[] port);
        public delegate void Downcollpoint(byte[] point);
        public delegate void Downcollgen(byte[] gener);
        public delegate void Downserver(byte[] server);
        public delegate void Checkgm();
        public delegate void Period(string per);

    }
}
