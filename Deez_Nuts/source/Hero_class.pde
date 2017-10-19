
/*
    THIS IS THE SQUIRREL CLASS
    HE IS THE HERO OF THE GAME, KEEP HIM ALIVE AT ALL COSTS
*/


class squirrelClass {
  //
}

void squirrelDisplay(){
  pushMatrix();
  //
  scale(0.4); 
  image(heroSquirrel,heroX,heroY);  
  //
  popMatrix();
}


void squirrelMovement(){
  
  if(keyA == true){ //LEFT MOVEMENT
    heroX -= 10;
    
    if(heroX == -80){// THIS IF-STATEMENT ENSURES THAT THE HERO CAN'T GO OUTSIDE THE PROGRAM
      heroX += 10;
    }
  }
  
  if(keyD == true){ //RIGHT MOVEMENT
    heroX += 10;
    
    if(heroX == width+600){// THIS IF-STATEMENT ENSURES THAT THE HERO CAN'T GO OUTSIDE THE PROGRAM
      heroX -= 10;
    }
  }
  
  if(keyW == true){ //UPWARDS MOVEMENT
    heroY -= 10;
    
    if(heroY == -80){ // THIS IF-STATEMENT ENSURES THAT THE HERO CAN'T GO OUTSIDE THE PROGRAM
      heroY += 10;
    }
  }
  
  if(keyS == true){ //DOWNWARDS MOVEMENT
    heroY += 10;
    
    if(heroY == height+1050){// THIS IF-STATEMENT ENSURES THAT THE HERO CAN'T GO OUTSIDE THE PROGRAM
      heroY -= 10;
    }
  }
}