import java.io.*;
import java.util.Scanner;
public class QuestionReader {
    public static void main(String[] args) throws Exception
    {
//parsing a CSV file into Scanner class constructor  
        Scanner sc = new Scanner(new File("C:\\Users\\Victor Hjort\\IdeaProjects\\VictorsServer\\lol.csv"));
        sc.useDelimiter(",");   //sets the delimiter pattern

            for (int i = 0; i < 4; i++)  //returns a boolean value
            {
                System.out.print(sc.next() + System.lineSeparator());  //find and returns the next complete token from this scanner
            }

        sc.close();  //closes the scanner
    }
}  