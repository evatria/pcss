package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

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
		try {
			changeSceen(event);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		
	}
	
	public void createNewuser(ActionEvent event) throws IOException
	{
		UserPopUp pop = new UserPopUp();
		pop.display("new User");
		System.out.print("Done");
	}
	
	public void changeSceen(ActionEvent event) throws IOException
	{
		AnchorPane chatRoot = (AnchorPane)FXMLLoader.load(getClass().getResource("ChatSelector.fxml"));
		Scene chat = new Scene(chatRoot);
		chat.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chat);
		window.show();
	}
	

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
	}
}
