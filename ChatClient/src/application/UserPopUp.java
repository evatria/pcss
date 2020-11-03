package application;

import java.io.IOException;

import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class UserPopUp {
	
	private NetworkConnection connection;
	
	public void displayUser(String title, String FXML) throws IOException
	{
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
		window.show();
		Controller controller = (Controller) loader.getController();
		controller.setConnection(connection);

	}

	public NetworkConnection getConnection() {
		return connection;
	}

	public void setConnection(NetworkConnection connection) {
		this.connection = connection;
	}
	
	public String displayChatroom(String title, String FXML) throws IOException
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

        if (FXML.compareTo("PopUps/newChatroom.fxml") == 0)
        {
            NewChatroomController controller = loader.getController();
            outCome = controller.getNewChatName();
        }
        return outCome;
    }
}
