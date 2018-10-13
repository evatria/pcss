import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Client {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);

		try {
			Socket socket = new Socket("localhost", 6969);

			DataOutputStream output = new DataOutputStream(socket.getOutputStream());
			DataInputStream input = new DataInputStream(socket.getInputStream());

			System.out.println("Successfully joined the server");
			System.out.print("Type your user name: ");

			output.writeUTF(scan.nextLine());
			output.flush();

			
			new Thread(() -> {
				boolean connect = true;
				while (connect) {
					try {
						String message = scan.nextLine();
						output.writeUTF(message);
						output.flush();
						
						if(message.equalsIgnoreCase("quit")) {
							socket.close();
							connect = false;
						}
						
					} catch (IOException e) {
						e.printStackTrace();
					}
				}
			}).start();

			new Thread(() -> {
				while (true) {
					try {
						System.out.println(input.readUTF());
					} catch (IOException e) {
						System.out.println(e + " SocketException expected, do not worry");
						break;
					}
				}
			}).start();

		} catch (IOException ex) {
			System.out.println(ex.toString() + '\n');
		}

	}
}
