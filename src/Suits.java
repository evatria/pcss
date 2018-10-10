
public enum Suits {
	H("H"), S("S"), D("D"), C("C");

    
    private final String suitText;
    
    //The Constructor for the suits
    private Suits(String suitText) {
    	this.suitText = suitText;
    }
    
    //the Method
    public String printRankCard() {
    	return suitText;
    }
}
