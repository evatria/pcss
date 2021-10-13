import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class Main implements Serializable {

    public static void main(String args[]) throws IOException {

        //Creatin an object for the gam
        Game game =  new Game();
        game.loadQuestions();

        //Hosting the server
        String host = "172.20.10.2";
        int port = 9696;
        ServerSocket Server = new ServerSocket(port);
        Socket socket = Server.accept();
        System.out.println("Connection from " + socket + "!");

        //Creating input and output streams
        DataInputStream input = new DataInputStream(socket.getInputStream());
        DataOutputStream output = new DataOutputStream(socket.getOutputStream());

        //Sending all the questionblock variables
        game.transferBlockOut(socket, output);

        //Receiving name of the first user
        //game.loadPlayerInfo(socket, input);



    }
}
