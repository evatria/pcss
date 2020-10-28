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
	
			
			if(i.getChatId() == chatroom.getChatId()) {
				
				chatrooms.remove(i);

		}
	}
  }
}