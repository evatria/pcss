import java.io.*;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;

public class Main implements Serializable {

    public static void main(String args[]) throws IOException {

        int numberOfClients = 0;

        //Creatin an object for the gam
        Game game =  new Game();
        game.loadQuestions();

        //Hosting the server
        String host = "172.20.10.2";
        int port = 9696;
        ServerSocket server = new ServerSocket(port);
        while (true) {
            Socket socket = server.accept();
            numberOfClients++;

            InetAddress inetAddress = socket.getInetAddress();

            System.out.println("\nClient number " + numberOfClients + " joined!");
            System.out.println("Client " + numberOfClients + "'s host name is: " + inetAddress.getHostName());
            System.out.println("Client " + numberOfClients + "'s IP-address is: " + inetAddress.getHostAddress() + "\n");

            new Thread(
                    new ClientTask(socket, game, "Multithreaded Server")
            ).start();
        }
    }
}
