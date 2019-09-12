package com.example.rotate4;

import android.os.CountDownTimer;
import android.widget.TextView;

public class MyTimer {
    public static long time;
    TextView textView;

    public MyTimer(){
        new CountDownTimer(60000,1000){
            @Override
            public void onTick(long millisUntilFinished) {
                //textView.setText(millisUntilFinished/1000 + "");
                time=millisUntilFinished/1000;

            }

            @Override
            public void onFinish() {

            }
        }.start();
    }

   /* public void countdown(){

        new CountDownTimer(time,1000){
            @Override
            public void onTick(long millisUntilFinished) {
                time=millisUntilFinished/1000;

            }

            @Override
            public void onFinish() {

            }
        }.start();
    }*/

    public long getTime(){
        return this.time;
    }
}
