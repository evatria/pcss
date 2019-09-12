package com.example.rotate4;

import android.content.Intent;
import android.media.MediaPlayer;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;
import android.widget.MediaController;
import android.widget.VideoView;

public class Introduction extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_introduction);

        //setting up the path for the video
        VideoView introVideo=findViewById(R.id.intro);
        String introPath="android.resource://" + getPackageName() + "/" + R.raw.intellegence;
        Uri uri= Uri.parse(introPath);
        introVideo.setVideoURI(uri);

        //making the video visible and starts it, then goes to next page
        MediaController  mediaController=new MediaController(this);
        introVideo.setMediaController(mediaController);
        mediaController.setAnchorView(introVideo);
        introVideo.start();
        introVideo.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mp) {
                finish();
                nextPage();
            }
        });
    }

    //intent that goes to next page(desktop)
    public void nextPage(){
        Intent intent= new Intent(this, Desktop.class);
        startActivity(intent);
    }


}
