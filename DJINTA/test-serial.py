#!/usr/bin/env python3
import time
import serial
import random
ser = serial.Serial('/dev/ttyACM0', 9600)
ser.reset_input_buffer()
ser.write(b'20000')
time.sleep(5)
ser.write(b'40000')
