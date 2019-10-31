package com.example.rotate4;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Client extends AppCompatActivity {
    boolean connect = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.client);
        System.out.println("Class Client is working pls");
        //Scanner input = new Scanner(System.in);


        Thread thread = new Thread(new clientThread());
        thread.start();

        /*try {
            System.out.println("Inside try");
            Socket s = new Socket("192.168.8.104", 7500);
            System.out.println("Connected to server");


            DataInputStream inputStream = new DataInputStream(s.getInputStream());
            DataOutputStream outputStream = new DataOutputStream(s.getOutputStream());

            while (connect) {
                System.out.print("While connected...");
                outputStream.writeDouble(1);
                System.out.print("Sending double '1' to server for defining ");

                double warOfficer = inputStream.readDouble();
                double intelligens = inputStream.readDouble();

                if (warOfficer == 10) {
                    // change the screen with intent
                    startwar();
                }

                if (intelligens == 20) {
                    // change the screen with intent
                    startintel();
                }


            }
        } catch (IOException ex) {
            System.out.println("ex");
        }*/

    }


    public class clientThread implements Runnable{

        @Override
        public void run() {
            try {
                System.out.println("Inside try");
                Socket s = new Socket("192.168.43.180", 7500);
                System.out.println("Connected to server");


                DataInputStream inputStream = new DataInputStream(s.getInputStream());
                DataOutputStream outputStream = new DataOutputStream(s.getOutputStream());
                System.out.println("Data Streams established");


                while (connect) {
                    System.out.print("While connected...");
                    outputStream.writeDouble(1);
                    System.out.print("Sending double '1' to server for defining ");

                    outputStream.flush();

                    double character = inputStream.readDouble();
                    //double intelligens = inputStream.readDouble();



                    if (character == 10) {
                        // change the screen with intent
                        startwar();
                    }

                    if (character == 20) {
                        // change the screen with intent
                        startintel();
                    }


                }
            } catch (IOException ex) {
                System.out.println("ex");
            }
        }
    }

    void startwar(){
        Intent intent = new Intent(this, DesktopWar.class);
        startActivity(intent);
    }

    void startintel(){
        Intent intent = new Intent(this,Desktop.class);
        startActivity(intent);
    }
}
