package application;

import java.util.ArrayList;

import application.dataTypes.ChatMessage;

public class ChatUpdateThread implements Runnable {

	private boolean bool;
	private NetworkConnection connection;
	
	@Override
	public void run() {
		bool = true;
		
		while(bool) {
			try {
				getConnection().receive();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
		
	}
	
	public ChatUpdateThread(NetworkConnection connection, ArrayList<ChatMessage> list, int roomID) {
		
	}
	
	public void stop() {
		bool = false;
	}

	public NetworkConnection getConnection() {
		return connection;
	}

	public void setConnection(NetworkConnection connection) {
		this.connection = connection;
	}

}
