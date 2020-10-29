package application;


import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class NewUserController implements Initializable{
	
	@FXML
	private TextField newUserNameInput;
	
	@FXML
	private PasswordField newPassWordInput;
	
	@FXML  
	private Button newCreateUserBtn;
	
	@FXML
	private Text popErrorNameTxt;
	
	private String userPass;
	
	public void createNewUser(ActionEvent event)
	{
		
		if (newUserNameInput.getText().trim().isEmpty() && newUserNameInput.getPromptText() != null || newPassWordInput.getText().trim().isEmpty() && newPassWordInput.getPromptText() != null){
			popErrorNameTxt.setText("Test");
			System.out.println("Error");
		}
		
		
		else if (this.newUserNameInput.getText() != null && this.newUserNameInput.getText() != null) 
		{
			setUserPass(this.newUserNameInput.getText()+ (" ") + this.newPassWordInput.getText());
			System.out.println("It saved... "+ userPass);
			((Stage)(((Button)event.getSource()).getScene().getWindow())).close(); 
		}
	}
	public void userExists()
	{
		popErrorNameTxt.setVisible(true);
	}


	public String getUserPass() {
		return userPass;
	}

	private void setUserPass(String userPass) {
		this.userPass = userPass;
	}
	
	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		popErrorNameTxt.setVisible(false);
	}

}
