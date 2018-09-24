// The board class could hold the Ludo board as an array.
// Maybe smarter to do 1 outer board array and then each player's "victory road" as 4 seperate arrays, to avoid continuity problems when the players are moving around the board

public class Board {
	
	int[] board = {51};
	int[] redEnd = {5};
	int[] greenEnd = {5};
	int[] YellowEnd = {5};
	int[] BlueEnd = {5};

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Die gameDie = new Die();
		
		for(int i = 0; i < 100; i++)
		{
		    gameDie.roll();
		    System.out.println(gameDie.getDie());
		}
	}
}

