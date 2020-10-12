import javafx.animation.AnimationTimer;
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.transform.Rotate;
import javafx.stage.Stage;
import javafx.scene.shape.Line;



public class Test2 extends Application {
    int move = 5;
    int circleX = 200;
    int circleY = 150;
    int angleCount = 0;
    double angleRadians;

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) {


        Circle circle = createCircle(circleX, circleY, Color.GREEN);
        Line line = createLine();
        final Group group = new Group(circle, line);
        final Scene scene = new Scene(group, 600, 400, Color.WHITE);


        moveCircleOnKeyPress(scene, circle, line);
        stage.setScene(scene);
        stage.show();
    }


    void lineMove(Line line, int angle) {
        line.getTransforms().add(new Rotate(angle, circleX, circleY));

        angleCount += angle;
        if (angleCount == 360) {
            angleCount = 0;
        }
        if (angleCount == -360) {
            angleCount = 0;
        }

        angleRadians = Math.toRadians(angleCount);
    }


    private Circle createCircle(int circleX, int circleY, Color color) {
        int radius = 30;
        final Circle circle = new Circle(circleX, circleY, radius, color);
        return circle;
    }

    private Line createLine() {
        final Line line = new Line(200, 150, 230, 150);
        return line;
    }




    private void moveCircleOnKeyPress(Scene scene, final Circle circle, final Line line) {
        scene.setOnKeyPressed(new EventHandler<KeyEvent>() {
            @Override
            public void handle(KeyEvent event) {
                switch (event.getCode()) {

                    case UP:
                        circle.setCenterX(circle.getCenterX() + move * Math.cos(angleRadians));
                        circle.setCenterY(circle.getCenterY() + move * Math.sin(angleRadians));
                        break;

                    case RIGHT:
                        lineMove(line, 10);
                        break;

                    case DOWN:
                        circle.setCenterX(circle.getCenterX() - move * Math.cos(angleRadians));
                        circle.setCenterY(circle.getCenterY() - move * Math.sin(angleRadians));
                        break;

                    case LEFT:
                        lineMove(line, -10);
                        break;

                    case SPACE:
                }
            }
        });
    }
}
