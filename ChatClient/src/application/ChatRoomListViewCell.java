package application;

import java.io.IOException;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Label;
import javafx.scene.control.ListCell;
import javafx.scene.layout.AnchorPane;

public class ChatRoomListViewCell extends ListCell<Chatroom>{

	@FXML
	Label chatRoomName;
	
	@FXML
	Label chatRoomUsers;
	
	@FXML
	AnchorPane pane;
	
	FXMLLoader mLLoader;
	
	@Override
    protected void updateItem(Chatroom chatroom, boolean empty) 
	{
        super.updateItem(chatroom, empty);
        
        if(empty || chatroom == null) 
        {

            setText(null);
            setGraphic(null);

        } 
        else 
        {
        	if (mLLoader == null) {
                mLLoader = new FXMLLoader(getClass().getResource("ChatRoomListView.fxml"));
                mLLoader.setController(this);

                try {
                    mLLoader.load();
                } catch (IOException e) {
                    e.printStackTrace();
                }

            }
        	
        	chatRoomName.setText(chatroom.getChatroomName());
        	chatRoomUsers.setText(chatroom.getUsersAsString());
        	
        	setGraphic(pane);
        	
        }
	}
}
