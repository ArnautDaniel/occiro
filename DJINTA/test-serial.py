#!/usr/bin/env python3
import time, serial, sys

if len(sys.argv) != 2:
    print("Invalid number of arguments")
    sys.exit()

ard = serial.Serial("/dev/ttyACM0", 9600)
ard.reset_input_buffer()
ard.write(bytes(sys.argv[1]))
time.sleep(5)
