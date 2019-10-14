package com.example.rotate4;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.NumberPicker;

public class Puzzle extends AppCompatActivity {

        private ImageView achievBox;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_puzzlewar);
        Button checkButton = findViewById(R.id.CheckButton);

        //Picker for TURING box
        final NumberPicker PickerOne = findViewById(R.id.Picker1); //refer to picker number 1
        String[] PickerOneLetters = {"A","B","C","E","P","T"};     //a string of letters
        PickerOne.setMaxValue(5);                                  //the string cannot have more than 6 spots (0-5)
        PickerOne.setDisplayedValues(PickerOneLetters);            //display the letters in picker 1

        final NumberPicker PickerTwo = findViewById(R.id.Picker2);
        String[] PickerTwoLetters = {"I", "U", "O", "B", "T", "I"};
        PickerTwo.setMaxValue(5);
        PickerTwo.setDisplayedValues(PickerTwoLetters);

        final NumberPicker PickerThree = findViewById(R.id.Picker3);
        String[] PickerThreeLetters = {"R", "Y", "V", "A", "B", "P"};
        PickerThree.setMaxValue(5);
        PickerThree.setDisplayedValues(PickerThreeLetters);

        final NumberPicker PickerFour = findViewById(R.id.Picker4);
        String[] PickerFourLetters = {"R", "Y", "V", "I", "O", "A"};
        PickerFour.setMaxValue(5);
        PickerFour.setDisplayedValues(PickerFourLetters);

        final NumberPicker PickerFive = findViewById(R.id.Picker5);
        String[] PickerFiveLetters = {"R", "Y", "V", "I", "S", "N"};
        PickerFive.setMaxValue(5);
        PickerFive.setDisplayedValues(PickerFiveLetters);

        final NumberPicker PickerSix = findViewById(R.id.Picker6);
        String[] PickerSixLetters = {"R", "Y", "V", "I", "G", "M"};
        PickerSix.setMaxValue(5);
        PickerSix.setDisplayedValues(PickerSixLetters);


        achievBox = findViewById(R.id.achievementBox);

        //Make sure that only when the pickers spell TURING it is possible to proceed
        checkButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(PickerOne.getValue()==5 && PickerTwo.getValue()==1 && PickerThree.getValue()==0 && PickerFour.getValue()==3 && PickerFive.getValue()==5 && PickerSix.getValue()==4){

                    //Animates the fade in over 1500 milliseconds
                    achievBox.animate().alpha(1f).setDuration(1500);

                    //Adds a delay before the fade out animation
                    achievBox.postDelayed(new Runnable() {
                        @Override
                        public void run() {
                            achievBox.animate().alpha(0f).setDuration(1500);

                            //Adds another delay before going to the next page.
                            //This was the only way I could make the fade out animation happen while still going to the next page.
                            achievBox.postDelayed(new Runnable() {
                                @Override
                                public void run() {
                                    nextPage();
                                }
                            }, 2000);
                        }
                    }, 3000);
                }
            }
        });
    }

    public void nextPage(){
        Intent intent = new Intent(this, EndScreen.class);
        startActivity(intent);
    }

    //back to desktop
    public void back(View view){
        Intent intent = new Intent(this, DesktopWar.class);
        startActivity(intent);
    }

}
