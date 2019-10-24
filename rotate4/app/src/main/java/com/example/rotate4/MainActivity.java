package com.example.rotate4;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class MainActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //three first lines hide the bars, same in all activities
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Scanner input = new Scanner(System.in);
        boolean connect = true;

        try {
            Socket connectToServer = new Socket("localhost", 7500);
            System.out.println("Connected to server");
            DataInputStream isFromServer = new DataInputStream(connectToServer.getInputStream());
            DataOutputStream osToServer = new DataOutputStream(connectToServer.getOutputStream());

            while(connect) {
                System.out.print("Waiting for 2 player to start");
                String Waiting;

                






            }

            input.close();
            connectToServer.close();
        } catch (IOException var15) {
            System.out.println(var15.toString() + "\n");
        }

    }

    public void startGame(View view){
        Intent intent= new Intent(this, Selection.class);
        startActivity(intent);
    }


}



