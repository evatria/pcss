import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class UserThread extends Thread {
	private String userName;
	private Server server;
	private Socket socket;
	private DataOutputStream output;
	private DataInputStream input;

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
			System.out.println(userName);
			
			for (UserThread users : server.getUsers()) {
				server.sendToAll(users.userName);
			}
			
			while(true) {
				
			}
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
	public void sendMessage(String message) {
		try {
			output.writeUTF(message);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
