
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Date;

public class Server {
	private int port;
	private ArrayList<UserThread> users;

	public Server(int port) {
		this.port = port;
		users = new ArrayList<>();
	}

	public static void main(String[] args) {
		Server server = new Server(69);
		server.initiateServer();
	}

	public void initiateServer() {
		try {
			ServerSocket serverSocket = new ServerSocket(port);
			System.out.println("Server started at " + new Date());

			while (true) {
				Socket socket = serverSocket.accept();
				UserThread newUser = new UserThread(this, socket);
				users.add(newUser);
				newUser.start();
			}

		} catch (IOException e) {
			System.out.println("Unable to start server IOException");
			e.printStackTrace();
		}
	}

	public ArrayList<UserThread> getUsers() {
		return users;
	}

	public void removeUser(UserThread ut) {
		users.remove(ut);
	}

	public void sendToAll(String message, UserThread ut) {
		for (UserThread userThread : users) {
			if (userThread != ut)
				userThread.sendMessage(message);
		}
	}

}
