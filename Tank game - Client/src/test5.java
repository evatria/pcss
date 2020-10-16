import javafx.animation.AnimationTimer;
import javafx.application.Application;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Rectangle;
import javafx.scene.transform.Rotate;
import javafx.stage.Stage;
import java.util.List;
import java.util.stream.Collectors;

public class test5 extends Application {
    private Pane root = new Pane();


    private Sprite player = new Sprite(300, 300, 70, 40, "player", Color.BLUE);


    private Parent createContent() {
        root.setPrefSize(1200, 700);
        root.getChildren().add(player);


        AnimationTimer timer = new AnimationTimer() {
            @Override
            public void handle(long now) {
                update();
            }
        };
        timer.start();
        nextLevel();
        return root;
    }

    private void nextLevel() {
        for (int i = 0; i < 10; i++) {
            Sprite s = new Sprite(90 + i * 100, 150, 30, 30, "enemy", Color.RED);
            root.getChildren().add(s);
        }
    }

    private List<Sprite> sprites() {
        return root.getChildren().stream().map(n -> (Sprite) n).collect(Collectors.toList());
    }

    private void update() {
        sprites().forEach(s -> { //handles what happens to the sprites/bullets
            switch (s.type) {
                case "enemybullet":
                    s.moveDown();
                    if (s.getBoundsInParent().intersects(player.getBoundsInParent())) {
                        player.dead = true;
                        s.dead = true;
                    }
                    break;

                case "playerbullet":
                    final int angle = player.getAngle();
                    s.moveBullet(angle);
                    sprites().stream().filter(e -> e.type.equals("enemy")).forEach(enemy -> {
                        if (s.getBoundsInParent().intersects(enemy.getBoundsInParent())) {
                            enemy.dead = true;
                            s.dead = true;
                        }
                    });
                    break;
            }
        });

        root.getChildren().removeIf(n -> {
            Sprite s = (Sprite) n;
            return s.dead;
        });
    }

    private void shoot(Sprite who) { //shoot function, creates sprites from shooting player
        int bulletW = 5; //bullet width
        int bulletH = 5; //bullet height
        Sprite s = new Sprite((int) who.getTranslateX() + (int) who.getWidth() / 2, (int) who.getTranslateY() + (int) who.getHeight() / 2, bulletW, bulletH, who.type + "bullet", Color.BLACK);
        root.getChildren().add(s);
    }


    public void start(Stage stage) throws Exception {
        Scene scene = new Scene(createContent());

        scene.setOnKeyPressed(e -> { //movement switch case
            switch (e.getCode()) {
                case LEFT:
                    player.rotateLeft();
                    break;
                case RIGHT:
                    player.rotateRight();
                    break;
                case UP:
                    player.moveForward();
                    break;
                case DOWN:
                    player.moveBackward();
                    break;
                case SPACE:
                    shoot(player);
            }
        });
        stage.setScene(scene);
        stage.show();
    }


    private static class Sprite extends Rectangle {
        boolean dead = false;
        int angle = 0;
        int angleIncrease = 10;
        int moveSpeed = 10;
        final String type; //either bullet or player


        Sprite(int x, int y, int w, int h, String type, Color color) { //constructor
            super(w, h, color);
            this.type = type;
            setTranslateX(x);
            setTranslateY(y);
        }

        Sprite(int x, int y, int w, int h, String type, Color color, int angle) { //constructor
            super(w, h, color);
            this.type = type;
            setTranslateX(x);
            setTranslateY(y);
        }

        void rotateLeft() { //function for rotating a sprite left, pivoting around its middle
            getTransforms().add(new Rotate(-angleIncrease, getX() + getWidth() / 2, getY() + getHeight() / 2));
            angle += -angleIncrease;
        }

        void rotateRight() { //function for rotating a sprite right, pivoting around its middle
            getTransforms().add(new Rotate(+angleIncrease, getX() + getWidth() / 2, getY() + getHeight() / 2));
            angle += angleIncrease;
        }

        void moveForward() {
            double angleR = Math.toRadians(angle);
            setTranslateX(getTranslateX() + moveSpeed * Math.cos(angleR));
            setTranslateY(getTranslateY() + moveSpeed * Math.sin(angleR));
        }

        void moveBackward() {
            double angleR = Math.toRadians(angle);
            setTranslateX(getTranslateX() - moveSpeed * Math.cos(angleR));
            setTranslateY(getTranslateY() - moveSpeed * Math.sin(angleR));
        }

        void moveBullet(int angleB) {
            double angleR = Math.toRadians(angleB);
            setX(getX() + moveSpeed * Math.cos(angleR));
            setY(getY() + moveSpeed * Math.sin(angleR));
        }

        int getAngle() {
            return angle;
        }

        void moveLeft() {
            setTranslateX(getTranslateX() - 5);
        }

        void moveRight() {
            setTranslateX(getTranslateX() + 5);
        }

        void moveUp() {
            setTranslateY(getTranslateY() - 5);
        }

        void moveDown() {
            setTranslateY(getTranslateY() + 5);
        }
    }


    public static void main(String[] args) {
        launch(args);
    }
}

