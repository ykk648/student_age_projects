#include <stdio.h>
#include "ThinkGearStreamParser.h"
#include "Movtion.h"
#include <pthread.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>

int funvalue[2];
char ip[128];

void
handleDataValueFunc(unsigned char extendedCodeLevel,unsigned char code,unsigned char valueLength,const unsigned char *value,void *customData) 
{
	int i = 0;
	if (extendedCodeLevel == 0) {
		switch (code) {
			/* [CODE]: ATTENTION eSense */
		case(0x04) :
			funvalue[0]=value[0] & 0xFF;
			printf("Attention Level: %d\n", value[0] & 0xFF);
			break;
			/* [CODE]: MEDITATION eSense */
		case(0x05) :
			funvalue[1]=value[0] & 0xFF; 
			printf("Meditation Level: %d\n", value[0] & 0xFF);
			break;
			/* Other [CODE]s */
		case(0x02) :
			printf("PQ Level: %d\n", value[0] & 0xFF);
			break;
			/* Other [CODE]s */


		default:
			//printf("EXCODE level: %d CODE: 0x%02X vLength: %d\n",
			//	extendedCodeLevel, code, valueLength);
			//printf("Data value(s):");
			//for (i = 0; i<valueLength; i++) printf(" %02X", value[i] & 0xFF);
			//printf("\n");
			;
		}
	}
} 

void *deal_thread(void *ptr)
{
	while(1){
		if(funvalue[0]>90)
		{
			Movtion(ip,"1");
			
		}
		else if(funvalue[0]>30&&funvalue[0]<60)
		{
			Movtion(ip,"3");
			
		}
		else if(funvalue[0]>60&&funvalue[0]<90)
		{
			Movtion(ip,"4");
			
		}
		else if(funvalue[0]>0&&funvalue[0]<30)
		{
			Movtion(ip,"2");
			
		}
		else
		{
			Movtion(ip,"0");
			
		}
		
	}
	pthread_exit(NULL);
}
void *deal_thread1(void *ptr)
{
	/* 2) Initialize ThinkGear stream parser */
	ThinkGearStreamParser parser;
	FILE *stream;
	stream=fopen("/dev/ttyAMA0","r");
	THINKGEAR_initParser(&parser, PARSER_TYPE_PACKETS,handleDataValueFunc, NULL);
	/* TODO: Initialize 'stream' here to read from a serial data
	* stream, or whatever stream source is appropriate for your
	* application. See documentation for "Serial I/O" for your
	* platform for details.
	*/
	/* 3) Stuff each byte from the stream into the parser. Every time
	* a Data Value is received, handleDataValueFunc() is called.
	*/
	
	unsigned char streamByte;
	while (1) {
		fread(&streamByte, 1, 1,stream);
		THINKGEAR_parseByte(&parser, streamByte);
		
		
	}
	pthread_exit(NULL);
}



int
main(int argc, char **argv) 
{
	
	
	strcpy(ip,argv[1]);
	printf("%s",ip);
	pthread_t id,id1;
	int ret,ret1;
	ret=pthread_create(&id,NULL,deal_thread,NULL);
	ret1=pthread_create(&id1,NULL,deal_thread1,NULL);
	printf("%d",ret);
	if(ret!=0)
	{
		printf("Creat thread error");
	}
	else	
	{
		printf("Creat thread over");
	}
	if(ret1!=0)
	{
		printf("Creat thread1 error");
	}
	else	
	{
		printf("Creat thread1 over");
	}
    	pthread_join(id,NULL);
	pthread_join(id1,NULL);
	
	
	return 0; 
}

