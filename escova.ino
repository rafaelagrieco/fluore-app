#include <Wire.h>
#include <SFE_MMA8452Q.h>
#include <SoftwareSerial.h> //bluetooth

MMA8452Q accel;
SoftwareSerial SerialBt(2, 3); //bluetooth

unsigned long currentTime = 0;
unsigned long previousTime = 0;
float x = 0, y = 0, z = 0;
bool mudou = false;
int cont_dif = 0;
const int NUM_LEITURAS = 3; // número de leituras consecutivas com valores diferentes
char inciar; // motor de vibração


void setup() {
  Serial.begin(9600);
  SerialBt.begin(9600); //bluetooth
  Serial.println("MMA8452Q Test Code!");
  accel.init();
  pinMode(5,OUTPUT); //motor de vibração
  
}

void loop() {

  char iniciar = Serial.read();
  if(iniciar == "I")
  {
    Vibracall();
  }

  if (accel.available()) {
    accel.read();
    printCalculatedAccels();
    CalculatedAccels();
    Serial.println();
  }

  //bluetooth código rogerio teams
    if (SerialBt.available())
    {
      Serial.write(SerialBt.read());
    }
    if (Serial.available())
    {
      SerialBt.write(Serial.read());
    }
  
}

void Vibracall() {

  //motor de vibração
  //3
  digitalWrite(5, LOW);
  digitalWrite(5, HIGH);
  delay(600);
  digitalWrite(5, LOW);
  delay(450);


  //2
  digitalWrite(5, HIGH);
  delay(600);
  digitalWrite(5, LOW);
  delay(450);


  //1
  digitalWrite(5, HIGH);
  delay(800);
  digitalWrite(5, LOW);
}

void CalculatedAccels() {
  currentTime = millis();
  if ((currentTime - previousTime) > 200) {
    if (x != round(accel.cx * 10) / 10.0 || y != round(accel.cy * 10) / 10.0 || z != round(accel.cz * 10) / 10.0) {
      cont_dif++; // incrementa contador se valores diferentes
      if (cont_dif == NUM_LEITURAS) { // dispara ataque quando atingir número de leituras consecutivas com valores diferentes
        mudou = true;
        x = round(accel.cx * 10) / 10.0;
        y = round(accel.cy * 10) / 10.0;
        z = round(accel.cz * 10) / 10.0;
        if (mudou) {
          Serial.write("A");
        }
        cont_dif = 0; // reseta contador
      }
    }
    else {
      cont_dif = 0; // reseta contador se valores iguais
      mudou = false;
      if (!mudou) {
        Serial.write("P");
      }
    }
    previousTime = currentTime;
  }
}

void printCalculatedAccels() {
  Serial.print(accel.cx, 1);
  Serial.print("\t");
  Serial.print(accel.cy, 1);
  Serial.print("\t");
  Serial.print(accel.cz, 1);
  Serial.print("\n");
  delay (1000);
}
