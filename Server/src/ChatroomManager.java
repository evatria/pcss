import java.util.ArrayList;

public class ChatroomManager {
	
	
	private ArrayList<Chatroom> chatrooms = new ArrayList<>();
	
	
	public void createChatroom(User user, String name) {
		
		Chatroom newChatroom;
		
		newChatroom = new Chatroom(user,name);
		
		chatrooms.add(newChatroom);
		
	}
	
	public void deleteChatroom(Chatroom chatroom) {
		
		for(Chatroom i : chatrooms) {
			
			int index = 0;
			
			if(chatrooms.get(index).getChatID() == chatroom.getChatID()) {
				
				chatrooms.remove(i);
				
		}
			
			index++;
			
	}
  }
}