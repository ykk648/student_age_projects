#ifndef _TESTSEND_H  
#define _TESTSEND_H  
  
#include <stdio.h>  
#include <stdlib.h>  
#include <unistd.h>  
#include <string.h>  
#include <errno.h>  
#include <sys/types.h>  
#include <sys/stat.h>  
#include <fcntl.h>  
#include <termios.h>  
  
#define BAUDRATE B38400 ///Baud rate : 57600  
#define DEVICE "/dev/ttyAMA0"  
#define SIZE 1024  
  
#endif  