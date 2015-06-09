#include <RP6ControlLib.h>
#include <someCommonLib.h>
#include "control.h"
#include "ringbuf.h"

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
	initRP6Control();
}

void loop(void)
{
  // correctly otherwise. 
	initLCD();
	mSleep(400);
	setLEDs(0b0000);

	showScreenLCD("ES22 - Week 6", "Rafal & Yop");
	mSleep(1000);

	DDRA &= ~ADC3;
	clearLCD();

	while (true) 
	{

		writeStringLCD("Value: ");
		writeIntegerLCD(readADC(ADC_3), 100);
		setCursorPosLDC(1, 0);
		writeStringLCD("Moving Average: ");
		writeIntegerLCD(readADC(ADC_3), 100);


		mSleep(500);
	}
	return 0;
}
