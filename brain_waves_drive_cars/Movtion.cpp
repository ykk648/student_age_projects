#include "Movtion.h"

char DOWN[]={0xff,0x00,0x00,0x00,0xff};
char QMOVE[]={0xff,0x00,0x01,0x00,0xff};
char HMOVE[]={0xff,0x00,0x02,0x00,0xff};
char ZMOVE[]={0xff,0x00,0x03,0x00,0xff};
char YMOVE[]={0xff,0x00,0x04,0x00,0xff};

int Movtion(char *ip, char *mode)
{
    char buf[MAXLINE];
    int i=0;
    int sockfd = socket(AF_INET, SOCK_STREAM, 0);

    sockaddr_in servaddr = {0};
    servaddr.sin_family = AF_INET;
    inet_pton(AF_INET, ip, &servaddr.sin_addr);
    servaddr.sin_port = htons(SERV_PORT);

    if (0!= connect(sockfd, (sockaddr *)&servaddr, sizeof(servaddr)))
    {
        printf("connected failed");
        return 1;
    }
    if(strcmp("0",mode)==0)
	{
		write(sockfd, DOWN, sizeof(DOWN));
   	
	}
	if(strcmp("1",mode)==0)
	{
		
		write(sockfd, QMOVE, sizeof(QMOVE));
   		
		
	}
	
   if(strcmp("2",mode)==0)
	{
		write(sockfd, HMOVE, sizeof(HMOVE));
   		
	}
	if(strcmp("3",mode)==0)
	{
		write(sockfd, ZMOVE, sizeof(ZMOVE));
   		 
	}
	if(strcmp("4",mode)==0)
	{
		write(sockfd, YMOVE, sizeof(YMOVE));
   		 
	}

    close(sockfd);
    return 0;
}
