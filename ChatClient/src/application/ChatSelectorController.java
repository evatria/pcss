package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.util.Callback;


public class ChatSelectorController implements Initializable{
	
	
	public void changeSceen(ActionEvent event) throws IOException
	{
		AnchorPane chatRoot = (AnchorPane)FXMLLoader.load(getClass().getResource("Chat.fxml"));
		Scene chat = new Scene(chatRoot);
		chat.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chat);
		window.show();
	}

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub

		/*
		workNow.setItems(ChatRoomTempObservableList);
		workNow.setCellFactory(new Callback<ListView<ChatRoomTemp>, ListCell<ChatRoomTemp>>() {
		    @Override
		    public ListCell<ChatRoomTemp> call(ListView<ChatRoomTemp> ChatRoomListView) {
		        return new ListCell<ChatRoomTemp>();
		    }
		});
		*/
	}

	@FXML
	private Button createRoomBtn;
	
	@FXML
	private ListView<String> roomList;
	
	/*
	private ObservableList<ChatRoomTemp> ChatRoomTempObservableList;

	public ChatSelectorController() {
		
		ChatRoomTempObservableList = FXCollections.observableArrayList();
		
		ChatRoomTempObservableList.addAll(
				new ChatRoomTemp("Test", "Test discription"),
				new ChatRoomTemp("Test2", "Test discription"),
				new ChatRoomTemp("Test3", "Test discription")
				);
	}
	*/


	public void createRoomBtn(ActionEvent event) {
		
		System.out.println("Room btn works");
		this.roomList.getItems().add("Room");
	}


	
}
