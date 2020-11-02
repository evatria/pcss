package application;

import javafx.application.Application;
import javafx.application.Platform;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;


public class Main extends Application {
	
	private boolean isServer = true;
	
	private NetworkConnection connection = isServer ? createServer() : createClient();
	
	@Override
	public void start(Stage primaryStage) {
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(getClass().getResource("Client.fxml"));
			AnchorPane root = (AnchorPane)loader.load();
			Controller controller = (Controller) loader.getController();
			controller.setConnection(this.connection);
			Scene login = new Scene(root);
			login.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
			primaryStage.setScene(login);
			primaryStage.show();
			
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void init() throws Exception {
		connection.startConnection();
	}
	
	public void stop() throws Exception {
		connection.closeConnection();
	}
	
	private Server createServer() {
		return new Server(55555, data -> {
			Platform.runLater(()-> {
				
				System.out.println("create server test");
			});
		});
	}
	
	private ClientConnection createClient() {
		return new ClientConnection("127.0.0.1", 55555, data -> {
			Platform.runLater(()-> {
				
				System.out.println("create client test");
			});
		});
	}
	

	
	public static void main(String[] args) {
		launch(args);

	}

}
