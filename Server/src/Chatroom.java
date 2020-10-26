import java.util.Random;

public class Chatroom {
	
	private String name;
	
	private int chatID;
	
	private User[] users;
	
	private User creator;
	
	private ChatHistory chatHistory;
	
	Chatroom(User user_temp, String name_temp){
		
		this.creator = user_temp;
		this.name = name_temp;
		
		Random rd = new Random();
        this.chatID = rd.nextInt();
	}
	
	public String getRoomName() {
		
		return this.name;
		
	}
	
    public String getCreatorName() {
    	
		return this.creator.getUsername();
		
	}
    
    public String[] getUsernames() {
    	
    	String[] usernames;
    	
    	for(int i: users) {
    		usernames.
    	}
    	
 		return usernames;
 		
 	}
	
	public String displayMessage(User user, String message) {
		
		return user.getName + ": " + message;
		
	}
	
	public void sendMessage(String message) {
		
		chatHistory.add(displayMessage());
		
	}

}
