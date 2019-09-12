package com.example.rotate4;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.IBinder;
import android.os.PowerManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

public class Bombe extends AppCompatActivity {
    HomeWatcher mHomeWatcher;

    private ImageView bombetro;

    ImageButton pic1;
    private int pic1Counter = 0;
    private boolean pic1true = false;

    ImageButton pic2;
    private int pic2Counter = 0;
    private boolean pic2true = false;

    ImageButton pic3;
    private int pic3Counter = 0;
    private boolean pic3true = false;

    ImageButton pic4;
    private int pic4Counter = 0;
    private boolean pic4true = false;

    ImageButton pic5;
    private int pic5Counter = 0;
    private boolean pic5true = false;

    ImageButton pic6;
    private int pic6Counter = 0;
    private boolean pic6true = false;

    ImageButton pic7;
    private int pic7Counter = 0;
    private boolean pic7true = false;

    ImageButton pic8;
    private int pic8Counter = 0;
    private boolean pic8true = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        //Hides the feature bar.
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bombe);

        //BIND music service
        doBindService();
        Intent music = new Intent();
        music.setClass(this, MusicService.class);
        startService(music);

        mHomeWatcher = new HomeWatcher(this);
        mHomeWatcher.setOnHomePressedListener(new HomeWatcher.OnHomePressedListener() {
            @Override
            public void onHomePressed() {
                if (mServ != null) {
                    mServ.pauseMusic();
                }
            }
            @Override
            public void onHomeLongPressed() {
                if (mServ != null) {
                    mServ.pauseMusic();
                }
            }
        });
        mHomeWatcher.startWatch();

        TextView textview3=findViewById(R.id.textView3);
        MyTimer mTimer= new MyTimer();
        //mTimer.getTime();
        textview3.setText(mTimer.getTime() + "");


        pic1 = findViewById(R.id.pic1);
        pic1.setOnClickListener(new View.OnClickListener() {



            @Override
            public void onClick(View view) {
                pic1 = findViewById(R.id.pic1);
                pic1.setRotation(pic1.getRotation() + 60);
                pic1Counter++;
                if (pic1Counter>6){
                    pic1Counter=0;
                }

                if (pic1Counter == 3) {
                    pic1true = true;
                }



            }
        });

        pic2 = findViewById(R.id.pic2);
        pic2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic2 = findViewById(R.id.pic2);
                pic2.setRotation(pic2.getRotation() + 60);
                pic2Counter++;
                if (pic2Counter>6){
                    pic2Counter=0;
                }
                if (pic2Counter == 2) {
                    pic2true = true;
                }
            }
        });

        pic3 = findViewById(R.id.pic3);
        pic3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic3 = findViewById(R.id.pic3);
                pic3.setRotation(pic3.getRotation() + 60);
                pic3Counter++;
                if (pic3Counter>6){
                    pic3Counter=0;
                }
                if (pic3Counter == 1) {
                    pic3true = true;
                }
            }
        });


        pic4 = findViewById(R.id.pic4);
        pic4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic4 = findViewById(R.id.pic4);
                pic4.setRotation(pic4.getRotation() + 60);
                pic4Counter++;
                if (pic4Counter>6){
                    pic4Counter=0;
                }
                if (pic4Counter == 3) {
                    pic4true = true;
                }
            }
        });

        pic5 = findViewById(R.id.pic5);
        pic5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic5 = findViewById(R.id.pic5);
                pic5.setRotation(pic5.getRotation() + 60);
                pic5Counter++;
                if (pic5Counter>6){
                    pic5Counter=0;
                }
                if (pic5Counter == 3) {
                    pic5true = true;
                }
            }
        });

        pic6 = findViewById(R.id.pic6);
        pic6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic6 = findViewById(R.id.pic6);
                pic6.setRotation(pic6.getRotation() + 60);
                pic6Counter++;
                if (pic6Counter>6){
                    pic6Counter=0;
                }
                if (pic6Counter == 3) {
                    pic6true = true;
                }
            }
        });

        pic7 = findViewById(R.id.pic7);
        pic7.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic7 = findViewById(R.id.pic7);
                pic7.setRotation(pic7.getRotation() + 60);
                pic7Counter++;
                if (pic7Counter>6){
                    pic7Counter=0;
                }
                if (pic7Counter == 3) {
                    pic7true = true;
                }
            }
        });

        pic8 = findViewById(R.id.pic8);
        pic8.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                pic8 = findViewById(R.id.pic8);
                pic8.setRotation(pic8.getRotation() + 60);
                pic8Counter++;
                if (pic8Counter>6){
                    pic8Counter=0;
                }
                if (pic8Counter == 3) {
                    pic8true = true;
                }
            }
        });

    }

    //for playing music
    private boolean mIsBound = false;
    private MusicService mServ;
    private ServiceConnection Scon =new ServiceConnection(){

        public void onServiceConnected(ComponentName name, IBinder
                binder) {
            mServ = ((MusicService.ServiceBinder)binder).getService();
        }

        public void onServiceDisconnected(ComponentName name) {
            mServ = null;
        }
    };

    void doBindService(){
        bindService(new Intent(this,MusicService.class),
                Scon, Context.BIND_AUTO_CREATE);
        mIsBound = true;
    }

    void doUnbindService()
    {
        if(mIsBound)
        {
            unbindService(Scon);
            mIsBound = false;
        }
    }

    @Override
    protected void onResume() {
        super.onResume();

        if (mServ != null) {
            mServ.resumeMusic();
        }

    }

    @Override
    protected void onPause() {
        super.onPause();

        PowerManager pm = (PowerManager)
                getSystemService(Context.POWER_SERVICE);
        boolean isScreenOn = false;
        if (pm != null) {
            isScreenOn = pm.isScreenOn();
        }

        if (!isScreenOn) {
            if (mServ != null) {
                mServ.pauseMusic();
            }
        }

    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        //UNBIND music service
        doUnbindService();
        Intent music = new Intent();
        music.setClass(this,MusicService.class);
        stopService(music);

    }


    public void nextPage(View view) {


        bombetro = findViewById(R.id.bombetro);

        if (pic1true == true && pic2true==true && pic3true==true && pic4true==true && pic5true==true  && pic6true==true && pic7true==true&& pic8true==true) {


            final AcievementData acievement1 = (AcievementData) getApplicationContext();
            acievement1.setEarned1(1);

            bombetro.animate().alpha(1f).setDuration(1500);
            bombetro.postDelayed(new Runnable() {

                @Override
                public void run() {
                    bombetro.animate().alpha(0f).setDuration(1500);
                    bombetro.postDelayed(new Runnable() {

                        @Override
                        public void run() {
                            if(mServ!=null){
                                mServ.stopMusic();
                            }
                            nextPage1();
                        }
                    }, 2000);

                }
            }, 3000);
        }

    }

    public void nextPage1(){
        Intent intent = new Intent(this, Activation.class);
        startActivity(intent);

    }

    public void back(View view){
        Intent intent= new Intent(this, Desktop.class);
        startActivity(intent);
    }
}
