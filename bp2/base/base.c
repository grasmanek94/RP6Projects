#include <RP6RobotBaseLib.h>
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

typedef struct 
{
	uint8_t begin[2];
	uint8_t end[2];
	uint8_t action;
	uint8_t dataLen;
	uint8_t data[59];
	uint8_t possiblyCorrupt;
} SMessage;

void InitMessage(SMessage* message)
{
	message->begin[0] = '{';
	message->begin[1] = '{';
	message->end[0] = '}';
	message->end[1] = '}';
}

//returns the ammount of data that has been succesfully read
uint8_t ReadMessage(SMessage* message)
{
	if (getBufferLength() > 5 &&
		readChar() == message->begin[0] &&
		readChar() == message->begin[1])
	{
		//Read action & data lenght
		message->action = readChar();
		message->dataLen = readChar();
		if (message->dataLen > 58)
		{
			message->dataLen = 58;
		}

		while (getBufferLength() < message->dataLen) {}

		readChars((char*)message->data, message->dataLen);
		message->data[message->dataLen] = 0;

		//Corruption check
		uint8_t corruptioncheck[2];
		readChars((char*)&corruptioncheck, 2);

		message->possiblyCorrupt = corruptioncheck[0] != message->end[0] || corruptioncheck[1] != message->end[1];

		return 6 + message->dataLen;
	}
	return 0;
}

char * ReadString(SMessage* message)
{
	if (ReadMessage(message))
	{
		return (char*)message->data;
	}
	return 0;
}

//returns the amount of bytes succesfully written
uint8_t WriteMessage(SMessage* message)
{
	writeStringLength((char*)message->begin, 2, 0);
	writeChar(message->action);
	writeChar(message->dataLen);
	writeStringLength((char*)message->data, message->dataLen, 0);
	writeStringLength((char*)message->end, 2, 0);
	return 6 + message->dataLen;
}

uint8_t WriteString(SMessage* message, char * str)
{
	message->dataLen = strlen(str) + 1;
	memcpy(message->data, str, message->dataLen);
	return WriteMessage(message);
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

SMessage message;

int16_t maximumspeed = 0;

int16_t speedL = 0;
int16_t speedR = 0;

void setup(void)
{
	initRobotBase(); // Always call this first! 
					 // The Processor will not work correctly otherwise.

	// clear the UART buffer once at the start of the program
	clearReceptionBuffer();

	InitMessage(&message);
}

void loop(void)
{
	if (ReadMessage(&message))
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

					WriteMessage(&message);
				}
				break;

				case GET_MAXIMUM_SPEED:
				{
					memcpy(message.data, &maximumspeed, sizeof(maximumspeed));
					message.dataLen = sizeof(maximumspeed);

					WriteMessage(&message);
				}
				break;

				case RESET_MAX_SPEED:
				{
					maximumspeed = 0;

					message.dataLen = 0;
					message.action = COMMAND_EXECUTION_SUCCESS;

					WriteMessage(&message);
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

					WriteMessage(&message);
				}
				break;

				case MOTOR_STOP:
				{
					speedL = 0;
					speedR = 0;

					moveAtSpeedDirection(speedL, speedR);

					message.action = COMMAND_EXECUTION_SUCCESS;
					message.dataLen = 0;

					WriteMessage(&message);

				}
				break;

				default:
				{
					message.action = UNKNOWN_COMMAND;
					message.dataLen = 0;

					WriteMessage(&message);
				}
				break;
			}
		}
		else
		{
			message.action = MESSAGECORRUPTION_OCCURED;
			message.dataLen = 0;

			WriteMessage(&message);
		}
	}
}