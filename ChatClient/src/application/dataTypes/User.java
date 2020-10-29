package application.dataTypes;

import java.util.ArrayList;
import java.util.Random;

public class User {


    private String username;
    private String password;
    private int id;
    
    private ArrayList<Chatroom> chatRooms = new ArrayList<Chatroom>();


    public User(String username, String password){
        this.username = username;
        this.password = password;

        Random cd = new Random();
        id = cd.nextInt();
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getId() {
        return id;
    }

	public ArrayList<Chatroom> getChatRooms() {
		return chatRooms;
	}

	public void setChatRooms(ArrayList<Chatroom> chatRooms) {
		this.chatRooms = chatRooms;
	}
	
	public void addChatRoom(Chatroom chatRoom) {
		this.chatRooms.add(chatRoom);
	}

}