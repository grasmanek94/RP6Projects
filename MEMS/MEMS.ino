#include <Wire.h>
#include <LSM303.h>

struct vector3
{
  float x;
  float y;
  float z;
  vector3()
    : x(0.0), y(0.0), z(0.0)
  {

  }
  vector3(float x, float y, float z)
    : x(x), y(y), z(z)
  {

  }
  vector3& operator=(vector3 other)
  {
    this->x = other.x;
    this->y = other.y;
    this->z = other.z;
    return *this;
  }
  vector3& operator-(vector3 other)
  {
    vector3 tmp;
    tmp.x = this->x - other.x;
    tmp.y = this->y - other.y;
    tmp.z = this->z - other.z;
    return tmp;
  }
  vector3& operator+(vector3 other)
  {
    vector3 tmp;
    tmp.x = this->x + other.x;
    tmp.y = this->y + other.y;
    tmp.z = this->z + other.z;
    return tmp;
  }
  vector3& operator/(float div)
  {
    vector3 tmp;
    tmp.x = this->x / div;
    tmp.y = this->y / div;
    tmp.z = this->z / div;
    return tmp;
  }
  vector3& operator*(float mul)
  {
    vector3 tmp;
    tmp.x = this->x / mul;
    tmp.y = this->y / mul;
    tmp.z = this->z / mul;
    return tmp;
  }
};

LSM303 compass;

void setup()
{
  Serial.begin(9600);
  Wire.begin();
  compass.init();
  compass.enableDefault();

  compass.m_min = (LSM303::vector<int16_t>) {
    +3822, +12269, -12231
  };
  compass.m_max = (LSM303::vector<int16_t>) {
    +16877, +25709,  +7268
  };
}

char report[80];
const float pi = 3.1415f;

void loop()
{
  compass.read();
  
  vector3 reading((float)compass.a.x, (float)compass.a.y, (float)compass.a.z);
  vector3 hoek(
    (atan2(reading.y, sqrt(reading.z * reading.z + reading.x * reading.x)) * 180.0f) / pi,
    (atan2(reading.x, sqrt(reading.z * reading.z + reading.y * reading.y)) * 180.0f) / pi,
    (float)compass.heading()
  );
 
  sprintf(report, "X: %4d Y: %4d Z: %4d", (int)hoek.x, (int)hoek.y, (int)hoek.z);
  Serial.println(report);

  delay(150);
}
