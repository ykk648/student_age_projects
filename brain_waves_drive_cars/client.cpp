#include <stdio.h>
#include <arpa/inet.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <string.h>

#define MAXLINE 80
#define SERV_PORT 2001

char DOWN[]={0xff,0x00,0x00,0x00,0xff};
char QMOVE[]={0xff,0x00,0x01,0x00,0xff};
char HMOVE[]={0xff,0x00,0x02,0x00,0xff};
char ZMOVE[]={0xff,0x00,0x03,0x00,0xff};
char YMOVE[]={0xff,0x00,0x04,0x00,0xff};

int main(int argc, char *argv[])
{
    char buf[MAXLINE];
    int i=0;
    int sockfd = socket(AF_INET, SOCK_STREAM, 0);

    sockaddr_in servaddr = {0};
    servaddr.sin_family = AF_INET;
    inet_pton(AF_INET, argv[1], &servaddr.sin_addr);
    servaddr.sin_port = htons(SERV_PORT);

    if (0!= connect(sockfd, (sockaddr *)&servaddr, sizeof(servaddr)))
    {
        printf("connected failed");
        return 1;
    }
    if(strcmp("0",argv[2])==0)
	{
		write(sockfd, DOWN, sizeof(DOWN));
   		 printf("d %x",DOWN[0]);
	}
	if(strcmp("1",argv[2])==0)
	{
		
		write(sockfd, QMOVE, sizeof(QMOVE));
   		printf("q");
		
	}
	
   if(strcmp("2",argv[2])==0)
	{
		write(sockfd, HMOVE, sizeof(HMOVE));
   		 printf("h");
	}
	if(strcmp("3",argv[2])==0)
	{
		write(sockfd, ZMOVE, sizeof(ZMOVE));
   		 printf("z");
	}
	if(strcmp("4",argv[2])==0)
	{
		write(sockfd, YMOVE, sizeof(YMOVE));
   		 printf("y");
	}

    close(sockfd);
    return 0;
}
