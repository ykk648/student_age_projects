using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCollect.Panel
{
    class XML_Beat
    {
        /// <summary>
        /// 要发送的心跳包
        /// </summary>
        public string heart_xml(string buding_id, string gateway_id)
        {

            String dt = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
             "<root>\r\n" +
             " <common>\r\n" +
             "  <building_id>" + buding_id + "</building_id>\r\n" +
             "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
             "    <type>time</type>\r\n" +
             "  </common>\r\n" +
             "  <heart_beat operation=\"notify/time\">\r\n" +
             "   <time>" + dt + "</time>\r\n" +
             "   </heart_beat>\r\n" +
             " </root>";
         return str;
     
        }
        /// <summary>
        /// 服务器主动查询
        /// </summary>
        /// <param name="buding_id"></param>
        /// <param name="gateway_id"></param>
        /// <returns></returns>
        public string query_xml(string buding_id, string gateway_id)
        {

             string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
             "<root>\r\n" +
             " <common>\r\n" +
             "  <building_id>" + buding_id + "</building_id>\r\n" +
             "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
             "    <type>query</type>\r\n" +
             "  </common>\r\n" +
             "  <data operation=\"query\">\r\n" +
             "  </data>\r\n" +
             " </root>";
            return str;

        }
        /// <summary>
        /// 发送随机序列
        /// </summary>
        public string sequence_xml(string buding_id, string gateway_id,string randomstr)
        {
          
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                         "<root>\r\n" +
                         " <common>\r\n" +
                         "  <building_id>" + buding_id + "</building_id>\r\n" +
                         "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
                         "    <type>sequence</type>\r\n" +
                         "  </common>\r\n" +
                         "  <id_validate operation=\"request/sequence/md5/result\">\r\n" +
                         "   <sequence>" + randomstr + "</sequence>\r\n" +
                         "   </id_validate>\r\n" +
                         " </root>";
            return str;
        
        }
        /// <summary>
        /// 发送验证结果
        /// </summary>
        public string result_xml(string buding_id, string gateway_id)
        {
          
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                         "<root>\r\n" +
                         " <common>\r\n" +
                         "  <building_id>" + buding_id + "</building_id>\r\n" +
                         "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
                         "    <type>result</type>\r\n" +
                         "  </common>\r\n" +
                         "  <id_validate operation=\"request/sequence/md5/result\">\r\n" +
                         "   <result>pass</result>\r\n" +
                         "   </id_validate>\r\n" +
                         " </root>";
            return str;

        }
        /// <summary>
        /// 发送采集间隔设置
        /// </summary>
        /// <param name="buding_id"></param>
        /// <param name="gateway_id"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public string period_xml(string buding_id, string gateway_id,string period)
        {
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                         "<root>\r\n" +
                         " <common>\r\n" +
                         "  <building_id>" + buding_id + "</building_id>\r\n" +
                         "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
                         "    <type>period</type>\r\n" +
                         "  </common>\r\n" +
                         "  <config  operation=\"period/period_ack\">\r\n" +
                         "   <period>"+ period +"</period>\r\n" +
                         "   </config>\r\n" +
                         " </root>";
             return str;
        }
        /// <summary>
        /// 历史记录查询包
        /// </summary>
        /// <param name="buding_id"></param>
        /// <param name="gateway_id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string history_xml(string buding_id, string gateway_id, string start, string end)
        {
            string str = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                         "<root>\r\n" +
                         " <common>\r\n" +
                         "  <building_id>" + buding_id + "</building_id>\r\n" +
                         "   <gateway_id>" + gateway_id + "</gateway_id>\r\n" +
                         "    <type>olddata</type>\r\n" +
                         "  </common>\r\n" +
                         "  <config  operation=\"start/end\">\r\n" +
                         "   <star>" + start + "</star>\r\n" +
                         "   <end>" +  end + "</end>\r\n" +
                         "   </config>\r\n" +
                         " </root>";
             return str;
            
        }
    }
}
