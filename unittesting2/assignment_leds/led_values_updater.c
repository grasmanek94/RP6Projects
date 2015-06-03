#include "led_values_updater.h"

void led_values_update(uint8_t led_values, uint8_t* new_led_values_ptr)
{
	led_values = 
		(led_values == 0) ? 
			1 : 
			((led_values == 8) ? 
				0 : 
				led_values << 1);

	*new_led_values_ptr = led_values;
}

/*
	Scenario	led_values		Expected value voor new_led_values_ptr
	1			0b0000			0b0001
	2			0b0001			0b0010
	3			0b0010			0b0100
	4			0b0100			0b1000
	5			0b1000			0b0000
*/