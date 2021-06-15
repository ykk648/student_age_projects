#include "Testlink.h"  
  
int nFd = 0;  
struct termios stNew;  
struct termios stOld;  
  
//Open Port & Set Port  
int SerialInit()  
{  
    nFd = open(DEVICE, O_RDWR|O_NOCTTY|O_NDELAY);  
    if(-1 == nFd)  
    {  
        perror("Open Serial Port Error!\n");  
        return -1;  
    }  
    if( (fcntl(nFd, F_SETFL, 0)) < 0 )  
    {  
        perror("Fcntl F_SETFL Error!\n");  
        return -1;  
    }  
    if(tcgetattr(nFd, &stOld) != 0)  
    {  
        perror("tcgetattr error!\n");  
        return -1;  
    }  
  
    stNew = stOld;  
    cfmakeraw(&stNew);//œ«ÖÕ¶ËÉèÖÃÎªÔ­ÊŒÄ£Êœ£¬žÃÄ£ÊœÏÂËùÓÐµÄÊäÈëÊýŸÝÒÔ×ÖœÚÎªµ¥Î»±»ŽŠÀí  
  
    //set speed  
    cfsetispeed(&stNew, BAUDRATE);//38400
    cfsetospeed(&stNew, BAUDRATE);  
  
    //set databits    
    //stNew.c_cflag |= (CLOCAL|CREAD);  
    //stNew.c_cflag &= ~CSIZE;  
    //stNew.c_cflag |= CS8;  
  
    //set parity    
    //stNew.c_cflag &= ~PARENB;    
    //stNew.c_iflag &= ~INPCK;  
  
    //set stopbits    
   // stNew.c_cflag &= ~CSTOPB;  

    stNew.c_cflag &= ~PARENB;
    stNew.c_cflag &= ~CSTOPB;
    stNew.c_cflag &= ~CSIZE;
    stNew.c_cflag |= CS8;
	
    stNew.c_cc[VTIME]=0;    //Öž¶šËùÒª¶ÁÈ¡×Ö·ûµÄ×îÐ¡ÊýÁ¿  
    stNew.c_cc[VMIN]=1; //Öž¶š¶ÁÈ¡µÚÒ»žö×Ö·ûµÄµÈŽýÊ±Œä£¬Ê±ŒäµÄµ¥Î»Îªn*100ms  
                //Èç¹ûÉèÖÃVTIME=0£¬ÔòÎÞ×Ö·ûÊäÈëÊ±read£š£©²Ù×÷ÎÞÏÞÆÚµÄ×èÈû  
    tcflush(nFd,TCIFLUSH);  //Çå¿ÕÖÕ¶ËÎŽÍê³ÉµÄÊäÈë/Êä³öÇëÇóŒ°ÊýŸÝ¡£  
    if( tcsetattr(nFd,TCSANOW,&stNew) != 0 )  
    {  
        perror("tcsetattr Error!\n");  
        return -1;  
    }  
  
    return nFd;  
}  
  
int main(int argc, char **argv)  
{  
    int nRet = 0;  
    int i=0;
    char buf[1024];  
    if( SerialInit() == -1 )  
    {  
        perror("SerialInit Error!\n");  
        return -1;  
    }  
    strcpy(buf,"AT+link=ba,55,57644a\r\n");
    write(nFd, buf, SIZE);
    printf("ok");

    
    close(nFd);  
    return 0;  
}  