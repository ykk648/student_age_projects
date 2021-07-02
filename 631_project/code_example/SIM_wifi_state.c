/*************************************************************************
	> File Name: SIM_wifi_state.c
	> Author: 
	> Mail: 
	> Created Time: 2017年05月23日 星期二 17时58分14秒
 ************************************************************************/

#include<stdio.h>
#include<stdbool.h>
#include<stdio.h>               /*标准输入输出定义*/
#include<sys/ioctl.h>
#include<time.h>
#include<unistd.h>             /*UNIX标准函数定义*/
#include<stdlib.h>
#include<sys/types.h>
#include<sys/stat.h>
#include<fcntl.h>             /*文件控制定义*/
#include<stdlib.h>            /*标准函数库定义*/
#include<termios.h>           /*PPSIX终端控制定义*/
#include<errno.h>             /*错误号定义*/
#include<sys/select.h>        /*kbhit函数用到它*/
#include<stropts.h>           /*同上*/
#include<string.h>
#include<netRSSI.h>
#include<get_name_ip.h>
#include "data_interface.h"
#define SPEED 115200
#define SIZE 512
unsigned int speed_arr[]={B115200,B57600,B38400,B19200,B9600,B4800,B2400,B1800,B1200,B600,B300,B200,B150,B134,B110,B75,B50,B0};
unsigned int name_arr[]={115200,57600,38400,19200,9600,4800,2400,1800,1200,600,300,200,150,134,100,75,50,0};
//char *dev = "/dev/ttyUSB2";
int csq_detected(int csq){
	if(csq>=0&&csq<=99){
		return (2*csq-113);
	}
	else if(csq>=100&&csq<=199){
		return (csq-216);
	}
	else{
		return 0;
	}
	/*switch(ber){
	case 0:
		change[1]=0;
		break;
	case 1:
		change[1]=0.01;
	case 2:
		change[1]=0.1
	}*/
}

void serial_send(int file_descriptor, char *buffer, size_t data_len)
{
    ssize_t len = 0;
    len = write(file_descriptor, buffer, data_len);
    if ( len == data_len ) {
    	printf("\nSend Success\n");
    	//return len;
    }
    else {
		tcflush(file_descriptor, TCOFLUSH);
		printf("Send Fail\n");
		//return -1;				
    }
}

int mod_detected(int mod,StateInfo *stateinfo){
	switch(mod){
	case 0:
		strcpy(stateinfo->sim_mode,"no service");
		break;
	case 1:
		strcpy(stateinfo->sim_mode,"GSM");
		break;
	case 2:
		strcpy(stateinfo->sim_mode,"GPRS");
		break;
	case 3:
		strcpy(stateinfo->sim_mode,"EGPRS (EDGE)");
		break;
	case 4:
		strcpy(stateinfo->sim_mode,"WCDMA");
		break;
	case 5:
		strcpy(stateinfo->sim_mode,"HSDPA only(WCDMA)");
		break;
	case 6:
		strcpy(stateinfo->sim_mode,"HSUPA only(WCDMA)");
		break;
	case 7:
		strcpy(stateinfo->sim_mode,"HSPA (HSDPA and HSUPA, WCDMA)");
		break;
	case 8:
		strcpy(stateinfo->sim_mode,"LTE");
		break;
	case 9:
		strcpy(stateinfo->sim_mode,"TDS-CDMA");
		break;
	case 10:
		strcpy(stateinfo->sim_mode,"TDS-HSDPA only");
		break;
	case 11:
		strcpy(stateinfo->sim_mode,"TDS-HSUPA only");
		break;
	case 12:
		strcpy(stateinfo->sim_mode,"TDS-HSPA (HSDPA and HSUPA)");
		break;
	case 13:
		strcpy(stateinfo->sim_mode,"CDMA");
		break;
	case 14:
		strcpy(stateinfo->sim_mode,"EVDO");
		break;
	case 15:
		strcpy(stateinfo->sim_mode,"HYBRID (CDMA and EVDO)");
		break;
	default:
		strcpy(stateinfo->sim_mode,"Undetected");
		break;
	}
	return 0;
}

