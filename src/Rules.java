import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

public class Rules {

	public static void main(String[] args) {

		ArrayList<Card> deck = new ArrayList<>();
		for (Value value : Value.values()) {
			for (Suit suit : Suit.values()) {
				deck.add(new Card(value, suit));
			}
		}
//		Collections.shuffle(deck);

		ArrayList<Card> playerHand = new ArrayList<>();
		for (int i = 0; i < 7 * 3; i += 3) {
			playerHand.add(deck.get(i));
			deck.remove(0);
		}

		Collections.sort(playerHand, Collections.reverseOrder(new SortByValue()));
		System.out.println(playerHand);
//high card:
		System.out.println("High card: " + playerHand.get(0));
//kinds:
		String kinds = "";
		String result = "";
		try {
			for (int i = 0; i < playerHand.size() - 1; i++) {
				result = "";
				if (playerHand.get(i).getCardValue().getCardValue() == playerHand.get(i + 1).getCardValue()
						.getCardValue()) {
					result = " 2 of a kind of " + playerHand.get(i).getCardValue() + "s";
					i++;
					if (playerHand.get(i).getCardValue().getCardValue() == playerHand.get(i + 1).getCardValue()
							.getCardValue()) {
						result = " 3 of a kind of " + playerHand.get(i).getCardValue() + "s";
						i++;
						if (playerHand.get(i).getCardValue().getCardValue() == playerHand.get(i + 1).getCardValue()
								.getCardValue()) {
							result = " 4 of a kind of " + playerHand.get(i).getCardValue() + "s";
							i++;
						}
					}
				}
				kinds = kinds.concat(result);
			}
		} catch (IndexOutOfBoundsException e) {
			// coders note: this is FINE
			kinds = kinds.concat(result);
		}

		System.out.println("Found kinds:" + '\n' + kinds);

		String straight = "None";
		for (int i = playerHand.size() - 1; i >= 4; i--) {
			if (playerHand.get(i).getCardValue().getCardValue() == playerHand.get(i - 1).getCardValue().getCardValue()
					- 1
					&& playerHand.get(i - 1).getCardValue()
							.getCardValue() == playerHand.get(i - 2).getCardValue().getCardValue() - 1
					&& playerHand.get(i - 2).getCardValue()
							.getCardValue() == playerHand.get(i - 3).getCardValue().getCardValue() - 1
					&& playerHand.get(i - 3).getCardValue()
							.getCardValue() == playerHand.get(i - 4).getCardValue().getCardValue() - 1)
				straight = "Straight of " + playerHand.get(i).getCardValue() + " "
						+ playerHand.get(i - 1).getCardValue() + " " + playerHand.get(i - 2).getCardValue() + " "
						+ playerHand.get(i - 3).getCardValue() + " " + playerHand.get(i - 4).getCardValue();
		}

		System.out.println("Found straight:" + '\n' + straight);

		String flush = "None";
		for (int i = playerHand.size() - 1; i >= 4; i--) {
			if (playerHand.get(i).getSuit().printRankCard().equals(playerHand.get(i - 1).getSuit().printRankCard())
					&& playerHand.get(i - 1).getSuit().printRankCard()
							.equals(playerHand.get(i - 2).getSuit().printRankCard())
					&& playerHand.get(i - 2).getSuit().printRankCard()
							.equals(playerHand.get(i - 3).getSuit().printRankCard())
					&& playerHand.get(i - 3).getSuit().printRankCard()
							.equals(playerHand.get(i - 4).getSuit().printRankCard()))
				flush = "Flush of " + playerHand.get(i).getCardValue() + " " + playerHand.get(i - 1).getCardValue()
						+ " " + playerHand.get(i - 2).getCardValue() + " " + playerHand.get(i - 3).getCardValue() + " "
						+ playerHand.get(i - 4).getCardValue() +" of " + playerHand.get(i).getSuit().printRankCard();
		}
		
		System.out.println("Found flush:" + '\n' + flush);

	}
}

class SortByValue implements Comparator<Card> {
	// Used for sorting in ascending order of
	// roll number
	public int compare(Card a, Card b) {
		return a.getCardValue().getCardValue() - b.getCardValue().getCardValue();
	}
}