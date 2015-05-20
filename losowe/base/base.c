#include <RP6RobotBaseLib.h>
#include <someCommonLib.h>
#include "base.h"

int main(void)
{
	setup();
	someCommonFunction();
	while (true)
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

enum currentState
{
	stateMovingBackwardsL,
	stateMovingBackwardsR,
	stateRotating,
	stateMovingForward
};

void loop(void)
{
	task_RP6System();

	static uint8_t state = stateMovingForward;

	uint8_t bLeft = getBumperLeft();
	uint8_t bRight = getBumperRight();

	if (
		(state == stateMovingForward || state == stateMovingBackwardsR || state == stateMovingBackwardsL) 
		&& (bLeft || bRight)
		)
	{
		stop();
		move(255, BWD, DIST_MM(50), NON_BLOCKING);
		state = bLeft ? stateMovingBackwardsR : stateMovingBackwardsL;
	}

	if (isMovementComplete())
	{
		switch (state)
		{
			case stateRotating:
				stop();
				state = stateMovingForward;
				break;
			case stateMovingForward:
				moveAtSpeedDirection(127, 127);
				break;
			case stateMovingBackwardsR:
			case stateMovingBackwardsL:
				rotate(120, state == stateMovingBackwardsR ? RIGHT : LEFT, 40.0, NON_BLOCKING);
				state = stateRotating;
				break;
		}
	}
}