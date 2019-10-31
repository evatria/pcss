# Introduction 
"Codename: ULTRA" is a two player game where both players gets different information presented on their virtual device. The game was originally developed for a P2 project but is now being modified to one simple riddle which is being used for this mini-project. 

In order to play the game, a server needs to be running before running the clients. When the server is running, players can join the game. Two players can play together and any more players willing to join, can play in pairs seperately from other pairs. 

When the game is installed on the phones and the 2 players have pressed the play button then is each player is assigned to one of the two roles: War officer or Intelligence officer. The game can be finished by the collaberation beetween War officer and Inteligence officer. 

The mini projects riddle is just one out of the actual game "Codename: ULTRA" which consists of many more puzzles when both parts are more involved with the game process. For the mini project this riddle was only presented as a teaser for the full game. 

Server is made in IntelliJ IDEA but the Client part in Android Studio. The game can run on an Android phone or a simulator within the Android Studio. 

# Step by step guide on how to set up the Server part

1. Download the repository to their computer as a zip file and unzip it. 

2. In order to run the server, Java IDE is needed. For example an Eclipse IDE for Java Developers or IntelliJ IDEA. The group has used IntelliJ IDEA for the developing the program. It can be downloaded through https://www.jetbrains.com/idea/ following the guide provided within the webpage. 

3. When the download has been done, the folder named "Server" should be opened through the Java IDE. 

4. Make sure server can run before starting to set up the Client side. If it prints out a line "Server is running" it is set up for starting the game.  

# Step by step guide on how to set up the Client part 

1. As the repository is already downloaded, first step for making sure Client part can be running, is to download Android studio. That can be done through this link > https://developer.android.com/studio 

2. When the download has been done, the folder named "rotate4" should be opened through the Android Studio. 

3. Install the programm in the phone by running it while Android phone is connected to the computer through USB. One should remember to enable Developers mode on phone. 

4. Phones should be connected to the same hotspot as the computer and the IP adress ("???.???.??.???.") should be written in Client class where it says 
Socket s = new Socket ("192.168.??.???", port 7500);

5. Check if server is running and run the game from Android Studio. It is now able to connect from the phones to server.  

# Gameplay

For starting the game, after making sure the server is running, both players must start the application in their phones and start the game. One of the players, as mentioned above, will be a War Officer, another an Intelligence Officer. 

For finishing the game, the intelligence officer is opening the peom on their table, and War officer using the code on his table should collaborate for solving the small puzzle War Officer is presented to. Together they would spell out the sentence "The name of a briliant mind". Then the players would have to discuss the meaning of this sentence and what the meaning of this could be, when they have found a possible solution, then the war officer go to the box on his desktop and spell out what he thinks is the answer. If the war officer spell out "TURING" then the game is won.
