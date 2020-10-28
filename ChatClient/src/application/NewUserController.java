package application;


import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class NewUserController {
	
	@FXML
	private TextField userNameInput;
	
	@FXML
	private TextField passWordInput;
	
	@FXML
	private Button createUserBtn;
	
	private String userPass;
	
	public void login(ActionEvent event)
	{
		if (this.userNameInput != null && this.passWordInput.getText() != null) 
		{
			setUserPass(this.userNameInput.getText()+ (" ") + this.passWordInput.getText());
		}

		((Stage)(((Button)event.getSource()).getScene().getWindow())).close(); 
	}

	public String getUserPass() {
		return this.userPass;
	}

	private void setUserPass(String userPass) {
		this.userPass = userPass;
	}

}
