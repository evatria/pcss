package application;

import java.io.IOException;

import application.dataTypes.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

public class Controller {
	
	private User user;
	
	public void changeScene(ActionEvent event, String FXML, User user) throws IOException
	{
		FXMLLoader loader = new FXMLLoader();
		loader.setLocation(getClass().getResource(FXML));
		AnchorPane chatRoot = (AnchorPane)loader.load();
		Scene chat = new Scene(chatRoot);
		chat.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chat);
		Controller controller = (Controller) loader.getController();
		controller.setUser(this.user);
		window.show();
	}
	
	
	public void changeScene(MouseEvent event, String FXML, User user) throws IOException
	{
		FXMLLoader loader = new FXMLLoader();
		loader.setLocation(getClass().getResource(FXML));
		AnchorPane chatRoot = (AnchorPane)loader.load();
		Scene chat = new Scene(chatRoot);
		chat.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		
		Stage window= (Stage)((Node)event.getSource()).getScene().getWindow();
		
		window.setScene(chat);
		Controller controller = (Controller) loader.getController();
		controller.setUser(this.user);
		window.show();
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
}
