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
	
	private ObservableList<Chatroom> classroomObservableList;
	
	Chatroom currentItemSelected;

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		listview.setCellFactory(classRoomListView -> new ChatRoomListViewCell());
		
		listview.setOnMouseClicked(new EventHandler<MouseEvent>() {

		    @Override
		    public void handle(MouseEvent click) {

		        if (click.getClickCount() == 2) {
		           //Use ListView's getSelected Item
		           currentItemSelected = listview.getSelectionModel().getSelectedItem();
		           try {
		        	   changeScene(click, "Chat.fxml", getUser());
		           } catch (IOException e) {
					// TODO Auto-generated catch block
		        	   e.printStackTrace();
		           }
		           //use this to do whatever you want to. Open Link etc.
		        }
		    }
		});

	}
	




	public void createRoomBtn(ActionEvent event) throws IOException {
		
		System.out.println("Room btn works");
		UserPopUp pop = new UserPopUp();
		String test = pop.display("new chatroom", "PopUps/newChatroom.fxml");
		Chatroom ctm = new Chatroom(getUser(),test);
		listview.getItems().add(ctm);
	}



	
}
