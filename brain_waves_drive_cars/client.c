#include <sys/socket.h>
#include <string.h>
#include <stdio.h>
#include <errno.h>
#include <netinet/in.h>
#include <stdlib.h>
#include <arpa/inet.h>
 
#define SERV_PORT 2001
#define BUFF_SIZE 1024
 
int main(int argc,char *argv[])
{
    int sockfd = socket(AF_INET,SOCK_STREAM,0);
    if(sockfd == -1)
        perror(strerror(errno));
     
    struct sockaddr_in servaddr;
    memset(&servaddr,0,sizeof(servaddr));
    servaddr.sin_family = AF_INET;
    servaddr.sin_port = htons(SERV_PORT);
    inet_aton("192.168.1.108",&servaddr.sin_addr);
    if(connect(sockfd,(struct sockaddr*)&servaddr,sizeof(servaddr)) == -1)
        perror(strerror(errno)),exit(0);
    printf("conected\n");
         
    
 
    return 0;
}
