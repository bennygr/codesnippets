#!/bin/bash
#building the test code as dynamic shared library
g++ -fPIC -Wall -shared -o libhello.so helloworld.cpp

