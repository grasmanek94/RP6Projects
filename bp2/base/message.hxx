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
      if (getBufferLength() > 5 &&
          readChar() == begin[0] &&
          readChar() == begin[1])
      {
        //Read action & data lenght
		action = readChar();
        dataLen = readChar();
        if (dataLen > 58)
        {
          dataLen = 58;
        }

		while (getBufferLength() < dataLen) {}

		readChars((char*)data, dataLen);
        data[dataLen] = 0;

        //Corruption check
        uint8_t corruptioncheck[2];
		readChars((char*)&corruptioncheck, 2);

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

    //returns the amount of bytes succesfully written
    uint8_t Write()
    {
      writeStringLength((char*)begin, 2, 0);
      writeChar(action);
      writeChar(dataLen);
      writeStringLength((char*)data, dataLen, 0);
      writeStringLength((char*)end, 2, 0);
      return 6 + dataLen;
    }

    uint8_t WriteString(char * str)
    {
      dataLen = strlen(str) + 1;
      memcpy(data, str, dataLen);
      return Write();
    }
};

