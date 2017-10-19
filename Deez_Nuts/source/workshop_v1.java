import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import ddf.minim.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class workshop_v1 extends PApplet {


// START OF THE PROGRAM


/*
******************* CREATED BY BO SYLVESTER PEDERSEN  *******************
******************* SCHOOL PROJECT CALLED "DEEZ NUTS" *******************
*******************          20 / 11 / 2016           *******************
*******************       COPY RIGHT, I GUESS?        *******************
*/


//
////
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------
// ***************** GLOBAL VARIABLES BELOW *****************
//

// --------------------------
int heroX = 250; //The squirrel's starts x-position
int heroY = 600; //The squirrel's starts y-position
// --------------------------

// --------------------------
PImage heroSquirrel; // The squirrel image variable
PImage gameBackground; // The background image variable
PImage nuts; // The nuts image variable
PImage birds; // The birds image variable
PImage birdBoss; // The boss image variable
PImage gameSky; // The clouds image variable
PImage tutorial; // The tutorial image variable
// --------------------------

// --------------------------
boolean skyChecker = false; //

int skySpeed1; // The speed variable for the first cloud
int skyX1 = -200; // Start x-position of the first cloud
int skyY1 = 50; // Start y-position of the first cloud

int skySpeed2; // The speed variable for the second cloud
int skyX2 = 400; // Start x-position of the second cloud
int skyY2 = 350; // Start y-position of the first cloud
// --------------------------

// --------------------------
//The variable below are used to remove the "tutorial start-screen"
int tutorialText = 1; //
// --------------------------

// --------------------------
int nutDrops = 0; // 
nutClass[] drops = new nutClass[1000]; // Declare and create the array
//
int birdDrops = 0; //
birdClass[] bombs = new birdClass[2000]; // Declare and create the array
// --------------------------

// --------------------------
int nutPoints = 0; // The amount of starting points
//
int lifePoints = 3; // The amount of starting lives
// --------------------------

// --------------------------
int birdNumbers = 80; // A variable used to set the difficulty for the game
// --------------------------

// --------------------------
int squareWidth = 85; // An invisible width - used for collision (Squirrel)
int squareHeight = 95; // An invisible height - used for collision (Squirrel)
// --------------------------

// --------------------------
// Four boolean variables used for the controls
boolean keyA = false;
boolean keyW = false;
boolean keyD = false;
boolean keyS = false;
// --------------------------

// --------------------------
//Sound variables
//
 //Imports minim
//
Minim minim;
//
AudioPlayer sound1;
AudioPlayer sound2;
AudioPlayer sound3;
AudioPlayer sound4;
// --------------------------

// --------------------------
float bossX; //Variable for the boss' x values
float bossY; //Variable for the boss' y values
//
float bossSpeed; //Variable for the boss' speed
//
int bossWidth = 170; //Variable for the invisible collision
int bossHeight = 170; //Variable for the invisible collision
// --------------------------


//
// ***************** GLOBAL VARIABLES ABOVE *****************
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------
////
//

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------

public void setup() { //Start of setup

   //Size of the program
  
  frameRate(60); //Sets the frame rate to 60 - smoothens the motions
  
  heroSquirrel = loadImage("heroSquirrel.png"); //Loading the squirrel-hero-image
  
  nuts = loadImage("nut_hd.png"); //Loading the nut-image
  
  birds = loadImage("bird.png"); //Loading the natural-enemy-image
  
  birdBoss = loadImage("boss_bird.png"); //Loading the natural-enemy-image
  
  gameBackground = loadImage("background_Workshop.png"); //Loading the background image
  
  gameSky = loadImage("sky.png"); //Loading the floating sky in the background
  
  tutorial = loadImage("Intro.jpg"); //Loading the tutorial image
  
  drops[0] = new nutClass(); // Create first nut-object
  bombs[0] = new birdClass(); // Create first bird-object
  
  minim = new Minim(this);
  
  sound1 = minim.loadFile("crunch.mp3"); //Loading the sound file "crunch.mp3"
  sound1.setGain(-3); //Lowering the gain of the sound
  sound1.pause(); //Pauses the sound
  
  //The same goes for the other sounds below
  
  sound2 = minim.loadFile("background_music.wav"); //
  sound2.setGain(-7); //
  sound2.pause(); //
  
  sound3 = minim.loadFile("bird.mp3"); //
  sound3.setGain(-3); //
  sound3.pause(); //
  
  sound4 = minim.loadFile("bossScream.mp3"); //
  sound4.setGain(-7); //
  sound4.pause(); //
  
  bossY = random(300,500); // Setting the y-values for the boss to be a random number between 300 and 500
  bossX = 705; //Setting the start x-value of the boss to be 705
  bossSpeed = -1.4f; //Setting the speed of the boss to be 1.4
  
} //End of setup

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------

public void draw() { //Start of draw
  background(gameBackground); //Drawing the background each frame
  
  // ----------------------------------------------------------------------------------------------------------
  //The code below makes the clouds repeatly goes through the sky
  image(gameSky,skyX1+skySpeed1,skyY1);
  if(skyChecker == true && skySpeed1 < 800){
    skySpeed1 += 1;
  } else {
    skySpeed1 = -50;
  }

  //The code below makes the cloud repeatly goes through the sky
  pushMatrix();
  scale(1.5f); //Scales the cloud 1/2 bigger
  image(gameSky,skyX2-(skySpeed2-(skySpeed2/2)),skyY2);
  popMatrix();
  
  if(skyChecker == true && skySpeed2 < 1300){
    skySpeed2 += 1;
  } else {
    skySpeed2 = -50;
  }
// ----------------------------------------------------------------------------------------------------------
// Drawing the squirrel-hero
  
  squirrelDisplay();
  squirrelMovement();

//----------------------------------------------------------------------------------------------------------

  
if(skyChecker == true){
  
  if (nutDrops == drops.length - 1) stop();
    fill(255, 80);
  if (random(80) < 1) {
    drops[++nutDrops] = new nutClass(); // Create each object
  }
  
 //Loop through array to use objects.
  for (int i = 0; i < nutDrops; i++) {
    drops[i].fall();
    drops[i].nutCollision();
  }
 
 
  if (birdDrops == bombs.length - 1) stop();
    fill(255, 80);
    if (random(birdNumbers) < 1) {
      bombs[++birdDrops] = new birdClass(); // Create each object
    }
      
    // **** The "if-statements" below determintes the different "levels" or difficulties, based on the amount of nutPoints you have. For example spawning the boss or increasing the amount of birds ****
      
    if(nutPoints >= 25){
      birdNumbers = 60;
      image(birdBoss,bossX-20,bossY-20);
      bossX += bossSpeed;
    }
    
    if(nutPoints >= 50){
      birdNumbers = 35;
      //
      if(bossX < -100 && nutPoints == 50){
        bossX = 705;
        bossY = random(150,400);
      }
    }
    
    if(nutPoints >= 75){
      birdNumbers = 25;
      //
      if(bossX < -100 && nutPoints == 75){
        bossX = 705;
        bossY = random(150,400);
      }
    }
    
    if(nutPoints >= 100){
      birdNumbers = 15;
      //
      if(bossX < -100 && nutPoints == 100){
        bossX = 705;
        bossY = random(150,400);
      }
    }
    
    if(nutPoints >= 125){
      birdNumbers = 12;
      //
      if(bossX < -100 && nutPoints == 125){
        bossX = 705;
        bossY = random(150,400);
      }
    }
    
    if(nutPoints >= 150){
      birdNumbers = 8;
      //
      if(bossX < -100 && nutPoints == 150){
        bossX = 705;
        bossY = random(150,400);
      }
    }
    
    //............ MOrE DIFFICULTIES TO COME ............
    // **** The "if-statements" above determintes the differennt "levels" or difficulties. For example spawning the boss or increasing the amount of birds ****


    // The code below is the boss collision with the squirrel-hero
    fill(0,0,0,0);
    rect(bossX,bossY,bossWidth,bossHeight);
    
    if(heroX*0.4f+squareWidth > bossX && heroX*0.4f < bossX+bossWidth && heroY*0.4f+squareHeight > bossY && heroY*0.4f < bossY+bossHeight){
      lifePoints = 0;
    }

 
 //Loop through array to use bird-objects
  for (int i = 0; i < birdDrops; i++) {
    bombs[i].fall();
    bombs[i].birdCollision();
  }
// ------------------------------------------------------------------------------------------------------
//An invisible square i use for collision, based on the squirrels movements and size
  noStroke();
  fill(0,0,0,0);
  rect(0.4f*heroX-4,0.4f*heroY+10,squareWidth,squareHeight);
  
// ------------------------------------------------------------------------------------------------------
// The code below displays the amount of nutPoints and lifePoints in the program 

  pushMatrix();
  fill(0);
  scale(1.4f);
  text("You have a total of "+nutPoints+" nuts",10,20);
  text("You have "+lifePoints+" lives left",10,40);
  popMatrix();
  
//When you lose, the code below will make the program stop and tell you that you have lost
  
  if(lifePoints == 0){
    stop();
    sound2.pause();
    fill(0,0,0,255);
    rect(0,0,width,height);
    pushMatrix();
    fill(255);
    scale(2.5f);
    text("YOU LOST YOU PIECE OF NUT",10,150);
    text("YOU GOT "+nutPoints+" NUTS",45,170);
    popMatrix();
  }

}

//----------------------------------------------------------------------------------------------------------

  pushMatrix();
  scale(tutorialText);
  image(tutorial,0,0);
  popMatrix();

//---------------------------------------------------------------------------------------------------------- 
  
} //End of draw

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------

public void keyPressed() { //Start of keyPressed

  if(key == 'a'){
    keyA = true; 
  }
  
  if(key == 'w'){
    keyW = true; 
  }
  
  if(key == 'd'){
    keyD = true; 
  }
  
  if(key == 's'){
    keyS = true; 
  }  
  
  if(key == ENTER){ //STARTS FROM THE TUTORIAL
    tutorialText = 0;
    skyChecker = true;
    sound2.loop();
  }
} //End of keyPressed

public void keyReleased(){ //Start of keyReleased
  
  if(key == 'a'){
    keyA = false; 
  }
  
  if(key == 'w'){
    keyW = false; 
  }
  
  if(key == 'd'){
    keyD = false; 
  }
  
  if(key == 's'){
    keyS = false; 
  }  
  
} // End of keyReleased


// ---------------------------------------------------------------------------------------------------------------------------------------------------------------

/*
    THIS IS THE ENEMY CLASS
    IF THE PLAYER TOUCHES ONE OF THE BIRDS - HE WILL LOSE 1 LIFE
*/


class birdClass {
  float birdX = 550;
  float birdY = random(-15,815);
  float birdSize = 1;
  
  
  public void fall() {
    
    birdX -= 1.5f;
    
    if(nutPoints >= 25){
      birdX -= 0.5f;
      sound4.play();
    }
    
    if(nutPoints == 49){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 50){
      birdX -= 0.5f;
      sound4.play();
    }
    
    if(nutPoints == 74){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 75){
      birdX -= 0.5f;
      sound4.play();
    }
    
    if(nutPoints == 99){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 100){
      birdX -= 0.5f;
      sound4.play();
    }
    
    if(nutPoints == 124){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 125){
      birdX -= 0.5f;
      sound4.play();
    }
    
    if(nutPoints == 149){
     sound4.rewind();
     sound4.pause();
    }
    
    if(nutPoints >= 150){
      birdX -= 0.5f;
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
  
  public void birdCollision() {
    if(birdX < heroX*0.4f +squareWidth && birdX > heroX*0.4f && birdY > heroY*0.4f && birdY < heroY*0.4f+squareHeight){
      lifePoints--;
      birdX -= 1000;
      sound3.play();
      sound3.rewind();
    }
  }
  
}

/*
    THIS IS THE SQUIRREL CLASS
    HE IS THE HERO OF THE GAME, KEEP HIM ALIVE AT ALL COSTS
*/


class squirrelClass {
  //
}

public void squirrelDisplay(){
  pushMatrix();
  //
  scale(0.4f); 
  image(heroSquirrel,heroX,heroY);  
  //
  popMatrix();
}


public void squirrelMovement(){
  
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

/*
    THIS IS THE NUT CLASS
    IF THE PLAYER TOUCHES ONE OF THE NUTS - HE WILL GAIN 1 NUT POINT
*/


class nutClass {
  float nutX = random(-5,505);
  float nutY = 0;
  
  public void fall() {
  
   nutY += 1.0f;
   fill(0,0);
   ellipse(nutX, nutY, 30, 40);
   image(nuts,nutX-15,nutY-20);
  }
  
  public void nutCollision() {
    if(nutX < heroX*0.4f +squareWidth && nutX > heroX*0.4f && nutY > heroY*0.4f && nutY < heroY*0.4f+squareHeight){
      nutPoints++;
      nutX -= 1000;
      sound1.play();
      sound1.rewind();
    }
  }
}
  public void settings() {  size(500,800); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "--present", "--window-color=#666666", "--stop-color=#cccccc", "workshop_v1" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
