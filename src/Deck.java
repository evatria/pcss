import java.util.Arrays;
import java.util.Random;



public class Deck {
	
	// Collection of cards
	private Card[] deck;
	
	// Meant to keep track of the number of cards dealt.
	private int cardsUsed;
	
	private Suit suits[];
	
	private Value values[];
	
	
	// Constructor. Fills a deck.
	public Deck() {
		deck = new Card[52];
		int cardsUsed = 0;
		suits=Suit.values();
		values=Value.values();
		for (int i = 0; i < suits.length; i++) {
			for ( int j = 0; j < values.length; j++) {
				deck[cardsUsed++] = new Card(suits[i],values[j]);	
			}
		}
	}
	
	
	// Print all the cards of the deck.
    public void printDeck(){
        System.out.println(Arrays.toString(deck));
    }

	
	//	Fischer-Yates algorythm (most efficient for random shuffle):
	//
	//	1. Start with N objects, let n=N
	//	2. Generate random number i between 1 and n
	//	3. SWAP element n (at the end) and element i (randomly picked to the left of n)
	//	4. Decrease n by 1
	//	5. Repeat 2 to 4 until n = 1	
    
	public void shuffle() {
		Random rnd = new Random();
		
		for (int i = deck.length-1; i > 0; i--) 		// Starts at the last card in the array. -1, since element 1 is at index 0
		{	
			int random = rnd.nextInt(i+1);				// +1, because nextInt goes up to the input. The last card should be able to swap with itself.
			Card temp = deck[i];
			deck[i] = deck[random];
			deck[random] = temp;
		}
	}
	
	
	public static void main(String args[]) {
		
		Deck gameDeck = new Deck();
		gameDeck.printDeck();
		gameDeck.shuffle();
		gameDeck.printDeck();
		
	}
}
