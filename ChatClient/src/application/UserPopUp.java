package application;

import java.io.IOException;

import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class UserPopUp {
	
	public void display(String title, String FXML) throws IOException
	{
		Stage window = new Stage();
		
		window.initModality(Modality.APPLICATION_MODAL);
		AnchorPane root = (AnchorPane)FXMLLoader.load(getClass().getResource(FXML));
		Scene popUp = new Scene(root);
		popUp.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		window.setScene(popUp);
		window.setTitle(title);
		window.setMinWidth(250);
		window.show();
	}

}