int open_port(int port)
{
	int fd;
	char filename[128];
	snprintf(filename, sizeof(filename), "/dev/ttyUSB%d", port);
	//snprintf(filename, sizeof(filename), "/dev/pts/%d", port);
	fd = open(filename, O_RDWR|O_NOCTTY|O_NONBLOCK);

	//fd=open(dev,O_RDWR | O_NOCTTY | O_NONBLOCK);
	//	printf("fd=%d\n",fd);

	if(fd==-1)
	{
		perror("Can't Open SerialPort");
		return (-1);
	}

	if(fcntl(fd, F_SETFL, 0)<0)
		printf("fcntl failed!\n");
    else
		printf("fcntl=%d\n",fcntl(fd, F_SETFL,0));

	 /*测试是否为终端设备*/
    if(isatty(STDIN_FILENO)==0)
		printf("standard input is not a terminal device\n");
    else
		printf("isatty success!\n");
    printf("fd-open=%d\n",fd);

    return fd;
}


int get_operator(int fd,StateInfo *stateinfo)
{
	int nread;
	char buff[SIZE];

	char sbuffer[]="AT+COPS?\r";
	serial_send(fd,sbuffer,sizeof(sbuffer));

	int flag = 0;

	while(!flag)
	{
		while((nread=read(fd,buff,SIZE))>0)
		{
			printf("\nLen %d\n",nread);
			buff[nread]='\0';
			printf("\n%s",buff);

			if(strstr(buff,"COPS")!=NULL)
			{
				int i = 0;
				int j = 0;
				while(buff[i]!='\"')
				{
					i++;
				}
				//printf("%d",i);
				while(buff[i+1]!='\"')
				{
					//printf("%c\n",buff[i]);
					stateinfo->provider_name[j++]=buff[i+1];
					i++;
				}
				if(!(stateinfo->provider_name == NULL))
				{
					flag = 1;
				}
				stateinfo->provider_name[j] = '\0';
				printf("receive : %s",stateinfo->provider_name);
			}
			else if(strstr(buff,"ERROR")!=NULL)
			{
				strcpy(stateinfo->provider_name,"ERROR");
			}
			else
			{
				perror("provider name internal error");
				//return 1;
			}
		}
		//usleep(1000);        -> dead if added
	}
	printf("\n--get provider name end--\n");
	return 0;
}

int get_csq(int fd,StateInfo *stateinfo)
{
	int nread;
	char buff[SIZE];

	char sbuffer[]="AT+CSQ\r";
	serial_send(fd,sbuffer,sizeof(sbuffer));

	int flag = 0;

	while(!flag)
	{
		while((nread=read(fd,buff,SIZE))>0)
		{
			printf("\nLen %d\n",nread);
			buff[nread]='\0';
			printf("\n%s",buff);

			if(strstr(buff,"CSQ")!=NULL)
			{
				stateinfo->ber=0;
				stateinfo->csq=0;
				int i = 0;

				while(buff[i]!=',')
				{
					if(buff[i]>='0'&&buff[i]<='9')
					{
						stateinfo->csq=(stateinfo->csq)*10+(buff[i]-'0');
					}
					i++;
				}
				while(buff[i]!='\0')
				{
					if(buff[i]>='0'&&buff[i]<='9')
					{
						stateinfo->ber=(stateinfo->ber)*10+(buff[i]-'0');
					}
					i++;
				}
				flag = 1;
				stateinfo->csq=csq_detected(stateinfo->csq);
			}
		}
		//usleep(5000);
	}
	printf("\n%d + %d\n",stateinfo->csq,stateinfo->ber);
	printf("\n--get csq&ber end--\n");
	return 0;
}

int get_mod(int fd,StateInfo *stateinfo)
{
	int nread;
	char buff[SIZE];
	int mod = 0;

	char sbuffer[]="AT+CNSMOD?\r";
	serial_send(fd,sbuffer,sizeof(sbuffer));

	int flag = 0;

	while(!flag)
	{
		while((nread=read(fd,buff,SIZE))>0)
		{
			printf("\nLen %d\n",nread);
			buff[nread]='\0';
			printf("\n%s",buff);

			if(strstr(buff,"CNSMOD")!=NULL)
			{
				int i = 0;
				//int j = 0;
				while(buff[i]!=',')
				{
					i++;
				}
				while(buff[i]!='\0')
				{
					if(buff[i]>='0'&&buff[i]<='9')
					{
						mod = mod*10+(buff[i]-'0');
					}
					i++;
				}
				flag = 1;
			}
			else if(strstr(buff,"ERROR")!=NULL)
			{
				strcpy(stateinfo->sim_mode,"ERROR");
			}
			else
			{
				perror("sim mod detect internal error");
				return 1;
			}
		}
		//usleep(1000);        -> dead if added
	}
	mod_detected(mod,stateinfo);
	printf("\n--get sim mod end--\n");
	return 0;
}

