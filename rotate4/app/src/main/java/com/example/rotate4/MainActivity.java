package com.example.rotate4;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class MainActivity extends AppCompatActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //three first lines hide the bars, same in all activities
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }
 /*   void Main () {
        boolean connect = true;
        try {
            Socket connectToServer = new Socket("localhost", 7500);
            System.out.println("Connected to the server");
            DataInputStream isFromServer = new DataInputStream (connectToServer.getInputStream());
            DataOutputStream osFromServer = new DataOutputStream (connectToServer.getOutputStream());


            while (connect) {
                System.out.println("Waiting for player 2");
                String waiting;
            }

        } catch (IOException var15) {
            System.out.println(var15.toString() + "\n");

        }
    }*/

    public void startGame(View view){
        System.out.println("Connecting to server");
        Intent intent1 = new Intent (this, Client.class);
        startActivity(intent1);

        //Intent intent= new Intent(this, Selection.class);
        //startActivity(intent);



    }

}



