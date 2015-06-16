#include <RP6RobotBaseLib.h>
#include "message.hxx"
#include "base.h"

enum Actions
{
	GET_BATTERY_LEVEL = 1,

	SET_MOTOR_L_SPEED,
	SET_MOTOR_R_SPEED,

	MOTOR_STOP,

	GET_MAXIMUM_SPEED,

	RESET_MAX_SPEED,

	COMMAND_EXECUTION_SUCCESS,
	COMMAND_EXECUTION_FAILURE,

	MESSAGECORRUPTION_OCCURED,

	UNKNOWN_COMMAND
};

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
	initRobotBase(); // Always call this first! 
					 // The Processor will not work correctly otherwise.

	// clear the UART buffer once at the start of the program
	clearReceptionBuffer();
}

Message message;

int16_t maximumspeed = 0;

int16_t speedL = 0;
int16_t speedR = 0;

void loop(void)
{
	if (message.Read())
	{
		if(!message.possiblyCorrupt)
		{
			switch (message.action)
			{
				case GET_BATTERY_LEVEL:
				{
					float batteryLevel = ((float)readADC(adcBat) / 1024.0f) * 100.0f;

					memcpy(message.data, &batteryLevel, sizeof(batteryLevel));
					message.dataLen = sizeof(batteryLevel);

					message.Write();
				}
				break;

				case GET_MAXIMUM_SPEED:
				{
					memcpy(message.data, &maximumspeed, sizeof(maximumspeed));
					message.dataLen = sizeof(maximumspeed);

					message.Write();
				}
				break;

				case RESET_MAX_SPEED:
				{
					maximumspeed = 0;

					message.dataLen = 0;
					message.action = COMMAND_EXECUTION_SUCCESS;

					message.Write();
				}
				break;

				case SET_MOTOR_L_SPEED:
				case SET_MOTOR_R_SPEED:
				{
					int16_t speed = 0;

					if (message.dataLen == sizeof(speed))
					{
						memcpy(&speed, message.data, sizeof(speed));

						if (abs(speed) > maximumspeed)
						{
							maximumspeed = abs(speed);
						}

						if (message.action == SET_MOTOR_L_SPEED)
						{
							speedL = speed;
						}
						else
						{
							speedR = speed;
						}

						moveAtSpeedDirection(speedL, speedR);

						message.action = COMMAND_EXECUTION_SUCCESS;
					}
					else
					{
						message.action = COMMAND_EXECUTION_FAILURE;
					}

					message.dataLen = 0;

					message.Write();
				}
				break;

				case MOTOR_STOP:
				{
					speedL = 0;
					speedR = 0;

					moveAtSpeedDirection(speedL, speedR);

					message.action = COMMAND_EXECUTION_SUCCESS;
					message.dataLen = 0;

					message.Write();

				}
				break;

				default:
				{
					message.action = UNKNOWN_COMMAND;
					message.dataLen = 0;

					message.Write();
				}
				break;
			}
		}
		else
		{
			message.action = MESSAGECORRUPTION_OCCURED;
			message.dataLen = 0;

			message.Write();
		}
	}
}