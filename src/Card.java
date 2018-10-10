
public class Card {

	private Suits suits;
	private CardValue value;
	
	//Card Constructor
	public Card(Suits suits, CardValue value) {
		this.suits = suits;
		this.value = value;	
	}
	
	//methods
	public String getSuits() {
		return suits.printRankCard();
	}
	
	public int getCardValue() {
		return value.getCardValue();
	}
	
	public String toString() {
		String str = "";
		str += value.getCardValue() + " " + suits.printRankCard();
		return str;
	}
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		

	}

}
