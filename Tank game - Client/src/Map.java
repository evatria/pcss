import java.awt.*;
import java.awt.image.BufferedImage;
import javax.swing.*;

public class Map extends JPanel {

    public static void main(String[] args) {

        JFrame frame = new JFrame("My Drawing");
        frame.pack();
        frame.setVisible(true);
        frame.setSize(720,720);
        ImageIcon pic = new ImageIcon("path");
        Image tank = pic.getImage();
    }

    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
    }
}

