package application;


import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class popUpController {
	
	@FXML
	private TextField userNameInput;
	
	@FXML
	private TextField passWordInput;
	
	@FXML
	private Button createUserBtn;
	
	private String newUserName;
	
	private String newPassWord;
	
	public void login(ActionEvent event)
	{
		if (this.userNameInput != null && this.passWordInput.getText() != null) 
		{
			this.newUserName = this.userNameInput.getText();
			this.newPassWord = this.passWordInput.getText();
		}

		((Stage)(((Button)event.getSource()).getScene().getWindow())).close(); 
	}

}
