package com.example.rotate4;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class Activation extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //Hides the feature bar.
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activation);
    }

    public void newStage(View view){
        Intent intent= new Intent(this, Desktop2.class);
        startActivity(intent);
    }
}