int mode_selection(int fd,int mode)
{
	char atname[128];
	snprintf(atname, sizeof(atname), "AT+CNMP=%d\r", mode);
	serial_send(fd,atname,sizeof(atname));

	int flag = 0;
	int nread;
	char buff[SIZE];

	while(!flag)
	{
		while((nread=read(fd,buff,SIZE))>0)
		{
			printf("\nLen %d\n",nread);
			buff[nread]='\0';
			printf("\n%s",buff);

			if((nread<11)&&(strstr(buff,"OK")!=NULL))  // OK len 6  ERROR len 9
			{
				printf("Mode Selection Succeed\n");
				flag = 1;
			}
			else if(strstr(buff,"ERROR")!=NULL)
			{
				printf("Mode Selection Error\n");
				flag = 1;
				return 1;
			}
			else
			{

			}
		}
	}
	return 0;
}

int offline_control(int fd,int isornot)
{
	if((isornot!=0)&&(isornot!=1))
	{
		printf("Input Error");
		return 1;
	}

	char atname[128];
	int num;

	switch(isornot)
	{
	case 0:
		num = 7;
		break;
	case 1:
		num = 6;
		break;
	default:
		printf("Switch Error");
	}

	snprintf(atname, sizeof(atname), "AT+CFUN=%d\r", num);
	serial_send(fd,atname,sizeof(atname));

	int flag = 0;
	int nread;
	char buff[SIZE];

	while(!flag)
	{
		while((nread=read(fd,buff,SIZE))>0)
		{
			printf("\nLen %d\n",nread);
			buff[nread]='\0';
			printf("\n%s",buff);

			if((nread<11)&&(strstr(buff,"OK")!=NULL))  // OK len 6  ERROR len 9
			{
				printf("Offline Control Succeed\n");
				flag = 1;
			}
			else if(strstr(buff,"ERROR")!=NULL)
			{
				printf("Offline Control Error\n");
				flag = 1;
				return 1;
			}
			else
			{

			}
		}
	}
	return 0;
}

