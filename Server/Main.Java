import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Date;


public class Main {
    int port = 8000;

    public static void main(String[] args) {
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