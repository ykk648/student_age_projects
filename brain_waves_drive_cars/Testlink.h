#ifndef _TESTLINK_H  
#define _TESTLINK_H  
  
#include <stdio.h>  
#include <stdlib.h>  
#include <unistd.h>  
#include <string.h>  
#include <errno.h>  
#include <sys/types.h>  
#include <sys/stat.h>  
#include <fcntl.h>  
#include <termios.h>  
  
#define BAUDRATE B57600 ///Baud rate : 57600  
#define DEVICE "/dev/ttyAMA0"  
#define SIZE 1024  
  
#endif  