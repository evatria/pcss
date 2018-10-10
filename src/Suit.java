
public enum Suit {
	Hearts("H"), Spades("S"), Diamonds("D"), Clubs("C");

    
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
