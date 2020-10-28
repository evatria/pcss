package application;

import java.io.IOException;
import java.nio.file.Path;

import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class UserPopUp {
	
	public String display(String title, String FXML) throws IOException
	{
		String outCome = null;
		Stage window = new Stage();
		FXMLLoader loader = new FXMLLoader();
		loader.setLocation(getClass().getResource(FXML));
		window.initModality(Modality.APPLICATION_MODAL);
		AnchorPane root = (AnchorPane)loader.load();
		Scene popUp = new Scene(root);
		popUp.getStylesheets().add(getClass().getResource("application.css").toExternalForm());

		window.setScene(popUp);
		window.setTitle(title);
		window.setMinWidth(250);
		window.showAndWait();
		if (FXML.compareTo("PopUps/newUser.fxml") == 0)
		{
			NewUserController controller = loader.getController();
			outCome = controller.getUserPass();
		}
		else if (FXML.compareTo("PopUps/newChatroom.fxml") == 0)
		{
			NewChatroomController controller = loader.getController();
			outCome = controller.newChatName;
		}
		return outCome;
	}

}
