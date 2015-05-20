#include <RP6RobotBaseLib.h>
#include <someCommonLib.h>
#include "base.h"

int main(void)
{
	setup();
	someCommonFunction();
	while(true) 
	{
		loop();
	}
	return 0;
}

void setup(void)
{
	initRobotBase();
	powerON();
}

void tasks(void)
{
	task_motionControl();
	task_ADC();
	task_ACS();
	task_Bumpers();
	task_RP6System();
}

void loop(void)
{
	tasks();
	move(255, FWD, DIST_MM(700), BLOCKING);
	rotate(255, RIGHT, 180.0, BLOCKING);
}