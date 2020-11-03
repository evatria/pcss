package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import application.dataTypes.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class ClientController extends Controller implements Initializable{
	
	@FXML
	private TextField userNameInput;
	
	@FXML
	private TextField passWordInput;
	
	@FXML
	private Button loginBtn;
	
	@FXML
	private Button createUserBtn;
	
	@FXML
	private Text invalidLoginTxt;
	
	private String userName;
	
	private String passWord;
	
	
	
	public void login(ActionEvent event)
	{
		
		this.userName = userNameInput.getText();
		this.passWord = passWordInput.getText();
		
		if (userNameInput.getText().trim().isEmpty() || passWordInput.getText().trim().isEmpty()) {
			System.out.println("Error");
			invalidLoginTxt.setText("invalidLoginTxt");
			invalidLoginTxt.setVisible(true);
		}
		
		else if (userName != null && passWord != null) {
			try {
				getConnection().send(userName);
			} catch (Exception e1) {
				e1.printStackTrace();
			}
			try {
				changeScene(event, "ChatSelector.fxml", getUser(), getConnection());
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		
	}
	
	public void createNewuser(ActionEvent event) throws IOException
	{
		UserPopUp pop = new UserPopUp();
		pop.setConnection(getConnection());
		pop.displayUser("new User", "PopUps/newUser.fxml");
	}
	

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
	}
}
