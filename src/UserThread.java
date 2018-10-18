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
	private int bettingCash;
	private int myBet;

	public UserThread(Server server, Socket socket) {
		this.server = server;
		this.socket = socket;
		bettingCash = 100;
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
	
	public int getMyBet() {
		return myBet;
	}
	
	public String getUserName() {
		return userName;
	}
	
	public int getBettingCash() {
		return bettingCash;
	}
	
	public boolean isReadyCheck() {
		return readyCheck;
	}
	

	
	public void sendMessage(String message) {
		try {
			output.writeUTF(message);
			output.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void sendBoolean(boolean condition) {
		try {
			output.writeBoolean(condition);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public String readString() {
		String string = "default";
		try {
			string = input.readUTF();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return string;
	}
	
	public int readInt() {
		int value = 0;
		try {
			value = input.readInt();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return value;
	}
}
