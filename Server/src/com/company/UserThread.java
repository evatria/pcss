package src.com.company;

import java.io.DataInputStream;
import java.io.DataOutputStream;
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
    
    public void sendMessage(String message) {
		try {
			output.writeUTF(message);
			output.flush();
		} 
		catch (IOException e) {
			e.printStackTrace();
		}
    }
    
    public boolean isReadyCheck() {
		return readyCheck;
    }
    
}