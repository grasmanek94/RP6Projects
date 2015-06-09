#include <RP6ControlLib.h>
#include <someCommonLib.h>
#include <RP6I2CmasterTWI.h>
#include "RP6Control_I2CMasterLib.h"
#include "control.h"

#include "ringbuf.h"
#include <string.h>

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

const int weight = 64;//gewicht
#define maxAverages (2)

unsigned long	*movingAverage	[maxAverages];
unsigned long	previousAverage	[maxAverages];
int				ADCsToRead		[maxAverages] = { ADC_3, ADC_4 };

int insertedElems = 0;

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

void setup(void)
{	
	initRP6Control();

	I2CTWI_initMaster(100);
	I2CTWI_setRequestedDataReadyHandler(I2C_requestedDataReady);
	I2CTWI_setTransmissionErrorHandler(I2C_transmissionError);

	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_ACS_POWER, ACS_PWR_MED);
	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_WDT, true);
	I2CTWI_transmit3Bytes(I2C_RP6_BASE_ADR, 0, CMD_SET_WDT_RQ, true);

	changeDirection(FWD);
	waitForTransmitComplete();

	for (int i = 0; i < maxAverages; ++i)
	{
		movingAverage[i] = malloc(weight * sizeof(unsigned long));
	}
}

void ProcessAverages()
{
	for (int i = 0; i < maxAverages; ++i)
	{
		movingAverage[i][insertedElems] = readADC(ADCsToRead[i]);
	}

	if (++insertedElems == weight)
	{
		insertedElems = 0;
		for (int i = 0; i < maxAverages; ++i)
		{
			previousAverage[i] = 0;
			for (int j = 0; j < weight; ++j)
			{
				previousAverage[i] += movingAverage[i][j];
			}
			previousAverage[i] /= weight;
		}
	}
}

int powerRechts;
int powerLinks;
float error;

void ProcessDisplay()
{
	if (getStopwatch1() >= 500)
	{
		setStopwatch1(0);

		clearLCD();

		setCursorPosLCD(0, 0);

		writeStringLCD("L");
		writeIntegerLCD(powerLinks, 10);
		writeStringLCD(" R");
		writeIntegerLCD(powerRechts, 10);
		writeStringLCD(" E");
		writeIntegerLCD((int)(error * 100.0), 10);
		
		setCursorPosLCD(1, 0);

		writeIntegerLCD(movingAverage[0][insertedElems], 10);
		writeStringLCD("/");
		writeIntegerLCD(previousAverage[0], 10);
		writeStringLCD(" ");
		writeIntegerLCD(movingAverage[1][insertedElems], 10);
		writeStringLCD("/");
		writeIntegerLCD(previousAverage[1], 10);
	}
}

void ProcessDriving()
{
	const int wantedDistance = 350;
	const float verschuiving = 0.22;
	error = (verschuiving - ((float)(wantedDistance - previousAverage[1]) / 600.0));
	if ((int)(error*100.0) > 22)//otherwise it doesnt work -- if(error > 0.22)
	{
		error = verschuiving;
	}
	if (error < -verschuiving)
	{
		error = -verschuiving;
	}
	float voor = (float)previousAverage[1];
	float achter = (float)previousAverage[0];

	powerRechts = (int)(127.0 * (voor / achter) * (1.0 + error));
	powerLinks = (int)(127.0 * (achter / voor) * (1.0 - error));
	
	moveAtSpeed(powerLinks, powerRechts);
}

void loop(void)
{
	initLCD();
	showScreenLCD("ES22 - Week 6", "Rafal & Yop");
	DDRA &= ~ADC3;

	startStopwatch1();

	while (true) 
	{
		ProcessAverages();
		ProcessDisplay();
		ProcessDriving();
	}
}
