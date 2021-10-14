package ClientTest;


	public class QuestionBlock {
	    public String answer;
	    public String question;
	    public int value;
	    public int categoryId;
	    public boolean notUsed;

	//Constructor of questionBlock
	    public QuestionBlock(String answer, String question, int value, int categoryId) {
	        this.answer = answer;
	        this.question = question;
	        this.value = value;
	        this.categoryId = categoryId;
	    }

	    //Getters and Setters
	    public String getAnswer() {
	        return answer;
	    }

	    public void setAnswer(String answer) {
	        this.answer = answer;
	    }

	    public String getQuestion() {
	        return question;
	    }

	    public void setQuestion(String question) {
	        this.question = question;
	    }

	    public int getValue() {
	        return value;
	    }

	    public void setValue(int value) {
	        this.value = value;
	    }

	    @Override
	    public String toString() {
	        return "QuestionBlock{" +
	                "answer='" + answer + '\'' +
	                ", question='" + question + '\'' +
	                ", value=" + value + '\'' +
	                ", categoryId=" + categoryId +  '\''
	                ;
	    }
	}