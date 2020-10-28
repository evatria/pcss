package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;

public class ClientController implements Initializable{
	
	@FXML
	private TextField userNameInput;
	
	@FXML
	private TextField passWordInput;
	
	@FXML
	private Button loginBtn;
	
	@FXML
	private Button createUserBtn;
	
	private String userName;
	
	private String passWord;
	
	
	
	public void login(ActionEvent event)
	{
		this.userName = userNameInput.getText();
		this.passWord = passWordInput.getText();
		
	}
	
	public void createNewuser(ActionEvent event) throws IOException
	{
		UserPopUp pop = new UserPopUp();
		pop.display("new User");
		System.out.print("Done");
	}
	

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
	}
}
