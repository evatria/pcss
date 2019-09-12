package com.example.rotate4;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import pl.bclogic.pulsator4droid.library.PulsatorLayout;

public class Choice extends AppCompatActivity {
private ImageView notHistorical;
private ImageView historical;
private ImageView goalSucces;
private ImageView goalFail;
private Button Bacbutt;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_choice);

        //PulsatorLayout pulsatorLayout = (PulsatorLayout) findViewById(R.id.pulsator);
        //pulsatorLayout.start();
        

        ImageButton bprofile= findViewById(R.id.charGoal);
        final Animation myAnim = AnimationUtils.loadAnimation(this, R.anim.bounce);
        MyBounceInterpolater interpolator = new MyBounceInterpolater(0.2, 100);
        myAnim.setInterpolator(interpolator);
        bprofile.startAnimation(myAnim);

    }

    public void profileGoal(View view){


        ImageView chaGoal = findViewById(R.id.persgoal);
        Button Backbutt = findViewById(R.id.backButt);


        chaGoal.setVisibility(View.VISIBLE);
        Backbutt.setVisibility(View.VISIBLE);

    }

    public void backBut(View view){
// goes back to the desktop picture if the back button is pushed
        ImageView chaGoal = findViewById(R.id.persgoal);
        ImageView notHistorical= findViewById(R.id.notHistorical);
        ImageView historical= findViewById(R.id.historical);
        ImageView goalSucces=findViewById(R.id.goalsucces);
        ImageView goalFail=findViewById(R.id.goalfailed);
        Button Backbutt = findViewById(R.id.backButt);


        chaGoal.setVisibility(View.INVISIBLE);
        Backbutt.setVisibility(View.INVISIBLE);
        notHistorical.setVisibility(View.VISIBLE);
        historical.setVisibility(View.VISIBLE);
        goalSucces.setVisibility(View.VISIBLE);
        goalFail.setVisibility(View.VISIBLE);

    }


    public void nothingtro (View view){
        historical= findViewById(R.id.historical);
        goalSucces= findViewById(R.id.goalsucces);



    final AcievementData acievement1 = (AcievementData) getApplicationContext();
    acievement1.setEarned1(1);

    historical.animate().alpha(1f).setDuration(1500);
   historical.postDelayed(new Runnable() {

        @Override
        public void run() {
           historical.animate().alpha(0f).setDuration(1500);
            historical.postDelayed(new Runnable() {

                @Override
                public void run() {
                   nothing();
                }
            }, 2000);

        }
    }, 3000);

        final AcievementData acievement2 = (AcievementData) getApplicationContext();
        acievement2.setEarned1(1);

        goalSucces.animate().alpha(1f).setDuration(1500);
        goalSucces.postDelayed(new Runnable() {

            @Override
            public void run() {
                goalSucces.animate().alpha(0f).setDuration(1500);
                goalSucces.postDelayed(new Runnable() {

                    @Override
                    public void run() {
                        nothing();
                    }
                }, 2000);

            }
        }, 3000);
}

    public void somethingtro (View view){
        notHistorical= findViewById(R.id.notHistorical);
        goalFail= findViewById(R.id.goalfailed);



        final AcievementData acievement1 = (AcievementData) getApplicationContext();
        acievement1.setEarned1(1);

        notHistorical.animate().alpha(1f).setDuration(1500);
        notHistorical.postDelayed(new Runnable() {

            @Override
            public void run() {
                notHistorical.animate().alpha(0f).setDuration(1500);
                notHistorical.postDelayed(new Runnable() {

                    @Override
                    public void run() {
                        something();
                    }
                }, 2000);

            }
        }, 3000);

        final AcievementData acievement2 = (AcievementData) getApplicationContext();
        acievement2.setEarned1(1);

        goalFail.animate().alpha(1f).setDuration(1500);
        goalFail.postDelayed(new Runnable() {

            @Override
            public void run() {
                goalFail.animate().alpha(0f).setDuration(1500);
                goalFail.postDelayed(new Runnable() {

                    @Override
                    public void run() {
                        something();
                    }
                }, 2000);

            }
        }, 3000);
    }



    public void nothing(){
        Intent intent=new Intent(this, NothingCode.class);
        startActivity(intent);
    }

    public void something(){
        Intent intent= new Intent(this, SomethingCode.class);
        startActivity(intent);
    }

        }