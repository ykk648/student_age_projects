 #-*-coding:utf-8-*-
 #python 2.7
 import serial
 import time


    ser=serial.Serial('/dev/ttyAMA0','38400')
    status=ser.isOpen()
    print status

    def Transaction(requst,response,ser):
    while True:
        ser.write(requst)
        print 'send:'+requst
        n=ser.inWaiting()
        response_2=ser.read(n)
        print response_2
        print len(response_2)
        raw_input('press any key to continue')
        if response_2==response:
            break

    #Testing
    while True:
        ser.write('AT\r\n')
        print 'send requst...'
        n=ser.inWaiting()
        response=ser.read(n)
        print response
        print len(response)
        raw_input('press any key to continue')
        if response=='OK\r\n':
            break


    #set the mode of the Device
    while True:
        print 'set at the mode of master...'
        ser.write('AT+ROLE=1\r\n')
        response=ser.read(4)
        print response
        raw_input('press any key to continue')
        if response=='OK\r\n':
            break


    #Set the mode of query #0--bind mode 1--any 2--loop
    print 'Set the mode of query'
    Transaction('AT+CMODE=0\r\n','OK\r\n',ser)
    #Bind the Addr
    print 'Bind the Addr'
    Addr='80BA,86,6CE14B'
    Transaction('AT+BIND='+Addr+'\r\n','OK\r\n',ser)

    #Set the pw
    print 'Set the pw'
    pw='0000'
    Transaction('AT+PSWD='+pw+'\r\n','OK\r\n',ser)

    #Set the parameter of the UART # baud,stopbits,cntl         #stopbits--0:11:2cntl--0:none 1:odd 2:even
    print 'Set the parameter of the UART'
    UART='57600,0,0'
    Transaction('AT+UART='+UART+'\r\n','OK\r\n',ser)

    ser.close()