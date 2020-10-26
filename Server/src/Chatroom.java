import java.util.ArrayList;
import java.util.Random;

public class Chatroom {
	
	private String name;
	
	private int chatID;
	
	private ArrayList<User> users = new ArrayList<>();
	
	private User creator;
	
	private ChatHistory chatHistory;
	
	Chatroom(User user, String name){
		
		this.creator = user;
		this.name = name;
		
		Random rd = new Random();
        this.chatID = rd.nextInt();
	}
	
	public String getRoomName() {
		
		return this.name;
		
	}
	
	public int getChatID() {
		
		return chatID;
	}
	
    public String getCreatorName() {
    	
		return this.creator.getUsername();
		
	}
    
    public ArrayList<String> getUsernames() {
    	
    	ArrayList<String> usernames = new ArrayList<>();
    	
    	for(int i: users) {
    		usernames.add(users.get(i).getUsername);
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
