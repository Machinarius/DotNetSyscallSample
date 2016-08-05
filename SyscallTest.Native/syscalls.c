#include <unistd.h>
#include <sys/syscall.h>
#include <errno.h>
#include <stdio.h>

int __attribute__ ((visibility ("default"))) chmodsc(char* filename, int mask) 
{
	int callResult;
	callResult = syscall(SYS_chmod, filename, mask);
	return callResult;
}
