import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.scene.transform.Rotate;

public class Sprite extends Rectangle {
    boolean dead = false;
    private int angle = 0;
    private int angleIncrease = 10;
    private int moveSpeed = 10;
    final String type; //either bullet or player

    Sprite(int x, int y, int w, int h, String type, Color color) { //constructor
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

    public int getAngle() {
        return angle;
    }




}
