#include <RP6ControlLib.h>
#include "control.h"

int main(void)
{
	setup();
	while(true) 
	{
		loop();
	}
	return 0;
}

void setup(void)
{
	initRP6Control();
}

void loop(void)
{

}