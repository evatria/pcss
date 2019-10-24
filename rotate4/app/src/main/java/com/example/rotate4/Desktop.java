package com.example.rotate4;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.media.MediaPlayer;
import android.os.IBinder;
import android.os.PowerManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class Desktop extends AppCompatActivity {
    int hintCounter=0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //Hides the feature bar.
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_desktop);

    }



// opens the bombe class
    public void bombeMachine(View view){
        Intent intent= new Intent(this, Bombe.class);
        startActivity(intent);
    }


   public void HintButton(View view) {
        ImageView hint = findViewById(R.id.hint1);
        hintCounter++;

        if (hintCounter == 1) {
            hint.setVisibility(View.VISIBLE);
            hint.setImageResource(R.drawable.hintone);
            VisibleInvisible();
        }

        if (hintCounter == 2) {
            hint.setVisibility(View.VISIBLE);
            hint.setImageResource(R.drawable.hintthree);
            VisibleInvisible();
        }

        if (hintCounter > 2) {
            hint.setVisibility(View.VISIBLE);
            hint.setImageResource(R.drawable.hintlast);
            VisibleInvisible();
        }
    }

    //method for setting everything invisible and back button visible(is used for the other methods)
    public void VisibleInvisible(){
        Button back = findViewById(R.id.backBD);
        back.setVisibility(View.VISIBLE);

        Button poemB=findViewById(R.id.poem);
        poemB.setVisibility(View.INVISIBLE);

        Button bombeB=findViewById(R.id.bombe);
        bombeB.setVisibility(View.INVISIBLE);

        Button charInfo= findViewById(R.id.charpro);
        charInfo.setVisibility(View.INVISIBLE);

        Button hintButton = findViewById(R.id.hintButt);
        hintButton.setVisibility(View.INVISIBLE);

    }


    //Opens the character by setting the picture to visible.
    public void profileView(View view){
        ImageView character= findViewById(R.id.charView);
        character.setVisibility(View.VISIBLE);

      VisibleInvisible();
    }

    //Opens the poem by setting it to visible
   public void poemView(View view){
        ImageView poem= findViewById(R.id.poemView);
        poem.setVisibility(View.VISIBLE);

       VisibleInvisible();
    }


    // goes back to the desktop picture if the back button is pushed
    public void backButton(View view){

        ImageView poem= findViewById(R.id.poemView);
        poem.setVisibility(View.INVISIBLE);

        Button back= findViewById(R.id.backBD);
        back.setVisibility(View.INVISIBLE);

        Button poemB=findViewById(R.id.poem);
        poemB.setVisibility(View.VISIBLE);

        Button bombeB=findViewById(R.id.bombe);
        bombeB.setVisibility(View.VISIBLE);

        Button charInfo= findViewById(R.id.charpro);
        charInfo.setVisibility(View.VISIBLE);

        ImageView character= findViewById(R.id.charView);
        character.setVisibility(View.INVISIBLE);

        ImageView hint= findViewById(R.id.hint1);
        hint.setVisibility(View.INVISIBLE);

        Button hintButton = findViewById(R.id.hintButt);
        hintButton.setVisibility(View.VISIBLE);
    }

}
