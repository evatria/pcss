package application;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
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
		
	}

}
