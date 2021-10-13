package ClientTest;

import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.ServerSocket;
import java.util.Scanner;
public class Client {

	static ArrayList<QuestionBlock> questionBlock = new ArrayList<QuestionBlock>();
	
	
	public static void main(String[]args) throws IOException, ClassNotFoundException {
        String Host = "172.20.10.2";
        int port = 9696;
        
        //Connecting and printing proof
        Socket socket = new Socket(Host, port);
        DataInputStream input = new DataInputStream(socket.getInputStream());
        System.out.println("Amogus");
        //Function for printing out questions
        for(int i = 0; i < 4; i++) {
        	questionBlock.add(new QuestionBlock(input.readUTF(),input.readUTF(),input.readInt(),input.readInt()));
        	System.out.println(questionBlock.get(i).toString());
        }

        }
       
    }


