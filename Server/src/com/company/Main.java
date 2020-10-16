package src.com.company;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.*;
import java.util.Date;


public class Main {

    public static void main(String[] args) {

        new Thread( () -> {
            try {	      // Create a server socket
                ServerSocket serverSocket = new ServerSocket(8000);
                System.out.println("Loan Server started at " + new Date() + '\n');
                System.out.println("IP address: " + Inet4Address.getLocalHost().getHostAddress());
                final double testData;

                // Number a client
                int clientNo = 0;
                while (true) {

                    Socket connectToClient = serverSocket.accept();
                    clientNo++;

                    // Display the client number
                    System.out.println("Starting thread for client " + clientNo +
                            " at " + new Date() + '\n');

                    // Find the client's host name, and IP address
                    InetAddress inetAddress = connectToClient.getInetAddress();
                    System.out.println("Client " + clientNo + "'s host name is "
                            + inetAddress.getHostName() + "\n");
                    System.out.println("Client " + clientNo + "'s IP Address is "
                            + inetAddress.getHostAddress() + "\n");
                    new Thread(
                            new WorkerRunnable(
                                    connectToClient, "Multithreaded Server")
                    ).start();
                }
            }
            catch(IOException e) {
                System.err.println(e);
            }


        }).start();
    }
}
