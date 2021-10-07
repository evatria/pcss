import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Date;

public class Server {
    private static int port = 6969;

    public static void main(String[] args) {

        //Creates a deck of solution cards and adds them in an arraylist
        ArrayList<SolutionCard> solutionDeck = new ArrayList<>();
        for(SolutionText solutionText : SolutionText.values()){
            solutionDeck.add(new SolutionCard(solutionText.printSolutionText()));
        }

        //Creates a deck of problem cards and adds them in an arraylist
        ArrayList<ProblemCard> problemDeck = new ArrayList<>();
        for(ProblemText problemText : ProblemText.values()){
            solutionDeck.add(new SolutionCard(problemText.printProblemText()));
        }

        //Shuffles the two decks
        Collections.shuffle(solutionDeck);
        Collections.shuffle(problemDeck);

        //Printing of the deck to check if it works
        for(int i = 0; i < problemDeck.size();i++)
            System.out.println(problemDeck.get(i).toString());

        //Printing of the deck to check if it works
        for(int i = 0; i < solutionDeck.size();i++)
        System.out.println(solutionDeck.get(i).toString());

        new Thread( () -> {
            try {
                ServerSocket serverSocket = new ServerSocket(port);
                System.out.println("Server has started at:" + new Date() + '\n');

                //Counts the numbers of clients
                int numberOfClient = 0;

                while(true){
                    Socket connectToCLient = serverSocket.accept();
                    numberOfClient++;

                    //Displays information about the connected clients
                    System.out.println("Client has connected at:" + new Date() + '\n');
                    System.out.println("Total number of client connected: " + numberOfClient + '\n');

                    new Thread(
                            new ServerRunnable(connectToCLient, "Multithreaded Server")
                    ).start();


                }


            } catch (IOException e) {
                e.printStackTrace();
            }

        }).start();

    }

}
