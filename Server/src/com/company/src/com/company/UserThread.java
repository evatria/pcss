package src.com.company.src.com.company;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class UserThread extends Thread {
    
    private Server server;
	private Socket socket;
	private String playerID;
	private DataOutputStream output;
	private DataInputStream input;
    private boolean readyCheck;
    public static Database database = new Database();

	public UserThread(Server server, Socket socket) {
        this.server = server;
		this.socket = socket;
	
    }
    
	@Override
	public void run() {
		try {
			input = new DataInputStream(socket.getInputStream());
			output = new DataOutputStream(socket.getOutputStream());
			playerID = input.readUTF();
			System.out.println(playerID + " joined the server");
			database.addPlayer(playerID);

			while(true){
				String commandType = input.readUTF();
				if(commandType.equals("sendSubLobby")){
					recieveSubLobby();
				}
				if(commandType.equals("..")); //Her skal indsættes kode til at sende lobbylist til client.


			}

			/*while (readyCheck) {
				String clientMessage = input.readUTF();
				server.sendToAll(playerID + ": " + clientMessage, this);
				if(clientMessage.equalsIgnoreCase("quit")) {
					server.sendToAll(playerID + " disconnected from the server", this);
					server.removeUser(this, playerID);
					socket.close();

					readyCheck = false;

				}
			}*/

		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	public void recieveSubLobby() throws IOException {
		String lobbyName = input.readUTF();
		String host = input.readUTF();
		
		// int len = input.readInt();
		List<String> players = new ArrayList<>();
		players.add(host);
		database.addLobby(lobbyName, host, players);
		// for(int i = 0; i<len; i++){
		// 	players.add(input.readUTF());
		// }

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
}