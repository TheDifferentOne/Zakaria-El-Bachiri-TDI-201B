package com.example.pfemobile;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class RegisterActivity extends AppCompatActivity {
    EditText firstName, lastName, email, password, passwordAgain;
    Button createBtn;
    TextView result;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        //initiate apiMethods class
        ApiMethods apiMethods = new ApiMethods(getApplicationContext());

        firstName = findViewById(R.id.firstNameEdTxt);
        lastName = findViewById(R.id.lastNameEdTxt);
        email = findViewById(R.id.emailEdtxtInRegister);
        password = findViewById(R.id.pwdEdtxtInRegister);
        passwordAgain = findViewById(R.id.pwdAgainEdtxtInRegister);
        createBtn = findViewById(R.id.createBtn);
        result = findViewById(R.id.resultTxtVw);

        //Set focus on first field
        firstName.setFocusable(true);
        //Disable password again field
        passwordAgain.setEnabled(false);

        //Input validation
        firstName.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus){
                    if (firstName.getText().toString().isEmpty())
                        setResultText("Must fill first name");
                    else
                        setResultText("");
                }
            }
        });

        lastName.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {

                    if (lastName.getText().toString().isEmpty())
                        setResultText("Must fill last name");
                    else
                        setResultText("");
                }
            }
        });

        email.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    if (email.getText().toString().isEmpty())
                        setResultText("Email is required");
                    else
                        setResultText("");
                }
            }
        });

        password.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus){
                    if (password.getText().toString().isEmpty())
                        setResultText("Password is required");
                    else
                        setResultText("");
                }
            }
        });

        password.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (password.getText().toString().length() < 6)
                    passwordAgain.setEnabled(false);
                else
                    passwordAgain.setEnabled(true);
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

        passwordAgain.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    if (passwordAgain.getText().toString().isEmpty())
                        setResultText("Must re-type the password");
                    else
                        setResultText("");
                }
            }
        });

        createBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isValid())
                    setResultText("Invalid input or empty fields");
                else{
                    if (!password.getText().toString().equals(passwordAgain.getText().toString()))
                        setResultText("Password doesn't match");
                    else{
                        setResultText("");
                        apiMethods.postUser(firstName.getText().toString(), lastName.getText().toString(),
                                            email.getText().toString(), password.getText().toString(),
                            new ApiMethods.VolleyCallBack() {
                                @Override
                                public void OnSuccess(Object object) {
                                    Toast.makeText(getApplicationContext(),"Welecom to our delecious world 🍽", Toast.LENGTH_SHORT).show();

                                    //Return to login Activity
                                    Intent intent = new Intent();
                                    intent.putExtra("email",email.getText().toString());
                                    intent.putExtra("password",password.getText().toString());
                                    setResult(Activity.RESULT_OK, intent);
                                    finish();
                                }

                                @Override
                                public void OnFailure(String error) {
                                    Toast.makeText(getApplicationContext(),"Error is: "+error,Toast.LENGTH_SHORT).show();
                                }
                            }
                        );
                    }
                }
            }
        });
    }

    public void setResultText(String text){
        if (text.isEmpty()){
            result.setBackgroundColor(Color.TRANSPARENT);
            result.setText("");
        }
        else{
            result.setBackground(getDrawable(R.drawable.result));
            result.setText(text);
        }
    }
    
    public boolean isValid(){
        if (firstName.getText().toString().isEmpty() || lastName.getText().toString().isEmpty() || email.getText().toString().isEmpty()
            || password.getText().toString().isEmpty() || passwordAgain.getText().toString().isEmpty())
            return false;
        return true;
    }
}