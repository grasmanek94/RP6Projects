#include <Wire.h>
#include <LSM303.h>

class _myVector
{
  public:
    float x;
    float y;
    float z;

    _myVector()
      : x(0.0), y(0.0), z(0.0)
    {

    }
    _myVector(const _myVector& other)
      : x(other.x), y(other.y), z(other.z)
    {

    }
    _myVector(float x, float y, float z)
      : x(x), y(y), z(z)
    {

    }
    _myVector& operator=(const _myVector& other)
    {
      this->x = other.x;
      this->y = other.y;
      this->z = other.z;
      return *this;
    }
    const _myVector operator-(const _myVector& right)
    {
      _myVector tmp;
      tmp.x = this->x - right.x;
      tmp.y = this->y - right.y;
      tmp.z = this->z - right.z;
      return tmp;
    }
    const _myVector operator+=(const _myVector& right)
    {
      this->x += right.x;
      this->y += right.y;
      this->z += right.z;
      return *this;
    }
    const _myVector operator+(const _myVector& right)
    {
      _myVector tmp;
      tmp.x = this->x + right.x;
      tmp.y = this->y + right.y;
      tmp.z = this->z + right.z;
      return tmp;
    }
    const _myVector operator/=(float div)
    {
      this->x /= div;
      this->y /= div;
      this->z /= div;
      return *this;
    }
    const _myVector operator/(float div)
    {
      _myVector tmp;
      tmp.x = this->x / div;
      tmp.y = this->y / div;
      tmp.z = this->z / div;
      return tmp;
    }
    const _myVector operator*(float mul)
    {
      _myVector tmp;
      tmp.x = this->x * mul;
      tmp.y = this->y * mul;
      tmp.z = this->z * mul;
      return tmp;
    }
    float len()
    {
      return sqrt(x * x + y * y + z * z);
    }
    const _myVector absolute()
    {
      this->x = abs(this->x);
      this->y = abs(this->y);
      this->z = abs(this->z);
      return *this;
    }
};

//we gebruiken onze moving average filter
const class _myVector MoveAverF(const class _myVector& x, unsigned int weight)
{
    static bool firstInsert = false;
    static bool firstMeasurements = false;
    static int insertedElems = 0;
    static _myVector movingAverage[50];
    static _myVector previousAverage;

    if (weight > 50) {
      weight = 50;
    }

    if (!firstInsert)
    {
      previousAverage = x;
      firstInsert = true;
    }

    movingAverage[insertedElems] = x;

    if (++insertedElems == weight)
    {
      insertedElems = 0;
      firstMeasurements = true;
    }

    if (firstMeasurements)
    {
      previousAverage = _myVector(0.0, 0.0, 0.0);
      for (unsigned int j = 0; j < weight; ++j)
      {
        previousAverage += movingAverage[j];
      }
    }

    previousAverage /= (float)weight;

    return previousAverage;
}

LSM303 compass;

//correctie voor drift (dit zijn de stationaire acceleratie waarden) voor de correctie van de afstandmeting
_myVector driftCorrectie(750.0, 20.0, 16900.0);//9.81 m/s^2 = 16900 readout, 1 m/s^2 = 1722

void setup()
{
  Serial.begin(9600);

  Wire.begin();

  compass.init();
  compass.enableDefault();

  //calibaratie zodat de resultaten betrouwbaarder zijn
  compass.m_min = (LSM303::vector<int16_t>) {
    +3822, +12269, -12231
  };
  compass.m_max = (LSM303::vector<int16_t>) {
    +16877, +25709,  +7268
  };
}

char report[80];
const float pi = 3.1415f;
unsigned long lastPrintTime = 0;
unsigned long lastTick = micros();
float totalMovedDistance = 0.0;

void loop()
{
  unsigned long timeNow = micros();
  unsigned long timeDiff = timeNow - lastTick;
  lastTick = timeNow;

  compass.read();

  _myVector reading(MoveAverF(_myVector((float)compass.a.x, (float)compass.a.y, (float)compass.a.z), 50));
  _myVector hoek(
    (atan2(reading.y, sqrt(reading.z * reading.z + reading.x * reading.x)) * 180.0f) / pi,
    (atan2(reading.x, sqrt(reading.z * reading.z + reading.y * reading.y)) * 180.0f) / pi,
    (atan2((float)compass.m.y, (float)compass.m.x) * 180.0f) / pi
  );
  
  float timeDiffSecond = (float)timeDiff / 1000000.0;
  
  //acceleratie
  static _myVector lastAccel(0.0, 0.0, 0.0);
  
  //Area(N) = Sample(N) + abs(Sample(N) - Sample(N-1)) / 2 * T:
   _myVector currentAccel(_myVector(reading - driftCorrectie) / 1722.0f);
   _myVector diffAccel(_myVector(currentAccel - lastAccel).absolute());
   float currentSpeed = currentAccel.len() + diffAccel.len() / 2.0 * timeDiffSecond;
   
   lastAccel = currentAccel;//areaAccel
   
   //snelheid
  static float lastSpeed = 0.0;
  
  //Area(N) = Sample(N) + abs(Sample(N) - Sample(N-1)) / 2 * T:
  float distanceMoved = currentSpeed + abs(currentSpeed - lastSpeed) / 2.0 * timeDiffSecond;
  
  lastSpeed = currentSpeed;//areaSpeed
  
  //afstand
  static float totalDistance = 0.0;
  if(distanceMoved > 0.60)
  {
    totalDistance += distanceMoved;
  }

  if (timeNow - lastPrintTime > 100000)
  {
    lastPrintTime = timeNow;
    sprintf(report, "X: %4d Y: %4d Z: %4d S: %4d M: ", (int)hoek.x, (int)hoek.y, (int)hoek.z, (unsigned long)currentSpeed);
    Serial.print(report);
    Serial.println(totalDistance);
  }
  delay(1);
}
