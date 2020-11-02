package application;

import java.io.Serializable;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.function.Consumer;

public abstract class NetworkConnection {
	
	private Consumer<Serializable> onReceiveCallback;
	
	public NetworkConnection(Consumer<Serializable> onReceiveCallback) 
	{
		this.onReceiveCallback = onReceiveCallback;
	}

	public void startConnection() throws Exception 
	{
		
	}
	
	public void send(Serializable data) throws Exception 
	{
		
	}
	
	public void closeConnection() throws Exception
	{
		
	}

	protected abstract boolean isServer();
	protected abstract String getIP();
	protected abstract int getPort();

	private class ConnectionThread extends Thread
	{
		private Socket socket;
		private ObjectOutputStream out;

		@Override
		public void run()
		{
			try(ServerSocket server = isServer() ? new ServerSocket(getPort()) : null;
				Socket socket = isServer() ? server.accept() : new Socket(getIP(),getPort());
				ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
				ObjectInputStream in = new ObjectInputStream(socket.getInputStream()))
				{
					this.socket = socket;
					this.out = out;
					socket.setTcpNoDelay(true);
					
					while (true) {
						Serializable data = (Serializable) in.readObject();
					}
				}

			catch (Exception e) {

			}


		}
	}

}
