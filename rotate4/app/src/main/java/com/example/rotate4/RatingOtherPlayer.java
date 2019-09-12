package com.example.rotate4;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Html;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class RatingOtherPlayer extends AppCompatActivity {

    private EditText eTo;
    private String eSubject;
    private TextView eTextQ1;
    private TextView eTextQ2;
    private TextView eTextQ3;
    private TextView eTextQ4;
    private TextView eTextQ5;
    private TextView eTextQ6;
    private TextView eTextQ7;
    private EditText eTextA1;
    private EditText eTextA2;
    private EditText eTextA3;
    private EditText eTextA4;
    private EditText eTextA5;
    private EditText eTextA6;
    private EditText eTextA7;
    private Button btn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getSupportActionBar().hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rating_other_player);

        //Receiver and subject line
        eTo = findViewById(R.id.txtTo);
        eSubject = "Feedback from your partner";

        //Questions
        eTextQ1 = findViewById(R.id.txtQ1);
        eTextA1 = findViewById(R.id.txtA1);
        eTextQ2 = findViewById(R.id.txtQ2);
        eTextA2 = findViewById(R.id.txtA2);
        eTextQ3 = findViewById(R.id.txtQ3);
        eTextA3 = findViewById(R.id.txtA3);
        eTextQ4 = findViewById(R.id.txtQ4);
        eTextA4 = findViewById(R.id.txtA4);
        eTextQ5 = findViewById(R.id.txtQ5);
        eTextA5 = findViewById(R.id.txtA5);
        eTextQ6 = findViewById(R.id.txtQ6);
        eTextA6 = findViewById(R.id.txtA6);
        eTextQ7 = findViewById(R.id.txtQ7);
        eTextA7 = findViewById(R.id.txtA7);

        btn = findViewById(R.id.btnSend);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent email = new Intent(Intent.ACTION_SEND);
                email.setType("text/html");
                email.putExtra(Intent.EXTRA_EMAIL, new String[]{eTo.getText().toString()});
                email.putExtra(Intent.EXTRA_SUBJECT,eSubject);
                email.putExtra(Intent.EXTRA_TEXT,
                        Html.fromHtml(new StringBuilder()
                                .append("<html>")
                                .append(eTextQ1.getText().toString())
                                .append("<br/>")
                                .append(eTextA1.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ2.getText().toString())
                                .append("<br/>")
                                .append(eTextA2.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ3.getText().toString())
                                .append("<br/>")
                                .append(eTextA3.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ4.getText().toString())
                                .append("<br/>")
                                .append(eTextA4.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ5.getText().toString())
                                .append("<br/>")
                                .append(eTextA5.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ6.getText().toString())
                                .append("<br/>")
                                .append(eTextA6.getText().toString())
                                .append("<br/>")
                                .append("<br/>")
                                .append(eTextQ7.getText().toString())
                                .append("<br/>")
                                .append(eTextA7.getText().toString())
                                .append("<br/>")
                                .append("<br/>")

                                .append("<br/></html>").toString()
                        ));


                startActivity(Intent.createChooser(email,"Choose Mail App"));
            }
        });
    }

    public void results(View view){
        Intent intent=new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}
