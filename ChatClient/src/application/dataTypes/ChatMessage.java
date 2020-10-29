package application.dataTypes;

public class ChatMessage{
	
	private String message;
	
	private User user;
	
	
	public ChatMessage(String msg, User user)
	{
		this.message = msg;
		this.user = user;
	}

	public String getMessage() {
		return message;
	}

	public void setMessage(String message) {
		this.message = message;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

}
