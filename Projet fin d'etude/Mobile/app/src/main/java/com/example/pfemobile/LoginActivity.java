package com.example.pfemobile;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.content.res.AppCompatResources;

public class LoginActivity extends AppCompatActivity {
    TextView resultTxtVw,registerTxtVw;
    Button returnBtn, letsCookBtn;
    EditText emailEdTxt, passowrdEdTxt;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        returnBtn = findViewById(R.id.retrunBtn);
        letsCookBtn = findViewById(R.id.letsCookBtn);
        emailEdTxt = findViewById(R.id.emailEdTxt);
        passowrdEdTxt = findViewById(R.id.passwordEdTxt);
        resultTxtVw = findViewById(R.id.resultTxtVw);
        registerTxtVw = findViewById(R.id.registerTxtVw);

        ApiMethods apiMethods = new ApiMethods(LoginActivity.this);

        returnBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        letsCookBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (emailEdTxt.getText().toString().isEmpty() || passowrdEdTxt.getText().toString().isEmpty()){
                    resultTxtVw.setBackground(AppCompatResources.getDrawable(getApplicationContext(),R.drawable.result));
                    resultTxtVw.setText("All fields are required");
                    return;
                }

                apiMethods.getUser(emailEdTxt.getText().toString(), passowrdEdTxt.getText().toString(), new ApiMethods.VolleyCallBack() {
                    @Override
                    public void OnSuccess(Object object) {
                        User user = (User)object;
                        Intent intent = new Intent(getApplicationContext(), ListRecipiesActivity.class);
                        intent.putExtra("userId", user.getId());
                        startActivity(intent);
                    }

                    @Override
                    public void OnFailure(String error) {
                        resultTxtVw.setBackgroundColor(Color.parseColor("#F73333"));
                        resultTxtVw.setText("Not found, please try again");
                    }
                });
            }
        });

        registerTxtVw.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), RegisterActivity.class);
                startActivityForResult(intent,1);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == 1){
            if (resultCode == Activity.RESULT_OK){
                emailEdTxt.setText(data.getStringExtra("email"));
                passowrdEdTxt.setText(data.getStringExtra("password"));
            }
        }

    }
}

