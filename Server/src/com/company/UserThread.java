package src.com.company;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;

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
					server.startGame();
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
		} catch (IOException e) {
			e.printStackTrace();
		}
    }
    
    public boolean isReadyCheck() {
		return readyCheck;
    }
    
}