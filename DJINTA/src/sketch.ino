#define Pulse 9

#define Dir 8

long delay_Micros = 5;

long currentMicros = 0;

long previousMicros = 0;

int inByte = '0';

const byte numChars = 32;

char receivedChars[numChars];

boolean newData = false;

int dataNumber = 0;

void setup(){
  Serial.begin(9600);
  pinMode(Pulse,OUTPUT);

  pinMode(Dir,OUTPUT);

  digitalWrite(Dir,LOW);
}

void loop(){
  inByte = 0;
  if(Serial.available() > 0){
    recvWithEndMarker();
    inByte = atoi(receivedChars);
  }

  while(inByte != 0){
    currentMicros = micros();
    if(currentMicros - previousMicros >= delay_Micros){
      inByte--;
      previousMicros = currentMicros;
      digitalWrite(Pulse,HIGH);
      delayMicroseconds(5);
      digitalWrite(Pulse,LOW);
    }
  }
}

void recvWithEndMarker(){
    static byte ndx = 0;
    char endMarker = '\n';
    char rc;
    
    if (Serial.available() > 0) {
        rc = Serial.read();

        if (rc != endMarker) {
            receivedChars[ndx] = rc;
            ndx++;
            if (ndx >= numChars) {
                ndx = numChars - 1;
            }
        }
        else {
            receivedChars[ndx] = '\0'; // terminate the string
            ndx = 0;
            newData = true;
        }
    }
}
