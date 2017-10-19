
/*
    THIS IS THE NUT CLASS
    IF THE PLAYER TOUCHES ONE OF THE NUTS - HE WILL GAIN 1 NUT POINT
*/


class nutClass {
  float nutX = random(-5,505);
  float nutY = 0;
  
  void fall() {
  
   nutY += 1.0;
   fill(0,0);
   ellipse(nutX, nutY, 30, 40);
   image(nuts,nutX-15,nutY-20);
  }
  
  void nutCollision() {
    if(nutX < heroX*0.4 +squareWidth && nutX > heroX*0.4 && nutY > heroY*0.4 && nutY < heroY*0.4+squareHeight){
      nutPoints++;
      nutX -= 1000;
      sound1.play();
      sound1.rewind();
    }
  }
}