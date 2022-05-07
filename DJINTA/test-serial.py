#!/usr/bin/env python3
import time, serial, sys, io

if len(sys.argv) != 2:
    print("Invalid number of arguments")
    sys.exit()

ard = serial.Serial('/dev/ttyACM0', 9600)
ard.reset_input_buffer()
time.sleep(2)
ard.write(bytes(sys.argv[1], encoding='ascii'))
ard.flush()


