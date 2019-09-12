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

public class Something extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_something);

        VideoView introVideo=findViewById(R.id.something);
        String introPath="android.resource://" + getPackageName() + "/" + R.raw.something;
        Uri uri= Uri.parse(introPath);
        introVideo.setVideoURI(uri);

        MediaController mediaController=new MediaController(this);
        introVideo.setMediaController(mediaController);
        mediaController.setAnchorView(introVideo);
        introVideo.start();
        introVideo.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mp) {
                finish();
                rating();
            }
        });
    }

    public void rating(){
        Intent intent= new Intent(this, RatingOtherPlayer.class);
        startActivity(intent);
    }
}
