/*
 * level_check.c
 *
 *  Created on: 22 nov. 2012
 *      Author: ben
 */

#include "level_check.h"

bool is_level_detected(uint16_t measured_level, uint16_t threshold_level)
{
	return measured_level > threshold_level;
}
/*
Scenario	measured_level	threshold_level		Expected return value
1			100				100					false
2			101				100					true
*/