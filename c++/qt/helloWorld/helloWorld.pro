TEMPLATE = app
TARGET = hello_World

QT = core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets
SOURCES += \
    helloWorld.cpp

