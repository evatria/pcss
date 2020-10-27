import java.io.FileWriter;
import java.io.File;
import java.io.IOException;


public class UserDataBase {

	FileWriter usernameWriter = new FileWriter("E/demo.txt");
	FileWriter passwordWriter = new FileWriter("E/demo.txt");
	
	private String[] usernames;
	private String[] passwords;
	private String[] ids;
	private int len = Array.length;
	
	UserDataBase(String[] usernames,  String[] passwords, String[] ids){
		this.usernames = usernames;
		this.passwords = passwords;
		this.ids = ids;
	}
	
	
	public void getUser(){
		
	}
	
	public void createUser() {
		
	}
	
	void deleteUser() {
		
	}
	
}
