import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Random;

public class Deck{

	// Collection of cards
	private ArrayList<Card> deck; 



	ArrayList<Card> table = new ArrayList<>();
	ArrayList<Card> burnPile = new ArrayList<>();



	// Constructor. Fills a deck.
	public Deck() {
		this.deck = new ArrayList<Card>();
		for (Value value : Value.values()){
			for (Suit suit : Suit.values()) {
				deck.add(new Card(value,suit));	
			}
		}
	}


	// Print all the cards of the deck.
	public void printDeck(){
		System.out.println(deck);
	}
	


	public void shuffle() {
		Collections.shuffle(deck);
	}



	// Deal function for table.
	public void deal(ArrayList<Card> list) {
		//Get next card and add to hand of the player
		Card removedCard = deck.remove(0);
		list.add(removedCard);
	}

	// Burns one card from the deck and adds it to the burn pile.
	public void burn(ArrayList<Card> list) {
		//Get next card and add to hand of the player
		Card removedCard = deck.remove(0);
		list.add(removedCard);
	}

	
}

