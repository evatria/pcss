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

			boolean connect = true;
			while (connect) {
				String clientMessage = input.readUTF();
				server.sendToAll(userName + ": " + clientMessage, this);
				if(clientMessage.equalsIgnoreCase("quit")) {
					server.sendToAll(userName + " disconnected from the server", this);
					server.removeUser(this, userName);
					socket.close();
					connect = false;
					
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
}
