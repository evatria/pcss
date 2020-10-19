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
    Tank[] tanks = {player, player2};//puts the tanks into an array

    private Map map = new Map(width/2, height/2);


    private Parent createContent() { //creates the "draw" function - creates a Parent and returns it
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

    public void update() {//function where everything that happens every frame is called
        //moves ALL bullets on the map
        for (int i = 0; i < projectiles.length; i++) {
            if (projectiles[i] != null) { //only does this function if there are bullets in the array
                projectiles[i].moveBullet(map);//moves bullets

                //removes a tank if hit
                if(projectiles[i].collision(tanks) != null){//only does this if there is a hit tank

                    Tank tank = projectiles[i].collision(tanks);
                    root.getChildren().remove(tank);
                    tank.setDead();
                    //root.getChildren().remove(projectiles[i].collision(tanks));//removes the tank visually
                    root.getChildren().remove(projectiles[i]);//removes the bullet visually
                    projectiles[i] = null;//removes the bullets from the array
                }
            }
        }

        //checks the lifespan and removes bullet if it is over a threshold
        int threshold = 300; //threshold - the bullets are removed after 300 frames
        for (int i = 0; i < projectiles.length; i++) {
            if (projectiles[i] != null && projectiles[i].getLifespan() >= threshold) { //only does this if there are bullets on the map and if one have been alive for 300 frames
                root.getChildren().remove(projectiles[i]); //removes the projectile child
                projectiles[i] = null; //removes projectile from array.
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
        Scene scene = new Scene(createContent()); //creates a scene with the root createContent as input
        projectiles = player.getProjectiles(); //initializes the projectile array

        //sets booleans to false if key is released
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

        //sets booleans to true if key is pressed
        scene.setOnKeyPressed(e -> {
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
        stage.setScene(scene);//creates a stage using the scene that uses the root
        stage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
