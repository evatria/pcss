
public enum Suit {
	Hearts("Hearts"), Spades("Spades"), Diamonds("Dimonds"), Clubs("Clubs");

    
    private final String suitText;
    
    //The Constructor for the suits
    private Suit(String suitText) {
    	this.suitText = suitText;
    }
    
    // Method 
    public String printRankCard() {
    	return suitText;
    }
}
