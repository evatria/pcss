import java.util.Random;

public class Chatroom {
	
	private String name;
	
	private int chatID;
	
	private User[] users;
	
	private user creator;
	
	Chatroom(User user_temp, String name_temp){
		
		creator = user_temp;
		name = name_temp;
		
		Random rd = new Random();
        chatID = rd.nextInt();
        
	}
	
	public String getName() {
		
		return name;
		
	}
	
    public String getCreatorName() {
    	
		return user.getName();
		
	}
    
    public String[] getCreatorName() {
    	
		return users.getNames();
		
	}
	
	public void displayMessage(User user, String message) {
		
		int index = 0;
		
		System.out.println(users[index].getName + ": " + message);
		
	}
	
	public void sendMessage(String message) {
		chatHis.add(message);
	}

}
