package application;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

public class NewChatroomController {
	
	@FXML
	private Button createUserBtn;
	
	@FXML
	private TextField chatName;
	
	private String newChatName;
	
	public void create(ActionEvent event)
	{
		if (this.chatName != null ) 
		{
			this.setNewChatName(this.chatName.getText());
		}
		

		((Stage)(((Button)event.getSource()).getScene().getWindow())).close(); 
	}

	public String getNewChatName() {
		return newChatName;
	}

	public void setNewChatName(String newChatName) {
		this.newChatName = newChatName;
	}
}
