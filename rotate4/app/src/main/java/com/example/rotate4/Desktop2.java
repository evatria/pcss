package com.example.rotate4;

import android.content.Intent;
import android.os.CountDownTimer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class Desktop2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //Hides the feature bar.
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_desktop2);


    }


    public void bombeView(View view){
        Intent intent= new Intent(this, Bombe.class);
        startActivity(intent);
    }

    public void profileView(View view){
        ImageView character= findViewById(R.id.charInfo);
        character.setVisibility(View.VISIBLE);

        visibleInvisble();

    }

    public void backButton(View view){

        Intent intent=new Intent(this, Desktop2.class);
        startActivity(intent);
    }

    public void HintButton(View view) {
        ImageView hint= findViewById(R.id.hintButton);
        hint.setVisibility(View.VISIBLE);

        visibleInvisble();
    }




    public void finalDay(View view){
        ImageView thursday= findViewById(R.id.bombday);
        thursday.setVisibility(View.VISIBLE);

        Button back= findViewById(R.id.backB);
        back.setVisibility(View.VISIBLE);

        Button poemB=findViewById(R.id.poemB);
        poemB.setVisibility(View.INVISIBLE);

        Button bombeB=findViewById(R.id.bombeB);
        bombeB.setVisibility(View.INVISIBLE);

        Button hintB=findViewById(R.id.hint1);
        hintB.setVisibility(View.INVISIBLE);

    }

    public void poemView(View view){
        ImageView poem= findViewById(R.id.poemInfo);
        poem.setVisibility(View.VISIBLE);

        visibleInvisble();
    }

    public void targetView(View view){
        ImageView target= findViewById(R.id.target);
        target.setVisibility(View.VISIBLE);

        visibleInvisble();

    }

    public void visibleInvisble(){
        Button back= findViewById(R.id.backB);
        back.setVisibility(View.VISIBLE);

        Button poemB=findViewById(R.id.poemB);
        poemB.setVisibility(View.INVISIBLE);

        Button bombeB=findViewById(R.id.bombeB);
        bombeB.setVisibility(View.INVISIBLE);

        Button choiceB=findViewById(R.id.button10);
        choiceB.setVisibility(View.INVISIBLE);

        ImageView choiceI=findViewById(R.id.imageView5);
        choiceI.setVisibility(View.INVISIBLE);

        Button hintB=findViewById(R.id.hint1);
        hintB.setVisibility(View.INVISIBLE);

    }

    public void activation(View view){
        Intent intent=new Intent(this, Choice.class);
        startActivity(intent);
    }

}
