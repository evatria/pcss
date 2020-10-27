package src.com.company;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class UserThread extends Thread {
    
    private Server server;
	private Socket socket;
	private String userName;
	private DataOutputStream output;
	private DataInputStream input;
	private boolean readyCheck;
	
	public UserThread(Server server, Socket socket) {
        this.server = server;
		this.socket = socket;
	
    }
    
	@Override
	public void run() {
		try {
			input = new DataInputStream(socket.getInputStream());
			output = new DataOutputStream(socket.getOutputStream());
			userName = input.readUTF();
			System.out.println(userName + " joined the server");
			server.sendToAll(userName + " joined the server.", this);

			readyCheck = true;

			


			while (readyCheck) {
				String clientMessage = input.readUTF();
				server.sendToAll(userName + ": " + clientMessage, this);
				if(clientMessage.equalsIgnoreCase("quit")) {
					server.sendToAll(userName + " disconnected from the server", this);
					server.removeUser(this, userName);
					socket.close();

					readyCheck = false;

				}
				if(clientMessage.equalsIgnoreCase("ready")) {
					server.sendToAll(userName + " is ready", this);
					readyCheck = false;
					//System.out.println(clientMessageDouble);
					//server.startGame();
				}
			
				

			}

			while (true) {
				String clientMessage = input.readUTF();
				

				if (clientMessage.equals("INFO")){
				
					
					int x = input.readInt();
					System.out.println("X: "+x);
					int y = input.readInt();
					System.out.println("Y: "+y);
					int a = input.readInt();
					System.out.println("A: "+a);
					server.sendToAll("INFO", this);
					server.sendToAllInts(x, this);
					server.sendToAllInts(y, this);
					server.sendToAllInts(a, this);
				}

				if (clientMessage.equals("BULLET")){
					System.out.println("BULLET!!!!!!!!!!!!!!!!!!!!!!!");
					
					server.sendToAll("BULLET", this);

				}
			}

			

		} catch (IOException e) {
			e.printStackTrace();
		}
	}


    public void sendMessage(String message) {
		try {
			output.writeUTF(message);
			output.flush();
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void sendInt(int messageint) {
		try {
			output.writeInt(messageint);
			output.flush();
		} catch (Exception e) {
			//TODO: handle exception
			e.printStackTrace();
		}
	}
    
    public boolean isReadyCheck() {
		return readyCheck;
    }
    
}