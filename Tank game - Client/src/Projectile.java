//package sample;
import javafx.scene.shape.Circle;

public class Projectile {

    final static int MAX_SPEED = 10;
    final static int[] BULLET_COLOR = {20,20,20};

    private Tank player = new Tank();
    private Tank[] enemies;

    private int xPos;
    private int yPos;
    private int xSpeed;
    private int ySpeed;
    private int direction;
    private int hitboxRadius;
    private boolean hit = false;

    static final int HITBOX_RADIUS = 5;


    private Circle hitboxCircle;


    Projectile(){}
    Projectile(Tank player_, Tank[] enemies_, int xPos_, int yPos){
        setPlayer(player_);
        setEnemies(enemies_);
        hitbox(xPos_, yPos);
    }





    public void hitbox(int x, int y){
        this.hitboxCircle = new Circle(getxPos(),getyPos(),this.HITBOX_RADIUS);
    }

    public void updateHitbox(int x, int y){
        this.hitboxCircle.setCenterX(this.hitboxCircle.getCenterX() + getxSpeed());
        this.hitboxCircle.setCenterY(this.hitboxCircle.getCenterY() + getySpeed());
    }




  /*  public boolean move(){
        setxPos(getxPos() + getxSpeed());
        setyPos(getyPos() + getySpeed());

        if (getxPos() == getEnemies().getXpos){
            this.hit = true;
            return true;
        }
        return false;
    }
    */























    public void setPlayer(Tank player) {
        this.player = player;
    }

    public void setEnemies(Tank[] enemies) {
        this.enemies = enemies;
    }

    public Tank[] getEnemies() {
        return enemies;
    }

    public void setxPos(int xPos) {
        this.xPos = xPos;
    }
    public int getxPos() {
        return xPos;
    }

    public void setyPos(int yPos) {
        this.yPos = yPos;
    }
    public int getyPos() {
        return yPos;
    }

    public void setDirection(int direction) {
        this.direction = direction;
    }
    public int getDirection() {
        return direction;
    }

    public void setxSpeed(int xSpeed) {
        this.xSpeed = xSpeed;
    }
    public int getxSpeed() {
        return xSpeed;
    }

    public void setySpeed(int ySpeed) {
        this.ySpeed = ySpeed;
    }
    public int getySpeed() {
        return ySpeed;
    }
}
