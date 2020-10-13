package company;
import java.util.Scanner;
import java.net.*;
import java.io.*;



public class ServerTestClient {

    public static void main(String[] args) {
        DataOutputStream toServer = null;
        DataInputStream fromServer = null;
        int port = 8000;
        // ipv4 address for server
        String host = "192.168.43.236";
        boolean Continue = true;
        Socket socket = null;


        try {
            socket = new Socket(host, port);
            System.out.println("Connection to server established ");
            toServer = new DataOutputStream(socket.getOutputStream());
            fromServer = new DataInputStream(socket.getInputStream());
            objectToServer = new ObjectInputStream(socket.getInputStream());
            objectFromServer = new ObjectOutputStream(socket.getOutputStream());

            while (Continue == true) {

                Scanner testScanner = new Scanner();
                objectToServer.writeUTF(testScanner);

                testData = objectFromServer.readString();
                System.out.println(testData);

            }
        }

            catch (IOException e) {
            e.printStackTrace();
        }



    }
}

