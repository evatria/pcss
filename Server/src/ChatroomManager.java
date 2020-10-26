public class ChatroomManager {
	
	
	private Chatroom[] chatrooms = new Chatroom[];
	
	
	public void createChatroom(User user, String name) {
		
		Chatroom newChatroom;
		
		newChatroom = new Chatroom(user,name);
		
		chatrooms.add(newChatroom);
		
	}
	
	public void deleteChatroom(Chatroom chatroom) {
		
		for(int i : chatrooms) {
			if(chatrooms[i].equals(chatroom)) {
				chatrooms.delete(i);
		}
			
	}
}
}
