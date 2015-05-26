#include <RP6ControlLib.h>
#include <someCommonLib.h>
#include "control.h"
#include <RP6I2CmasterTWI.h>
#include "RP6Control_I2CMasterLib.h"

uint8_t isDriving = 0;
uint8_t shouldDrive = 0;
uint8_t isRotating = 0;
uint8_t lastState = 9;

void ProcessStartStop()
{
	if (!isStopwatch7Running())
	{
		startStopwatch7();
	}

	if (getStopwatch7() > 100)
	{
		setStopwatch7(0);
	
		uint16_t micpeak = getMicrophonePeak();

		if (micpeak > 768)
		{
			dischargePeakDetector();
			shouldDrive ^= 1;
		}
	
		writeInteger(micpeak, 10);
		writeChar('\n');
	}
}

void ProcessDriving()
{
	if (shouldDrive != isDriving)
	{
		isDriving = shouldDrive;
		if (shouldDrive && !isRotating)
		{			
			stop();
			changeDirection(FWD);
			waitForTransmitComplete();
			moveAtSpeed(255, 255);
			waitForTransmitComplete();
			lastState = 1;
		}
		else if(!shouldDrive)
		{		
			isRotating = 0;
			stop();	
			lastState = 0;
		}
	}
}

enum ESensorLocation
{
	ESL_AL = 0,//achter links
	ESL_AR = 1,//achter rechts
	ESL_VR = 2,//voor	rechts
	ESL_VL = 3 //voor	links
};

uint8_t sensorState[4];

void ProcessDistanceSensors()
{
	if (!isRotating)
	{
		for (int i = 2; i < 6; ++i)
		{
			if (!sensorState[i - 2])
			{	//read & set only when sensor isn't already 'too close', let someone else reset the state
				sensorState[i - 2] = readADC(i) < 300;
			}
		}
	}
}

void ProcessRotation()
{
	if (!isRotating)
	{
		uint8_t tooCloseRight = sensorState[ESL_AL] || sensorState[ESL_VL];
		uint8_t tooCloseLeft = sensorState[ESL_AR] || sensorState[ESL_VR];
		uint8_t dir = (tooCloseRight == tooCloseLeft) ? 0 : (tooCloseLeft ? RIGHT : LEFT);
		memset(sensorState, 0, sizeof(sensorState));
		lastState = 2;

		if (dir)
		{
			isRotating = 1;
			stop();
			rotate(255, dir, 60, NON_BLOCKING);
			waitForTransmitComplete();
			lastState = 3;
		}
	}
	else if(drive_status.movementComplete)
	{
		isRotating = 0;
		stop();
		changeDirection(FWD);
		waitForTransmitComplete();
		moveAtSpeed(255, 255);
		waitForTransmitComplete();
		lastState = 4;
	}
}

void I2C_requestedDataReady(uint8_t dataRequestID)
{
	checkRP6Status(dataRequestID);
}

void I2C_transmissionError(uint8_t errorState)
{
	writeString_P("\nI2C ERROR - TWI STATE: 0x");
	writeInteger(errorState, HEX);
	writeChar('\n');
}

int main(void)
{
	initRP6Control();
	initLCD();

	I2CTWI_initMaster(100);
	I2CTWI_setRequestedDataReadyHandler(I2C_requestedDataReady);
	I2CTWI_setTransmissionErrorHandler(I2C_transmissionError);

	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_ACS_POWER, ACS_PWR_MED);
	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_WDT, true);
	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_WDT_RQ, true);

	while (true) 
	{
		ProcessStartStop();
		ProcessDriving();
		if (isDriving)
		{
			ProcessDistanceSensors();
			ProcessRotation();
		}

		setCursorPosLCD(0, 0);
		writeIntegerLCD(lastState, 10);
	}
	return 0;
}


/*
Here we will show how to set and read I/O pins.

You need to change this and add your own routines
for the specific hardware you want to control!

The 14 free I/O Pins are the following ones (definitions from RP6Control.h):

ADC7 	(1 << PINA7)
ADC6	(1 << PINA6)
ADC5 	(1 << PINA5)
ADC4 	(1 << PINA4)
ADC3 	(1 << PINA3)
ADC2 	(1 << PINA2)
IO_PC7 	(1 << PINC7)
IO_PC6 	(1 << PINC6)
IO_PC5 	(1 << PINC5)
IO_PC4 	(1 << PINC4)
IO_PC3 	(1 << PINC3)
IO_PC2 	(1 << PINC2)
IO_PD6 	(1 << PIND6)
IO_PD5 	(1 << PIND5)

ADC2 - 7 are useable as I/Os or as Analog/Digital Converter Channels.
IO_PC2 - 7 and IO_PD5 and IO_PD6 are only useable as I/Os.

So you have free pins on PORTA, C and D.

Please note the small difference in spelling ADC Channels and I/Os
(ADC_7 vs. ADC7)



// When you want to use a port pin as output, you have to set the 
// DDRx register bit belonging to this port to 1. 
//
// For example - if you want to use PORTC 7 as output, you can write:

DDRC |= IO_PC7;  // PC7 is output

				 // And then you can set the Port to high or low:


PORTC |= IO_PC7;  // High
writeString_P("\nPC7 is set to HIGH!\n\n");
mSleep(1000);	  // wait 1s for example... 
PORTC &= ~IO_PC7; // Low
writeString_P("\nPC7 is set to LOW!\n\n");

// When you want to use the Port as input to read its value,
// you need to clear the DDRx register bit. 

DDRC &= ~IO_PC6;  // PC6 is input

PORTC |= IO_PC6;     // enable internal pullup resistor of PC6  OR ALTERNATIVELY:
					 // PORTC &= ~IO_PC6  // disable pullup resistor of PC6
					 // You need this when external sensors only pull the signal low
					 // for example or if you disconnect the sensors or ... 

					 // Now we want to output something depending on if this port pin is 
					 // high or low:
writeString_P("\nCheck PC6:");
if (PINC & IO_PC6) // Check if PC6 is high
writeString_P("\n\nPC6 is HIGH!\n\n");
else
writeString_P("\n\nPC6 is LOW!\n\n");


// Hints for DDRx and PORTx Registers:
// DDRx = 0 and PORTx = 0 ==> Input without internal Pullup
// DDRx = 0 and PORTx = 1 ==> Input with internal Pullup
// DDRx = 1 and PORTx = 0 ==> Output low
// DDRx = 1 and PORTx = 1 ==> Output high
// "=1" indicates that the appropriate bit is set.


// To read the ADC channels, you can use the readADC() function. 
// First you have to make the pins INPUTs, of course:
DDRA &= ~ADC7;
DDRA &= ~ADC2;


// When you run this program with nothing connected
// to the ADCs, you will most likely measure only junk
// data - for example the ADC could show 210 or 623 or
// anything else randomly. 

// -------------------------------------------

dischargePeakDetector();

while (true)
{

	for (int i = 0; i < 8; ++i)
	{
		writeInteger(i, DEC);
		writeString_P(": ");
		uint16_t val = readADC(i);
		if (val < 1000)
		{
			if (val > 99)
			{
				writeString_P("0");
			}
			else if (val > 9)
			{
				writeString_P("00");
			}
			else
			{
				writeString_P("000");
			}
		}
		writeInteger(val, DEC);
		writeString(" | ");
	}
	writeChar('\n');
	mSleep(500);
}

*/