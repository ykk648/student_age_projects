using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCollect.Panel
{
    public class CollectPoints
    {
        public byte t_p = 0;//节点属于那个接口
        public byte t_s = 0;//节点在接口中的顺序
        public byte[] addr = new byte[14]; //表地址号
        public byte maddr = 0;
        public byte tab_type = 64;//表类型
        public byte tab_state;//表状态
        public byte funcode = 3;//功能码
        public byte[] enercode = new byte[5] { 48, 48, 48, 48, 48 };//能耗编码
        public byte item_count;//显示条数个数
        public byte[] reg_len = new byte[20];
        public Int16[] commaddr = new Int16[20];
        public float[] mul = new float[20];
    }


}
