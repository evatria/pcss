package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import application.dataTypes.Chatroom;
import application.dataTypes.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.util.Callback;


public class ChatSelectorController extends Controller implements Initializable{
	
	
	@FXML
	private ListView<Chatroom> listview;
	
	@FXML
	private Button createRoomBtn;
	
	@FXML
	private Button logOutBtn;
	
	Chatroom currentItemSelected;

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		listview.setCellFactory(classRoomListView -> new ChatRoomListViewCell());
		
		listview.setOnMouseClicked(new EventHandler<MouseEvent>() {

		    @Override
		    public void handle(MouseEvent click) {

		        if (click.getClickCount() == 2) {
		           currentItemSelected = listview.getSelectionModel().getSelectedItem();
		           try {
		        	   changeScene(click, "Chat.fxml", getUser());
		           } catch (IOException e) {
					// TODO Auto-generated catch block
		        	   e.printStackTrace();
		           }
		        }
		    }
		});


	}
	
	public void loadChatrooms() 
	{
		for(Chatroom i: this.getUser().getChatRooms())
		{
			listview.getItems().add(i);
		}
	}
	




	public void createRoomBtn(ActionEvent event) throws IOException {
		
		System.out.println("Room btn works");
		UserPopUp pop = new UserPopUp();
		String test = pop.display("new chatroom", "PopUps/newChatroom.fxml");
		Chatroom ctm = new Chatroom(getUser(),test);
		listview.getItems().add(ctm);
		this.getUser().addChatRoom(ctm);
	}


	public void logOut(ActionEvent event)
	{
		try {
			changeScene(event, "Client.fxml");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	
}
