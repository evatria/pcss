import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.InetAddress;
import java.net.Socket;

public class ClientTask implements Runnable {

    Socket socket = null;
    String serverText = "";
    Game game;

    InetAddress inetAddress;

    ClientTask(Socket socket, Game game, String serverText) {
        this.socket = socket;
        this.game = game;
        this.serverText = serverText;
        inetAddress = socket.getInetAddress();
    }

    @Override
    public void run() {
        //> The loan will be calculated in here
        try {
            //Creating input and output streams
            DataInputStream input = new DataInputStream(socket.getInputStream());
            DataOutputStream output = new DataOutputStream(socket.getOutputStream());

            //Sending all the questionblock variables
            game.transferBlockOut(socket, output);

            //Receiving name of the first user
            //game.loadPlayerInfo(socket, input);

        } catch (IOException e) {
            e.printStackTrace();
            System.out.println("Some in-/output went wrong!");
        }
    }
}