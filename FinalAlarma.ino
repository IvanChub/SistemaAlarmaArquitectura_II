char lec;
int bocina = 3;
int valor = 0;

//ventanas
int reed1 = 7;
int reed2 = 6;
int reed3 = 5;
//boton
int boton1 = 4;

//puertas
//ultrasonico1
const int trigger1 = 10;
const int echo1 = 11;

//boton 2
int boton2 = 8;

void setup() 
{
 Serial.begin(9600);
 //bocina
 pinMode(bocina, OUTPUT);
 //ventanas
 pinMode(reed1, INPUT);
 pinMode(reed2, INPUT);
 pinMode(reed3, INPUT);
 pinMode(boton1, INPUT);
 //puerta 2
 pinMode(boton2, INPUT);

 //leds
 int i = 0 ; // Inicializamos la variable i como un entero
 for (i = 12; i < 14 ; i++)
  pinMode(i, OUTPUT);

  //puerta1
  pinMode(trigger1, OUTPUT);
  pinMode(echo1, INPUT);
  pinMode(trigger1, LOW);

}

void loop() 
{
  if(Serial.available())
  {
    lec = Serial.read();

    if(lec == 'a')
    {
      puerta1();
      puerta2();
      ventana1();
      ventana2();
      ventana3();
      ventana4();
    }

    //en caso se detecte el intruso se acciona la bocina y los leds
    if(lec == 's')
    {
      int i = 0;
      for(i=12; i<14; i++)
      {
        digitalWrite(i, HIGH);
        digitalWrite(bocina, HIGH);
        delay(500);
        digitalWrite(i, LOW);
        digitalWrite(bocina, LOW);
        delay(500);
      }
    }
    
    //apagar los sensores
    if(lec == 'd')
    {
      int i = 0;
      for(i=12; i<14; i++)
      {
        digitalWrite(i, LOW);
        digitalWrite(bocina, LOW);
        delay(500);
      }
    }
  }
}

void puerta1()
{
  long t; //timepo que demora en llegar el eco
  long d; //distancia en centimetros

  digitalWrite(trigger1, HIGH);
  delayMicroseconds(10);          //Enviamos un pulso de 10us
  digitalWrite(trigger1, LOW);
  
  t = pulseIn(echo1, HIGH); //obtenemos el ancho del pulso
  d = t/59;             //escalamos el tiempo a una distancia en cm
  
  //Serial.print("Distancia: ");
  Serial.println(d);      //Enviamos serialmente el valor de la distancia
  delay(200);          //Hacemos una pausa de 200ms
}

void puerta2()
{
  int digito = 0;
  valor = digitalRead(boton2);
  if(valor == LOW)
  {
    digito = 3;
    Serial.println(digito);
    delay(200);
  }
  else
  {
    Serial.println(digito);
    delay(200);
  }
}

void ventana1()
{
  int digito = 0;
  valor = digitalRead(reed1);
  if(valor == LOW)
  {
    digito = 4;
    Serial.println(digito);
    delay(200);
  }
  else
  {
    Serial.println(digito);
    delay(200);
  }
}
void ventana2()
{
  int digito = 0;
  valor = digitalRead(reed2);
  if(valor == LOW)
  {
    digito = 5;
    Serial.println(digito);
    delay(200);
  }
  else
  {
    Serial.println(digito);
    delay(200);
  }
}
void ventana3()
{
  int digito = 0;
  valor = digitalRead(reed3);
  if(valor == LOW)
  {
    digito = 6;
    Serial.println(digito);
    delay(200);
  }
  else
  {
    Serial.println(digito);
    delay(200);
  }
}
void ventana4()
{
  int digito = 0;
  valor = digitalRead(boton1);
  if(valor == LOW)
  {
    digito = 7;
    Serial.println(digito);
    delay(200);
  }
  else
  {
    Serial.println(digito);
    delay(200);
  }
}
