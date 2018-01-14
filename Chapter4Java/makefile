#
# Makefile for Chapter4Java
#


SRCS = $(wildcard Controller/Controller.java Program.java BusinessLayer/*.java DAL/*.java Models/*.java View/*.java)


all:
	javac -classpath . $(SRCS) -d .

#since I want all the compiled files in the same directory, I need to keep
#adding the <classname>.class filenames as an argument to rm as they are created 
.PHONY : clean
clean:
	rm -f Controller.class Program.class BarNight.class MenuAction.class IRepository.class
