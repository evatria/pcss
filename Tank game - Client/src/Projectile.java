//package sample;
import javafx.scene.shape.Circle;

public class Projectile extends Circle {

    final static int MAX_SPEED = 10;
    final static int[] BULLET_COLOR = {20, 20, 20};
    static final int HITBOX_RADIUS = 5;

    private Tank player;
    private Circle c = new Circle();
    private int xPos;
    private int yPos;
    private int xSpeed;
    private int ySpeed;
    private int hitboxRadius;
    private boolean hit = false;

    Projectile(Tank tank){
        create();
        setSpeed(tank);
    }


    void create(){
        this.c = new Circle(tank.getX()+Math.cos(tank.getAngle())*5., tank.getY()+Math.sin(tank.getAngel())*5, HITBOX_RADIUS);
    }

    void setSpeed(Tank tank){
        xSpeed =  MAX_SPEED * Math.cos(tank.getAngle());
        ySpeed = MAX_SPEED * Math.sin(tank.getAngle());
    }
    void moveBullet() {

    }



    private Circle hitboxCircle;


}
