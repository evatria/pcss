import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;

public class Map extends Rectangle {
    final static Color color = Color.GRAY;
    final static int width = 100;
    final static int height = 100;



    Map(int x, int y){
        super();
        //setHeight(height);
        //setWidth(width);
        setTranslateX(x);
        setTranslateY(y);
    }

    void createMap(){

    }
}

