import java.io.FileWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.RandomAccessFile;


public class UserDataBase {

	String fileSeparator = System.getProperty("file.separator");
	
	String supUsers = fileSeparator+"Server"+fileSeparator+"src"+fileSeparator+"userList.txt";
	File userList = new File(supUsers);
	
	if(usernamelist.createNewFile()) {
		System.out.println(userList+"File created");
	}else
		System.out.println("File"+usernamelist+"already exists");
	
	
	FileWriter usernameWriter = new FileWriter("usernamelist.txt");
	FileWriter passwordWriter = new FileWriter("E/demo.txt");
	
	private String[] usernames;
	private String[] passwords;
	private String[] ids;
	int ln;
	

	
	void makeFile() {
		if(!userList.exists()) {
			userList.mkdirs();
			
		}
	}
	
	void readFile() {
		try{
			FileReader fr = new FileReader(userList);
			System.out.println("File exists");
		} catch (FileNotFoundException ex) {
			FileWriter fw = new FileWriter(userList);
		}
		
		
		
	}
	
	
	public void getUser(){
		
	}
	
	public void createUser(String username, String password) {
		
		RandomAccessFile raf = new RandomAccessFile(userList, "rw");
		for (int i = 0 ; i<ln;i++) {
			raf.readLine();
		}
		raf.writeBytes("Username:"+User.username+"\r\n");
		raf.writeBytes("Password:"+User.password+"\r\n");
		raf.writeBytes("\r\n");
	
	}
	
	void deleteUser() {
		
	}
	
}
