#include <RP6RobotBaseLib.h>
#include "base.h"
#include <stdlib.h>

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

	UNKNOWN_COMMAND,			

	NO_COMMAND_TICK				
};

uint8_t ReadMessage(
	uint8_t * action /*ptr to action variable*/, 
	uint8_t * dataLen /*ptr to dataLen variable*/, 
	uint8_t * _data /*ptr to data variable*/, 
	uint8_t * possiblyCorrupt)
{
	const int min_message_len = 6;

	if (getBufferLength() >= min_message_len)
	{
		if (readChar() == '<')
		{
			if(readChar() == '{')
			{
				//Read action & data len
				*action = readChar();
				*dataLen = readChar();

				if (*dataLen)
				{
					if (*dataLen > 25)
					{
						*dataLen = 25;
					}

					while (getBufferLength() < *dataLen + 2 /* corruption check bytes */) { }

					if (*dataLen)
					{
						for (int i = 0; i < *dataLen; ++i)
						{
							_data[i] = readChar();
						}
					}
					_data[*dataLen] = 0;
				}

				//Corruption check
				*possiblyCorrupt = 0;
				*possiblyCorrupt |= readChar() != '}';
				*possiblyCorrupt |= readChar() != '>';

				return min_message_len + *dataLen;
			}
		}
	}
	return 0;
}

void WriteBareMessage(uint8_t action, uint8_t dataLen, uint8_t* _data)
{
	writeChar('<');
	writeChar('{');
	writeChar(action);
	writeChar(dataLen > 25 ? 25 : dataLen);
	for (int i = 0; i < dataLen; ++i)
	{
		writeChar(_data[i]);
	}
	writeChar('}');
	writeChar('>');
	writeChar(0);
}

uint8_t maximumspeed = 0;
int16_t speedL = 0;
int16_t speedR = 0;
uint8_t action = 0;
uint8_t dataLen = 0;
uint8_t possiblyCorrupt = 0;;
uint8_t data[58];

int main(void)
{
	initRobotBase();
	clearReceptionBuffer();
	startStopwatch1();

	while (true)
	{
		task_RP6System();

		if (ReadMessage(&action, &dataLen, data, &possiblyCorrupt))
		{
			WriteBareMessage(action, dataLen, data);

			if (possiblyCorrupt)
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
					uint8_t batteryLevel = readADC(adcBat) / 8;
					data[0] = batteryLevel;
					dataLen = 1;
					WriteBareMessage(action, dataLen, data);
				}
				break;

				case GET_MAXIMUM_SPEED:
				{
					data[0] = maximumspeed;
					dataLen = 1;
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

					if (dataLen == 1)
					{
						memcpy(&speed, data, sizeof(speed));

						if (abs(speed) > maximumspeed)
						{
							maximumspeed = abs(speed);
						}


						if (speed > 50)
						{
							speed = 50;
						}
						if (speed < -50)
						{
							speed = -50;
						}

						speed *= 4;

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
		else if (getStopwatch1() > 1000)
		{
			setStopwatch1(0);

			action = NO_COMMAND_TICK;
			dataLen = 0;

			WriteBareMessage(action, dataLen, data);
		}
	}
	return 0;
}