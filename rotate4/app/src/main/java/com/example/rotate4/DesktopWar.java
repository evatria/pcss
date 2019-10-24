package com.example.rotate4;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;

public class DesktopWar extends AppCompatActivity {

    int clickCounter = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_desktopwar);



        /*CountDownTimer timer = new CountDownTimer(1500000, 1000){ //25 minutes
            TextView timer = findViewById(R.id.timer);

            @Override
            public void onTick(long millisUntilFinished) {
                timer.setText("Time: " +millisUntilFinished/60000 + " minutes");
            }

            @Override
            public void onFinish() {
                timer.setText("Fail");
            }
        };
        timer.start();*/
    }


    //enlarging the box (running code in puzzle class)
    public void box (View view) {
        Intent intent = new Intent(this, Puzzle.class);
        startActivity(intent);
    }

    public void visibleInvisibleElementsDesktop(){
        Button back = findViewById(R.id.backButton);
        back.setVisibility(View.VISIBLE);
        Button boxButton = findViewById(R.id.boxButton);
        boxButton.setVisibility(View.GONE);
        Button codeButton = findViewById(R.id.codeButton);
        codeButton.setVisibility(View.GONE);
        Button characterButton = findViewById(R.id.characterButton);
        characterButton.setVisibility(View.GONE);
        Button hintButton = findViewById(R.id.hintButton);
        hintButton.setVisibility(View.GONE);
    }

    //enlarge the code and hide the box so it is not clickable
    public void openCodeDesktop (View view){
        ImageView openCode = findViewById(R.id.codeFullscreen);
        openCode.setVisibility(View.VISIBLE);
        visibleInvisibleElementsDesktop();
    }

    public void backButtonDesktop (View view){
        Button back = findViewById(R.id.backButton);
        back.setVisibility(View.INVISIBLE);
        Button boxButton = findViewById(R.id.boxButton);
        boxButton.setVisibility(View.VISIBLE);
        Button codeButton = findViewById(R.id.codeButton);
        codeButton.setVisibility(View.VISIBLE);
        Button characterButton = findViewById(R.id.characterButton);
        characterButton.setVisibility(View.VISIBLE);
        Button hintsBut = findViewById(R.id.hintButton);
        hintsBut.setVisibility(View.VISIBLE);

        ImageView openCode = findViewById(R.id.codeFullscreen);
        openCode.setVisibility(View.INVISIBLE);
        ImageView openCharacter = findViewById(R.id.characterFullscreen);
        openCharacter.setVisibility(View.INVISIBLE);
        ImageView hints = findViewById(R.id.ArrayHints);
        hints.setVisibility(View.INVISIBLE);
    }

    public void openCharacterDesktop (View view){
        ImageView openCharacter = findViewById(R.id.characterFullscreen);
        openCharacter.setVisibility(View.VISIBLE);
        visibleInvisibleElementsDesktop();
    }

    public void hintDesktop(View view){
        ImageView hints = findViewById(R.id.ArrayHints);
        clickCounter++;

        if(clickCounter == 1){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.hint_one);
            visibleInvisibleElementsDesktop();
        }
        if(clickCounter == 2){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.hint_two);
            visibleInvisibleElementsDesktop();
        }
        if(clickCounter == 3){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.hint_three);
            visibleInvisibleElementsDesktop();
        }
        if(clickCounter == 4){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.hint_four);
            visibleInvisibleElementsDesktop();
        }
        if(clickCounter == 5){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.hint_five);
            visibleInvisibleElementsDesktop();
        }
        if(clickCounter > 5){
            hints.setVisibility(View.VISIBLE);
            hints.setImageResource(R.drawable.nohints);
            visibleInvisibleElementsDesktop();
        }

    }
}
