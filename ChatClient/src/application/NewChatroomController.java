package application;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class NewChatroomController {
	
	@FXML
	private Button createChatBtn;
	
	@FXML
	private TextField chatName;
	
	@FXML
	private Text popErrorRoomTxt;
	
	private String newChatName;
	
	public void create(ActionEvent event)
	{
		if (chatName.getText().trim().isEmpty()) {
			System.out.println("Error");
			popErrorRoomTxt.setText("Error: Missing room name");
			popErrorRoomTxt.setVisible(true);
		}
		
		else if (this.chatName.getText() != null && this.chatName.getText() != null) 
		{
			this.setNewChatName(this.chatName.getText());
			((Stage)(((Button)event.getSource()).getScene().getWindow())).close(); 
			
		}
		


	}
	
	public void roomExists()
	{
		popErrorRoomTxt.setText("Error: Room name already exist");
		popErrorRoomTxt.setVisible(true);
	}

	public String getNewChatName() {
		return newChatName;
	}

	public void setNewChatName(String newChatName) {
		this.newChatName = newChatName;
	}
	
	
}
