import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.scene.transform.Rotate;

public class Tank extends Rectangle {
    boolean dead = false;
    private int angle = 0;
    private int angleIncrease = 3;
    private int moveSpeed = 5;
    private Projectile[] projectiles = new Projectile[10];
    final String playerID; //either bullet or player

    Tank(int x, int y, int w, int h, String playerID, Color color) { //constructor
        super(w, h, color);
        this.playerID = playerID;
        setTranslateX(x);
        setTranslateY(y);
    }

    public Projectile[] getProjectiles() {
        return projectiles;
    }

    Projectile shoot() {
        for(int i = 0; i < projectiles.length; i++){
            if(projectiles[i] == null){
                int x = ((int)getTranslateX()+(int)this.getWidth()/2);
                int y = ((int)getTranslateY()+(int)this.getHeight()/2);
                Projectile p = new Projectile(x,y, this);
                projectiles[i] = p;
                return projectiles[i];
            }
        }
        return null;
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

    public int getAngle() {
        return angle;
    }

}
