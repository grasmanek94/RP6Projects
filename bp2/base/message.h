#include <RP6RobotBaseLib.h>

class Message
{
    uint8_t begin[2];
    uint8_t end[2];
  public:
    uint8_t action;
    uint8_t dataLen;
    uint8_t data[59];
    bool possiblyCorrupt;

    Message()
    {
      begin[0] = '{';
      begin[1] = '{';
      end[0] = '}';
      end[1] = '}';
    }

    //returns the ammount of data that has been succesfully read
    uint8_t Read()
    {
      if (Serial.available() > 5 &&
          Serial.read() == begin[0] &&
          Serial.read() == begin[1])
      {
        //Read action & data lenght
        Serial.readuint8_ts((char*)&action, 1);
        Serial.readuint8_ts((char*)&dataLen, 1);
        if (dataLen > 58)
        {
          dataLen = 58;
        }
        Serial.readuint8_ts((char*)data, dataLen);
        data[dataLen] = 0;

        //Corruption check
        uint8_t corruptioncheck[2];
        Serial.readuint8_ts((char*)&corruptioncheck, 2);

        possiblyCorrupt = *((uint16_t*)corruptioncheck) != *((uint16_t*)end);

        return 6 + dataLen;
      }
      return 0;
    }

    char * ReadString()
    {
      if (Read())
      {
        return (char*)data;
      }
      return 0;
    }

    //returns the amount of uint8_ts succesfully written
    uint8_t Write()
    {
      uint8_t written = 0;
      written += Serial.write((const uint8_t*)begin, 2);
      written += Serial.write(action);
      written += Serial.write(dataLen);
      written += Serial.write((const uint8_t*)data, dataLen);
      written += Serial.write((const uint8_t*)end, 2);
      return written;
    }

    uint8_t WriteString(char * str)
    {
      dataLen = strlen(str) + 1;
      memcpy(data, str, dataLen);
      return Write();
    }
};

