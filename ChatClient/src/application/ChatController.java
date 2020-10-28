package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.event.Event;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.TextArea;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class ChatController implements Initializable{
	
	
	public void changeSceen(ActionEvent event) throws IOException
	{
		AnchorPane chatSelectorRoot = (AnchorPane)FXMLLoader.load(getClass().getResource("ChatSelector.fxml"));
		Scene chatSelector = new Scene(chatSelectorRoot);
		chatSelector.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chatSelector);
		window.show();
	}

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		
		roomNametxt.setText("Chad Room"); 							//**Test for changing Chat Room name**
		
	}

	//FXML imports 
	@FXML
	private ListView<String> chatDisplayList;
	
	@FXML
	private Button sendbtn;
	
	@FXML
	private TextArea chatField;
	
	@FXML
	private Text roomNametxt;
	

	
	
	//Send by pressing the button
	public void sendbtn(ActionEvent event) {
		sendMessage();
	}
	
	//Send by pressing "Enter"
	public void sendField(KeyEvent keyEvent) {
				
		if (keyEvent.getCode() == KeyCode.ENTER) {
			sendMessage();
		}
	}

	//Method for sending message to list
	public void sendMessage() {
		String message = chatField.getText();
		
		if (message != null) {
			chatField.setText(null);
			this.chatDisplayList.getItems().add(message);
		}
		
		else {
			System.out.println("No message sent. Message was: " + message);
		}
	}
}
