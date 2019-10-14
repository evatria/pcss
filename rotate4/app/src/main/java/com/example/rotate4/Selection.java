package com.example.rotate4;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class Selection extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //three first lines hide the bars, same in all activities
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_selection);

    }

    public void startWar(View view){
        Intent intent= new Intent(this, DesktopWar.class);
        startActivity(intent);
    }

    public void startInt(View view){
        Intent intent= new Intent(this, Desktop.class);
        startActivity(intent);
    }
}

