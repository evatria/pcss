# Introduction 
"Codename: ULTRA" is a two player game where both players get different information presented on their device. The game was originally developed for a second semester project but is now being modified to one simple riddle which is being used for this mini-project. 

In order to play the game, a server needs to be running before running the clients. When the server is running, players can join the game. Two players can play together and any more players willing to join, can play in pairs seperately from others. 

When the game is installed on the phones and the 2 players have pressed the play button, each of them is assigned to one of the two roles: War officer or Intelligence officer. The game can be finished by the collaboration beetween the two officers. 

The mini project's puzzle is just one out of the actual game "Codename: ULTRA" which consists of many more puzzles. For the mini project this puzzle was only presented as a teaser for the full game. 

The server is made in IntelliJ IDEA and the Client in Android Studio. The game can run on an Android phone or an emulator within Android Studio. 

# Step by step guide on how to set up the Server

1. Download the repository to your computer as a zip file and unzip it. 

2. In order to run the server, Java IDE is needed. For example Eclipse IDE for Java Developers or IntelliJ IDEA. The group has used IntelliJ IDEA for developing the program. It can be downloaded through https://www.jetbrains.com/idea/ following the guide provided on the webpage. 

3. When the download has been completed, the folder named "Server" should be opened through the Java IDE. 

4. Make sure the server can run before starting the Client. If it prints out the line "Server is running" it is set up for starting the game.  

# Step by step guide on how to set up the Client

1. As the repository is already downloaded, the first step to make sure the Client will run, is to download Android studio. That can be done through this link > https://developer.android.com/studio 

2. When the download has been completed, the folder named "rotate4" should be opened through Android Studio. 

3. Install the program on the phone (With Android OS) by running it while it is connected to the computer through USB. One should remember to enable Developers options -> USB Debugging on the device. 

4. The phones should be connected to the same hotspot as the computer and the IP adress ("???.???.??.???.") should be written in the Client class where it says: 
Socket s = new Socket ("192.168.??.???", port 7500);

5. Check if the server is running and run the game from Android Studio. It is now able to connect from the phones to server.  

# Gameplay

For starting the game, after making sure the server is running, both players must start the application on their phones and start the game. One of the players, as mentioned above, will be a War Officer, another an Intelligence Officer. 

To complete the game, the intelligence officer is opening the poem on their table, and the War officer (using the code on his table) should collaborate in solving the small puzzle the War Officer is presented to. Together they should spell out the sentence "The name of a brilliant mind". Then, the players should discuss the meaning of this sentence and what/who it is reffering to. When they have come up with a possible solution, the war officer should go to the box on his table and spell out what he thinks is the answer. If the war officer spells out "TURING" then the game is completed and over.

#  UML class, use case, and sequence diagrams
### Class diagram client:

![Class Diagram](https://github.com/CatharinaP/MiniProjectPCSS/blob/master/class_diagram.jpg)

### Class diagram server:

![Class Diagram Server](https://github.com/CatharinaP/MiniProjectPCSS/blob/master/server_class.jpg)

### Use case diagram:

![Use Case Diagram](https://github.com/CatharinaP/MiniProjectPCSS/blob/master/use%20case.jpg)

### Sequence diagram:

![Sequence Diagram](https://github.com/CatharinaP/MiniProjectPCSS/blob/master/sequenceDiagram.jpg)

