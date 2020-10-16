import javafx.animation.AnimationTimer;
import javafx.application.Application;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.stage.Stage;


public class Game extends Application {

    Projectile[] projectiles;

    //movement booleans
    boolean left = false;
    boolean right = false;
    boolean forward = false;
    boolean backward = false;

    private Pane root = new Pane(); //initializes a Pane called root
    //size of the window
    int width = 1200;
    int height = 700;


    private Tank player = new Tank(300, 300, 70, 40, "1", Color.BLUE);
    private Tank player2 = new Tank(100,100,70,40, "2", Color.BISQUE);
    Tank[] tanks = {player, player2};
    private Map map = new Map(width, height);


    private Parent createContent() { //creates the "draw" function
        root.setPrefSize(width, height); //sets width and height of window
        root.getChildren().add(player); //adds tank as a child
        root.getChildren().add(player2);
        root.getChildren().add(map);


        AnimationTimer timer = new AnimationTimer() { //everything in this is called each frame
            @Override
            public void handle(long now) {
                update();
            }
        };
        timer.start(); //starts the animationtimer
        return root; //returns the root
    }

    public void update() {


        //moves ALL bullets on the map
        for (int i = 0; i < projectiles.length; i++) {
            if (projectiles[i] != null) {
                projectiles[i].moveBullet(map);

                //removes a tank if hit
                if(projectiles[i].collision(tanks) != null){
                    //root.getChildren().remove(projectiles[i].collision(tanks));
                    //root.getChildren().remove(projectiles[i]);
                    //projectiles[i] = null;
                }
            }
        }


        //checks the lifespan and removes bullet if it is over a threshold
        int threshold = 300;
        for (int i = 0; i < projectiles.length; i++) {
            if (projectiles[i] != null && projectiles[i].getLifespan() >= threshold) {
                root.getChildren().remove(projectiles[i]);
                projectiles[i] = null;
            }
        }





        if (left) { //moves if the boolean is true, this is smoother than having the move in the start function
            player.rotateLeft();
        }
        if (right) {
            player.rotateRight();
        }
        if (forward) {
            player.moveForward();
        }
        if (backward) {
            player.moveBackward();
        }
    }


    public void start(Stage stage) throws Exception {
        Scene scene = new Scene(createContent());
        projectiles = player.getProjectiles();
        scene.setOnKeyReleased(e -> {
            switch (e.getCode()) {
                case LEFT:
                    left = false;
                    break;
                case RIGHT:
                    right = false;
                    break;
                case UP:
                    forward = false;
                    break;
                case DOWN:
                    backward = false;
                    break;
            }
        });

        scene.setOnKeyPressed(e -> { //movement switch case
            switch (e.getCode()) {
                case LEFT:
                    left = true;
                    break;
                case RIGHT:
                    right = true;
                    break;
                case UP:
                    forward = true;
                    break;
                case DOWN:
                    backward = true;
                    break;
                case SPACE:
                    Projectile p = player.shoot();
                    projectiles = player.getProjectiles();
                    if (p != null) {
                        root.getChildren().add(p);
                    }
                    break;
            }
        });
        stage.setScene(scene);
        stage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
