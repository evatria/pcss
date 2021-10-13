import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Scanner;

public class Game {
    //Player variables
    ArrayList<Player> players = new ArrayList<Player>();
    public int playerId = 0;
    public String name;
    public int points;
    public boolean isActive;


    //QuestionBlock Variables
    static ArrayList<QuestionBlock> questionBlock = new ArrayList<QuestionBlock>();
    public static String question;
    public static String answer;
    public static int value;
    public static int categoryId;

    //Player voids
    public void loadPlayerInfo(Socket socket, DataInputStream input) throws IOException {
        name = input.readUTF();
        players.add(new Player(playerId, name, 0, false));

    }


    //QuestionBlock voids
      //Load questions from document
      public void loadQuestions() {
        //Creating a scanner for reading the questionblocks from a file
        Scanner sc = null;
        //Try Catch to find file
        try {
            sc = new Scanner(new File("C:\\Users\\Victor Hjort\\OneDrive\\Gymnasie\\Documents\\PCSS-G301\\Back end\\MiniprojectServer\\lol.csv"));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
            System.out.println("COULD NOT FIND FILE OF QUESTIONS");
        }

        sc.useDelimiter(",");//sets the delimiter pattern

        //Set a while loop for reading data as long as there is more data
        while(sc.hasNext()) {
            //A for loop for every questionBlock
            for (int i = 0; i < 4; i++)
            {
                if (i == 0) {
                    question = sc.next();
                }
                if (i == 1) {
                    answer = sc.next();
                }
                if (i == 2) {
                    value = Integer.parseInt(sc.next());
                }
                if (i == 3) {
                    categoryId = Integer.parseInt(sc.next());
                }
            }
            questionBlock.add(new QuestionBlock(question, answer, value, categoryId));
        }
        sc.close();  //closes the scanner

        //Printing out all the info in the console
        for(int i = 0; i < questionBlock.size(); i++) {
            System.out.println(questionBlock.get(i).toString());
        }



    }

      //Transfer questionblocks out to clients
      public void transferBlockOut(Socket socket, DataOutputStream output) throws IOException {
        //Letting client know how many loops it needs to run
          System.out.println(questionBlock.size());
        //For loop sending information from questionblocks
        for(int i = 0; i < questionBlock.size(); i++) {
            output.writeUTF(questionBlock.get(i).getQuestion());
            output.writeUTF(questionBlock.get(i).getAnswer());
            output.writeInt(questionBlock.get(i).getValue());
            output.writeInt(questionBlock.get(i).getCategoryId());
        }
    }



}