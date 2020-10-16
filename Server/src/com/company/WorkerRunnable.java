package src.com.company;
import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.*;
import java.util.Date;

/**

 */
public class WorkerRunnable implements Runnable{

    protected Socket clientSocket = null;
    protected String serverText   = null;

    public WorkerRunnable(Socket clientSocket, String serverText) {
        this.clientSocket = clientSocket;
        this.serverText   = serverText;
    }

    public void run() {
        int port = 8000;

        try {
            // Create a server socket
            ServerSocket serverSocket = new ServerSocket(port);
            System.out.println("Server IP address: " + Inet4Address.getLocalHost().getHostAddress());

            Socket connectToClient = serverSocket.accept();

            // client number
            System.out.println("Connected to client " + "at " + new Date() + "\n");

            // input and output streams
            DataInputStream isFromClient = new DataInputStream(connectToClient.getInputStream());
            DataOutputStream isToClient = new DataOutputStream(connectToClient.getOutputStream());

            while (true) {

                // Calculations made by server
                double testData = isFromClient.readDouble();
                testData += 1;

                //send back to client
                isToClient.writeDouble(testData);
            }



            } catch (IOException e) {
                e.printStackTrace();
            }
    }
}