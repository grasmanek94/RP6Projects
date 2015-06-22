#include <RP6RobotBaseLib.h>
#include "base.h"
#include <stdlib.h>

enum Actions
{
	GET_BATTERY_LEVEL = 1,		//B

	SET_MOTOR_L_SPEED,			//C
	SET_MOTOR_R_SPEED,			//D

	MOTOR_STOP,					//E

	GET_MAXIMUM_SPEED,			//F

	RESET_MAX_SPEED,			//G

	COMMAND_EXECUTION_SUCCESS,	//H
	COMMAND_EXECUTION_FAILURE,	//I

	MESSAGECORRUPTION_OCCURED,	//J

	UNKNOWN_COMMAND,			//K

	NO_COMMAND_TICK				//L
};

uint8_t ReadMessage(uint8_t * action /*ptr to action variable*/, uint8_t * dataLen /*ptr to dataLen variable*/, uint8_t * _data /*ptr to data variable*/, uint8_t * possiblyCorrupt)
{
	if (getBufferLength() > 5 &&
		readChar() == '<' &&
		readChar() == '{')
	{
		//Read action & data lenght
		*action = readChar() - 'A';
		*dataLen = readChar() - 'A';
		if (*dataLen > 25)
		{
			*dataLen = 25;
		}

		while (getBufferLength() < *dataLen) {}

		if (*dataLen)
		{
			for (int i = 0; i < *dataLen; ++i)
			{
				_data[i] = readChar();
			}
		}
		_data[*dataLen] = 0;

		//Corruption check
		while (getBufferLength() < 2) {}

		*possiblyCorrupt = 0;
		*possiblyCorrupt |= readChar() != '}';
		*possiblyCorrupt |= readChar() != '>';

		return 6 + *dataLen;
	}
	return 0;
}

uint8_t tosend[36];
void WriteBareMessage(uint8_t action, uint8_t dataLen, uint8_t* _data)
{
	int i = 0;
	tosend[i++] = '<';
	tosend[i++] = '{';
	tosend[i++] = 'A' + action;
	tosend[i++] = 'A' + dataLen > 25 ? 25 : dataLen;
	for (int j = 0; j < dataLen; ++j)
	{
		tosend[i++] = _data[j];
	}
	tosend[i++] = '}';
	tosend[i++] = '>';
	tosend[i++] = 0;
	writeStringLength(tosend, 7 + dataLen, 0);
}

int main(void)
{
	setup();
	while(true) 
	{
		loop();
	}
	return 0;
}

int16_t maximumspeed = 0;

int16_t speedL = 0;
int16_t speedR = 0;

void setup(void)
{
	initRobotBase(); // Always call this first! 
					 // The Processor will not work correctly otherwise.

	// clear the UART buffer once at the start of the program
	clearReceptionBuffer();

	startStopwatch1();
}

uint8_t action = 0;
uint8_t dataLen = 0;
uint8_t possiblyCorrupt = 0;;
uint8_t data[58];

void loop(void)
{
	task_RP6System();

	if (ReadMessage(&action, &dataLen, data, &possiblyCorrupt))
	{
		WriteBareMessage(action, dataLen, data);

		if(possiblyCorrupt)
		{
			action = MESSAGECORRUPTION_OCCURED;
			dataLen = 0;
		
			WriteBareMessage(action, dataLen, data);
		}
		else
		{
			switch (action)
			{
				case GET_BATTERY_LEVEL:
				{
					float batteryLevel = ((float)readADC(adcBat) / 1024.0f) * 100.0f;

					memcpy(data, &batteryLevel, sizeof(batteryLevel));
					dataLen = sizeof(batteryLevel);

					WriteBareMessage(action, dataLen, data);
				}
				break;

				case GET_MAXIMUM_SPEED:
				{
					memcpy(data, &maximumspeed, sizeof(maximumspeed));
					dataLen = sizeof(maximumspeed);

					WriteBareMessage(action, dataLen, data);
				}
				break;

				case RESET_MAX_SPEED:
				{
					maximumspeed = 0;

					dataLen = 0;
					action = COMMAND_EXECUTION_SUCCESS;

					WriteBareMessage(action, dataLen, data);
				}
				break;

				case SET_MOTOR_L_SPEED:
				case SET_MOTOR_R_SPEED:
				{
					int16_t speed = 0;

					if (dataLen == sizeof(speed))
					{
						memcpy(&speed, data, sizeof(speed));

						if (abs(speed) > maximumspeed)
						{
							maximumspeed = abs(speed);
						}

						
						if (speed > 200)
						{
							speed = 200;
						}
						if (speed < -200)
						{
							speed = -200;
						}

						if (action == SET_MOTOR_L_SPEED)
						{
							speedL = speed;
						}
						else
						{
							speedR = speed;
						}

						setMotorDir(speedL >= 0 ? FWD : BWD, speedR >= 0 ? FWD : BWD);

						moveAtSpeed(speedL, speedR);

						action = COMMAND_EXECUTION_SUCCESS;
					}
					else
					{
						action = COMMAND_EXECUTION_FAILURE;
					}

					dataLen = 0;

					WriteBareMessage(action, dataLen, data);
				}
				break;

				case MOTOR_STOP:
				{
					speedL = 0;
					speedR = 0;

					moveAtSpeedDirection(speedL, speedR);

					action = COMMAND_EXECUTION_SUCCESS;
					dataLen = 0;

					WriteBareMessage(action, dataLen, data);

				}
				break;

				default:
				{
					action = UNKNOWN_COMMAND;
					dataLen = 0;

					WriteBareMessage(action, dataLen, data);
				}
				break;
			}
		}
	}
	else if(getStopwatch1() > 1000)
	{
		setStopwatch1(0);

		//action = NO_COMMAND_TICK;
		//dataLen = 0;

		//WriteBareMessage(action, dataLen, data);

		//float batteryLevel = ((float)readADC(adcBat) / 1024.0f) * 100.0f;

		//memcpy(data, &batteryLevel, sizeof(batteryLevel));
		//dataLen = sizeof(batteryLevel);

		//WriteBareMessage(action, dataLen, data);

		//memcpy(data, &maximumspeed, sizeof(maximumspeed));
		//dataLen = sizeof(maximumspeed);

		//WriteBareMessage(action, dataLen, data);
	}
}