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
