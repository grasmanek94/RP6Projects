#include "unity.h"
#include <led_values_updater.h>

void test_perform_full_shift(void)
{
	uint8_t led_values = 0;

	led_values_update(led_values, &led_values);
	TEST_ASSERT(0b0001 == led_values);

	led_values_update(led_values, &led_values);
	TEST_ASSERT(0b0010 == led_values);

	led_values_update(led_values, &led_values);
	TEST_ASSERT(0b0100 == led_values);

	led_values_update(led_values, &led_values);
	TEST_ASSERT(0b1000 == led_values);

	led_values_update(led_values, &led_values);
	TEST_ASSERT(0b0000 == led_values);
}

void led_values_updater_run_testcases(void)
{
	RUN_TEST(test_perform_full_shift, __LINE__);
}