package application;

import java.io.IOException;

import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class SceneChanger {
	public void changeSceen(ActionEvent event, String FXML) throws IOException
	{
		AnchorPane chatRoot = (AnchorPane)FXMLLoader.load(getClass().getResource(FXML));
		Scene chat = new Scene(chatRoot);
		chat.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chat);
		window.show();
	}
}
