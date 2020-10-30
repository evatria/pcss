package application;

import java.io.Serializable;
import java.util.function.Consumer;

public abstract class ClientConnection {
	
	private Consumer<Serializable> onReceiveCallback;
	
	public ClientConnection(Consumer<Serializable> onReceiveCallback) 
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
	

}
