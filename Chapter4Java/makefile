#
# Makefile for Chapter4Java
#
SRCS = $(wildcard Controller/Controller.java Program.java)
CLS = $(SRCS:.java=.class)

all:
	javac -classpath . $(SRCS) -d .

clean:
	$(RM) $(CLS)
