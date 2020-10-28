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
	
	
	@FXML
	private ListView<Chatroom> listview;
	
	@FXML
	private Button createRoomBtn;
	
	private ObservableList<Chatroom> classroomObservableList;

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		// TODO Auto-generated method stub
		listview.setCellFactory(classRoomListView -> new ChatRoomListViewCell());

	}



	public void createRoomBtn(ActionEvent event) throws IOException {
		
		System.out.println("Room btn works");
		UserPopUp pop = new UserPopUp();
		pop.display("new User", "newUser.fxml");
	}


	
}
