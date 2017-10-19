
/*
    THIS IS THE ENEMY CLASS
    IF THE PLAYER TOUCHES ONE OF THE BIRDS - HE WILL LOSE 1 LIFE
*/


class birdClass {
  float birdX = 550;
  float birdY = random(-15,815);
  float birdSize = 1;
  
  
  void fall() {
    
    birdX -= 1.5;
    
    if(nutPoints >= 25){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 49){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 50){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 74){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 75){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 99){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 100){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 124){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 125){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 149){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 150){
      birdX -= 0.5;
      sound4.play();
    }
    
    if(nutPoints == 151){
     sound4.rewind();
     sound4.pause();
    }
    
    fill(0,0,0,0);
    
    ellipse(birdX, birdY, 40, 40);
    image(birds,birdX-20,birdY-20);
  }
  
  void birdCollision() {
    if(birdX < heroX*0.4 +squareWidth && birdX > heroX*0.4 && birdY > heroY*0.4 && birdY < heroY*0.4+squareHeight){
      lifePoints--;
      birdX -= 1000;
      sound3.play();
      sound3.rewind();
    }
  }
  
}