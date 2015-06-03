@echo off
SET PATH=%AVR32_HOME%\bin;%PATH%
SET LANG=C
cd ./assignment_leds
make all
echo ---------------------------
cd ../assignment_leds_test
make all
pause