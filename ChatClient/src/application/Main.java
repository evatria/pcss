package application;
	
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;


public class Main extends Application {
	@Override
	public void start(Stage primaryStage) {
		try {
			FXMLLoader loader = new FXMLLoader(getClass().getResource("Client.fxml"));
			AnchorPane root = (AnchorPane)loader.load();
			Scene login = new Scene(root);
			login.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
			primaryStage.setScene(login);
			primaryStage.show();
			
		} catch(Exception e) {
			e.printStackTrace();
		}
		connect();
	}
	
	public static void main(String[] args) {
		launch(args);
	}
	
	public void connect() 
	{
		int port = 8000;
		String host = "localhost";
		DataInputStream in;
		DataOutputStream out;
		Socket socket;
		Scanner input = new Scanner(System.in);
		boolean connect = true;
		
		try {
		
		
			socket = new Socket(host, port);
			in = new DataInputStream(socket.getInputStream());
			out = new DataOutputStream(socket.getOutputStream());
			
			while(connect) 
			{
			}
			out.writeChar('c');
			input.close();
			socket.close();
			
		}
		catch (IOException ex) {
			System.out.println(ex.toString() + '\n');
		}	
	}
}