int set_opt(int fd, int nSpeed, int nBits, char nEvent, int nStop)   // 115200 8N1
{
    struct termios newtio;
    struct termios oldtio;

    if(tcgetattr(fd,&oldtio) != 0)
    {
        perror("SetupSerial 1");
        return -1;
    }

    bzero(&newtio,sizeof(newtio));
    newtio.c_cflag |= CLOCAL|CREAD;
    newtio.c_cflag &= ~CSIZE;

/***********数据位选择****************/
    switch(nBits)
    {
        case 7:
        newtio.c_cflag |= CS7;
        break;
        case 8:
        newtio.c_cflag |= CS8;
        break;
        }
/***********校验位选择****************/
    switch(nEvent)
    {
        case 'O':
        newtio.c_cflag |= PARENB;
        newtio.c_cflag |= PARODD;
        newtio.c_iflag |= (INPCK | ISTRIP);
        break;

        case 'E':
        newtio.c_iflag |= (INPCK |ISTRIP);
        newtio.c_cflag |= PARENB;
        newtio.c_cflag &= ~PARODD;
        break;

        case 'N':
        newtio.c_cflag &= ~PARENB;
 	    break;
        }
/***********波特率选择****************/
    switch(nSpeed)
    {
         case 2400:
        cfsetispeed(&newtio,B2400);
        cfsetospeed(&newtio,B2400);
            break;
         case 4800:
        cfsetispeed(&newtio,B4800);
        cfsetospeed(&newtio,B4800);
            break;
         case 9600:
        cfsetispeed(&newtio,B9600);
        cfsetospeed(&newtio,B9600);
            break;
         case 57600:
        cfsetispeed(&newtio,B57600);
        cfsetospeed(&newtio,B57600);
            break;
         case 115200:
        cfsetispeed(&newtio,B115200);
        cfsetospeed(&newtio,B115200);
            break;
         case 460800:
        cfsetispeed(&newtio,B460800);
        cfsetospeed(&newtio,B460800);
           break;
         default:
        cfsetispeed(&newtio,B9600);
        cfsetospeed(&newtio,B9600);
                break;
        }
/***********停止位选择****************/
    if(nStop == 1){
        newtio.c_cflag &= ~CSTOPB;
    }
    else if(nStop ==2){
        newtio.c_cflag |= CSTOPB;
    }
    newtio.c_cc[VTIME] = 0;  // wait time
    newtio.c_cc[VMIN] = 0;   // min receive size

    tcflush(fd,TCIFLUSH);
    if((tcsetattr(fd,TCSANOW,&newtio)) != 0)
    {
        perror("com set error");
        return -1;
    }
    printf("set done!\n");
    return 0;
}
/***************************UDP************************/
void sendUDP(char*udpString)
{
	unsigned short port = 10088;	//服务器端口
	char *server_ip = "192.168.1.103";	//服务器ip地址
	int sockfd;
	sockfd = socket(AF_INET, SOCK_DGRAM, 0);   //创建UDP套接字
	if(sockfd < 0)
	{
		perror("socket");
		exit(-1);
	}
	
	// 套接字地址
	struct sockaddr_in dest_addr;
	bzero(&dest_addr, sizeof(dest_addr));	// 清空内容
	dest_addr.sin_family = AF_INET;		// ipv4
	dest_addr.sin_port   = htons(port);	// 端口转换
	inet_pton(AF_INET, server_ip, &dest_addr.sin_addr);	// ip地址转换

	printf("send data to UDP server %s:%d!\n", server_ip, port);
	int flag = 0;
	while(flag < 1)

	{
		flag++;
		//发送数据
		int udpsend = sendto(sockfd, udpString, strlen(udpString), 0, (struct sockaddr*)&dest_addr, sizeof(dest_addr));
		printf("data is:%s\n", udpString);
		//printf("len = %d\n", len);
	}
	
	close(sockfd);
	return;
}
/********************************************************/
void SIM_wifi_state()
{
//	struct radio_state* radio=&(struct radio_state){true,false,-30,{0,0,0,0},"192.168.1.155",false,13};
	//struct radio_state radio=(struct radio_state){true,false,-30,{0,0,0,0},"192.168.1.155",false,13};
	char* interface1="wlan0";
	int fd;
	int i;
	int n;
	printf("The Loop of Module Detection Begin\n");
	for(i = 0;i<2;i++)
	{
		n = 2+6*i;
		printf("the reading module is NO.%d (totally %d)\n",i+1,2);
		fd=open_port(n);
		if(fd != -1)
		{
			set_opt(fd,SPEED,8,'N',1);
			get_operator(fd,&stateinfo[i]);
			get_csq(fd,&stateinfo[i]);
			get_mod(fd,&stateinfo[i]);
			printf("operator name is: %s\ncsq is: %d\nber is: %d\nsim mode is: %s\n",
					stateinfo[i].provider_name,
					stateinfo[i].csq,
					stateinfo[i].ber,
					stateinfo[i].sim_mode);
			close(fd);
			if(stateinfo[i].csq<-70)
				stateinfo[i].radio_enable=false;
			else
				stateinfo[i].radio_enable=true;
			stateinfo[i].wifi_rss=netstat(interface1);
			if(stateinfo[i].wifi_rss<-70||!stateinfo[i].wifi_rss)
				stateinfo[i].wifi_enable=false;
			else
				stateinfo[i].wifi_enable=true;
			memset(stateinfo[i].wifi_ip, 0, sizeof(stateinfo[i].wifi_ip));
			memset(stateinfo[i].radio_ip, 0, sizeof(stateinfo[i].radio_ip));
			get_local_ip(stateinfo[i].wifi_ip,stateinfo[i].radio_ip,i);
				
			char udpString[512];
			sprintf(udpString,"%d,%d,%d,%d,%d,%s,%s,%s,%s",
				stateinfo[i].wifi_enable,
				stateinfo[i].radio_enable,
				stateinfo[i].wifi_rss,
				stateinfo[i].csq,
				stateinfo[i].ber,
				stateinfo[i].sim_mode,			
				stateinfo[i].provider_name,
				stateinfo[i].wifi_ip,
				stateinfo[i].radio_ip
			);
			//调用UDP发送
			sendUDP(udpString);
			close(fd);
				
		}
		else
		{
			printf("this module did not exist\n");
			//break;
		}

		if(i == 2)
		{
			sleep(1);    //thread sleep
		}
	}	
    return;
}
