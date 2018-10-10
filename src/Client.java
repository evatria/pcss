import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Client {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);

		try {
			Socket socket = new Socket("localhost", 69);

			DataOutputStream output = new DataOutputStream(socket.getOutputStream());
			DataInputStream input = new DataInputStream(socket.getInputStream());

			System.out.print("write your user name");
			output.writeUTF(scan.nextLine());

			while (true) {
				String temp = input.readUTF();
				System.out.println(temp);
			}

		} catch (IOException ex) {
			System.out.println(ex.toString() + '\n');
		}
	}

}
