package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import application.dataTypes.ChatMessage;
import javafx.event.ActionEvent;
import javafx.event.Event;
import javafx.event.EventHandler;
import javafx.event.EventType;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.SelectionMode;
import javafx.scene.control.TextArea;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class ChatController extends Controller implements Initializable{
	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		
		chatDisplayList.setCellFactory(chatRoomListView -> new ChatListCellController());
		
		EventHandler filter = new EventHandler<MouseEvent>()
			{
		    	public void handle(MouseEvent event) {
		    		event.consume();
		    	}
			};
		chatDisplayList.addEventFilter(MouseEvent.MOUSE_PRESSED, filter);

	}

	//FXML imports 
	@FXML
	private ListView<ChatMessage> chatDisplayList;
	
	@FXML
	private Button sendbtn;

	@FXML
	private Button exitChatbtn;
	
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
		ChatMessage message = new ChatMessage(chatField.getText(), getUser());
		
		if (message.getMessage() != null) {
			chatField.setText(null);
			this.chatDisplayList.getItems().add(message);
			chatDisplayList.scrollTo(chatDisplayList.getItems().size());
		}
		
		else {
			System.out.println("No message sent. Message was: " + message);
		}
	}
	
	public void goBack(ActionEvent event)
	{
		try {
			changeScene(event, "ChatSelector.fxml", getUser());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public Text getRoomNametxt() {
		return roomNametxt;
	}

	public void setRoomNametxt(String roomNametxt) {
		this.roomNametxt.setText(roomNametxt);
	}
}
