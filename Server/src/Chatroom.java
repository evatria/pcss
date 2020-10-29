import java.util.ArrayList;
import java.util.Random;

public class Chatroom {
	
	private String name;
	
	private int chatId;
	
	private ArrayList<User> users = new ArrayList<>();
	
	private User creator;
	
	//private ChatHistory chatHistory;
	
	public Chatroom(User user, String name){
		
		this.creator = user;
		this.name = name;
		
		Random rd = new Random();
        this.chatId = rd.nextInt();
	}
	
	public String getChatroomName() {
		
		return this.name;
		
	}
	
	public int getChatId() {
		
		return chatId;
	}
	
    public String getCreatorName() {
    	
		return this.creator.getUsername();
		
	}
    
    public ArrayList<String> getUsernames() {
    	
    	ArrayList<String> usernames = new ArrayList<>();
    	
    	for(User i: users) {
    		usernames.add(i.getUsername());
    	}

 		return usernames;
 		
 	}
	
	public String displayMessage(User user, String message) {
		
		return user.getUsername() + ": " + message;
		
	}
	
	public void sendMessage(String message) {
		
		//chatHistory.add(displayMessage());
		
	}
}
