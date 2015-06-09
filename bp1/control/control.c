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
			shouldDrive = !shouldDrive;
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
			moveAtSpeed(100, 100);
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
	ESL_AR = 0,//achter 
	ESL_AL = 1,//achter 
	ESL_VL = 2,//voor	
	ESL_VR = 3 //voor	
};

uint16_t sensorState[4];

void ProcessDistanceSensors()
{
	if (!isRotating && isDriving)
	{
		for (int i = 0; i < 4; ++i)
		{
			sensorState[i] = readADC(i + 2);
		}
	}
}

void ProcessRotation()
{
	if (isDriving)
	{
		if (!isRotating)
		{
			uint16_t min_dist_var = 200;
			uint8_t tooCloseRight = sensorState[ESL_AR] > min_dist_var || sensorState[ESL_VR] > min_dist_var;
			uint8_t tooCloseLeft = sensorState[ESL_AL] > min_dist_var || sensorState[ESL_VL] > min_dist_var;
			uint8_t dir = (tooCloseRight == tooCloseLeft) ? 0 : (tooCloseLeft ? LEFT : RIGHT);

			memset(sensorState, 0, sizeof(sensorState));
			lastState = 2;

			if (dir)
			{
				isRotating = 1;
				stop();
				rotate(100, dir, 60, NON_BLOCKING);
				waitForTransmitComplete();
				lastState = 3;
			}
		}
		else if (drive_status.movementComplete)
		{
			isRotating = 0;
			stop();
			changeDirection(FWD);
			waitForTransmitComplete();
			moveAtSpeed(100, 100);
			waitForTransmitComplete();
			lastState = 4;
		}
		else
		{
			task_checkINT0();
			task_I2CTWI();
		}
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
		ProcessDistanceSensors();
		ProcessRotation();

		setCursorPosLCD(0, 0);
		writeIntegerLCD(lastState, 10);
	}
	return 0;
}