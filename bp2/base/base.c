#include <RP6RobotBaseLib.h>
#include <someCommonLib.h>
#include "base.h"

#define RECEIVE_BUFFER_SIZE 101

void SendDataOverUART(int value)
{
	// These functions send data over the UART
	writeString_P("Counter: ");

	writeInteger(value, DEC);
	writeString_P("(DEC) | ");

	writeInteger(value, HEX);
	writeString_P("(HEX) | ");

	writeInteger(value, BIN);
	writeString_P("(BIN) ");

	writeChar('\n'); // New Line
}

void ShowDataReceivedOverUART(void)
{
	char receiveBuffer[RECEIVE_BUFFER_SIZE];
	uint8_t nrOfCharsReceived = getBufferLength();

	// check if no data was received
	if (nrOfCharsReceived == 0) return;

	int index = 0;
	while (getBufferLength() > 0) {
		receiveBuffer[index] = readChar();
		index++;

		//- reserve the last character of the buffer for '\0' character
		//- check not to write outside array boundaries.	
		if (index > (RECEIVE_BUFFER_SIZE - 2))
		{
			break;
		}
	}

	receiveBuffer[index] = '\0';

	writeString_P("Echo: ");
	writeString(receiveBuffer);
}

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
	initRobotBase(); // Always call this first! 
					 // The Processor will not work correctly otherwise.

					 // Write a text message to the UART:
	writeString_P("\nCounting and Receiving\n");

	// Define a counting variable:
	uint16_t counter = 0;

	// clear the UART buffer once at the start of the program
	clearReceptionBuffer();
}

void loop(void)
{
	// example of sending some data over UART
	counter++;
	SendDataOverUART(counter);

	//example of receiving some data over UART
	ShowDataReceivedOverUART();

	mSleep(100); // delay 100ms = 0.1s
}