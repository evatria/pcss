import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Rectangle;
import javafx.scene.text.Font;
import javafx.scene.text.Text;
import javafx.stage.Stage;

import java.awt.event.KeyEvent;
import java.awt.event.MouseEvent;


public class Main extends Application {

    public static void main(String[] args) {
        Application.launch(args);
    }

    int x = 25;
    int y = 25;

    @Override
    public void start(Stage stage) throws Exception {
        Group root = new Group();
        Scene scene = new Scene(root, 500, 500);

        stage.setTitle("Welcome to JavaFX!");
        stage.setScene(scene);
        stage.sizeToScene();
        stage.show();

        Rectangle r = new Rectangle(x, y, 250, 250);
        r.setFill(Color.AQUA);

        root.getChildren().add(r);

        scene.addEventListener(KeyEvent, keyEvent -> {
            System.out.println(keyEvent);
        });
    }

}
