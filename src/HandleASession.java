import java.util.Iterator;

public class HandleASession implements Runnable {

	private Server server;

	public HandleASession(Server server) {
		this.server = server;
	}

	@Override
	public void run() {
		boolean endCondition = true;
		int playersTurn = 0;
		int currentHighestBet = 10;
		int totalPot = 15;
		UserThread actingPlayer;

		while (endCondition) {
			actingPlayer = server.getUsers().get(playersTurn);
			actingPlayer.sendBoolean(true);
			for (UserThread ut : server.getUsers()) {
				if(ut != actingPlayer)
					ut.sendBoolean(false);
			}
			
			String defaultMessage = "It is currently " + actingPlayer.getUserName()
					+ "s turn. Wait until it's yours turn.";

			server.sendToAll(defaultMessage, actingPlayer);

			String message = "It's your acting turn." + '\n' + "Your current money Stack is: "
					+ server.getUsers().get(playersTurn).getBettingCash() + '\n';
			if (actingPlayer.getMyBet() == currentHighestBet) {
				message = message.concat("You match the current highest bet: " + currentHighestBet + '\n'
						+ "Use these commands: /Check /Raise /Fold");
			} else {
				message = message.concat("The current highest bet is: " + currentHighestBet + '\n'
						+ "Use these commands: /Call /Raise /Fold");
			}

			actingPlayer.sendMessage(message);

			String command = actingPlayer.readString();
			switch (command) {

			case "/check":
				actingPlayer.sendMessage("You checked this turn");
				server.sendToAll(actingPlayer.getUserName() + " decided to check", actingPlayer);
				break;

			case "/raise":
				//raising command
				actingPlayer.sendMessage("You raised by: ");
				server.sendToAll(actingPlayer.getUserName() + " decided to raise by: ", actingPlayer);
				break;

			case "/fold":
				//folding command
				actingPlayer.sendMessage("You folded your hand");
				server.sendToAll(actingPlayer.getUserName() + " decided to fold his hand", actingPlayer);
				break;

			case "/call":
				//calling command
				actingPlayer.sendMessage("You called to: " + currentHighestBet);
				server.sendToAll(actingPlayer.getUserName() + " decided to call highest bet: ", actingPlayer);
				break;
				
			default:
                System.out.println("Invalid command");
                break;
			}

			if (playersTurn == server.getUsers().size() - 1) {
				playersTurn = 0;
			} else {
				playersTurn++;
			}

		}
	}

}
