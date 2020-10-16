//package sample;

import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;

public class Projectile extends Circle {

    final static int MAX_SPEED = 5;
    static final int RADIUS = 5;

    private Tank player;

    private double xSpeed;
    private double ySpeed;
    public boolean dead = false;
    int angle;
    double angleR;
    int lifespan;

    Projectile(int x, int y, Tank tank) {
        super(x, y, RADIUS); //bruger constructor fra Rectangle som er superclass
        setFill(Color.HOTPINK);
        this.angle = tank.getAngle(); //henter den vinkel tanken har
        this.angleR = Math.toRadians(angle); //laver vinklen til radianer
        this.player = tank; //gemmer hvilken tank der har affyret
        setSpeed(); //kalder metoden set speed og gemmer en x og y speed
    }

    void setSpeed() { //sætter x og y speed i forhold til tankens vinkel
        this.xSpeed = MAX_SPEED * Math.cos(angleR);
        this.ySpeed = MAX_SPEED * Math.sin(angleR);
    }

    void moveBullet(Map map) {
        this.setCenterX(getCenterX() + xSpeed); //affyrer skud med dens vinkel fra setSpeed
        this.setCenterY(getCenterY() + ySpeed);
        if (this.getCenterX() > map.getTranslateX() && this.getCenterX() < map.getTranslateX() + map.getWidth() && this.getCenterY() < map.getTranslateY() && this.getCenterY() < map.getTranslateY() + map.getHeight() && this.getBoundsInParent().intersects(map.getBoundsInParent())) {
            ySpeed = -ySpeed; //inverter hastigheden hvis en top eller bund væg rammes
        } else if (this.getBoundsInParent().intersects(map.getBoundsInParent())) {
            xSpeed = -xSpeed; //inverter speed hvis sidevæg rammes
        }
        lifespan++; //incrementer lifespan hver frame
    }


    Tank collision(Tank[] tank){
        for (int i = 0; i < tank.length; i++) {
            if (this.getBoundsInParent().intersects(tank[i].getBoundsInParent())) {
                //lifespan = 300;
                return tank[i];
            }
        }
        return null;
    }

    public int getLifespan() {
        return lifespan;
    }
}
