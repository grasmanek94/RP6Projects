/*
 * led_value_updater_test.c
 *
 *  Created on: 22 nov. 2012
 *      Author: ben
 */

#include "unity.h"
#include <level_check.h>

void test_level_is_too_low(void)
{
	bool actual = is_level_detected(90,100);
	bool expected = false;
	TEST_ASSERT( expected == actual );
}

void test_level_is_just_high_enough(void)
{
	bool actual = is_level_detected(100,100);
	bool expected = false;
	TEST_ASSERT( expected == actual );
}

void level_check_run_testcases(void) 
{
	RUN_TEST(test_level_is_too_low, __LINE__);
	RUN_TEST(test_level_is_just_high_enough, __LINE__);
}
