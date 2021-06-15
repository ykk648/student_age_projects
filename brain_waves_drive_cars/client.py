import socket
import time
import sys
#RPi's IP
SERVER_IP = "10.170.27.149"
SERVER_PORT = 21


print("Starting socket: TCP...")
server_addr = (SERVER_IP, SERVER_PORT)
socket_tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print("Connecting to server @ %s:%d..." %(SERVER_IP, SERVER_PORT)
socket_tcp.connect(server_addr)
        

socket_tcp.send(0xff000100ff)
socket_tcp.send(0xff000100ff)
socket_tcp.send(0xff000100ff)
sys.exit(1)