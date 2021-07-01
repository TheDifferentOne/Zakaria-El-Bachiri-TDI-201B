package com.example.pfemobile;

import android.content.res.ColorStateList;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.AppCompatButton;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class ListRecipiesActivity extends AppCompatActivity {
    LinearLayout filterByCountry;
    ApiMethods apiMethods;
    FoodAdapter foodAdapter ;
    RecyclerView recyclerView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_recipies);
        ArrayList<Food> foods = new ArrayList<Food>();

        apiMethods = new ApiMethods(getApplicationContext());

        filterByCountry = findViewById(R.id.filterByCountry);
        recyclerView = findViewById(R.id.recyclerView);

        for (int i = 0; i < filterByCountry.getChildCount(); i++){
            filterByCountry.getChildAt(i).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    changeColors((AppCompatButton) v);
                    foods.clear();

                    //All Recipes
                    if (((AppCompatButton) v).getText().equals("All")){

                        apiMethods.getAllRecipes(new ApiMethods.VolleyCallBack() {
                            @Override
                            public void OnSuccess(Object object) {
                                try {
                                    for (int i = 0; i < ((JSONArray) object).length(); i++) {
                                        JSONObject jsonObject = ((JSONArray) object).getJSONObject(i);

                                        String foodName = jsonObject.getString("name");
                                        int cookingTime = jsonObject.getInt("cookingTime");
                                        int servings = jsonObject.getInt("servings");

                                        apiMethods.getPicsByFoodName(foodName, new ApiMethods.VolleyCallBack() {
                                            @Override
                                            public void OnSuccess(Object object) {
                                                try {
                                                    JSONArray jsonArray = ((JSONObject)object).getJSONArray("foodPics");

                                                    //Get pics
                                                    String pics[] = {jsonArray.getJSONObject(0).getString("pic1")};
                                                    foods.add(new Food(foodName,cookingTime,servings,pics));


                                                } catch (JSONException e) {
                                                    Toast.makeText(ListRecipiesActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                                                }

                                                foodAdapter = new FoodAdapter(ListRecipiesActivity.this, foods);
                                                recyclerView.setAdapter(foodAdapter);
                                                recyclerView.setLayoutManager(new LinearLayoutManager(getApplicationContext()));
                                            }
                                            @Override
                                            public void OnFailure(String error) {
                                                Toast.makeText(getApplicationContext(), "Error getting picstures: "+error, Toast.LENGTH_SHORT).show();
                                            }
                                        });
                                    }

                                } catch (JSONException e) {
                                    e.getStackTrace();
                                }
                            }

                            @Override
                            public void OnFailure(String error) {
                                Toast.makeText(getApplicationContext(), "Error occured : "+error, Toast.LENGTH_SHORT).show();
                                return;
                            }
                        });

                    }

                    //Recipe by food name
                    else{
                        apiMethods.getAllRecipes(new ApiMethods.VolleyCallBack() {
                            @Override
                            public void OnSuccess(Object object) {
                                try {
                                    for (int i = 0; i < ((JSONArray) object).length(); i++) {
                                        JSONObject jsonObject = ((JSONArray) object).getJSONObject(i);

                                        String country = jsonObject.getString("country");
                                        String foodName = jsonObject.getString("name");
                                        int cookingTime = jsonObject.getInt("cookingTime");
                                        int servings = jsonObject.getInt("servings");

                                        if (country.equals(((AppCompatButton)v).getText()))
                                            apiMethods.getPicsByFoodName(foodName, new ApiMethods.VolleyCallBack() {
                                                @Override
                                                public void OnSuccess(Object object) {
                                                    try {
                                                        JSONArray jsonArray = ((JSONObject)object).getJSONArray("foodPics");

                                                        //Get pics
                                                        String pics[] = {jsonArray.getJSONObject(0).getString("pic1")};

                                                        //Fill list
                                                        foods.add(new Food(foodName,cookingTime,servings,pics));

                                                    } catch (JSONException e) {
                                                        Toast.makeText(ListRecipiesActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                                                    }

                                                    foodAdapter = new FoodAdapter(ListRecipiesActivity.this, foods);
                                                    recyclerView.setAdapter(foodAdapter);
                                                    recyclerView.setLayoutManager(new LinearLayoutManager(getApplicationContext()));
                                                }
                                                @Override
                                                public void OnFailure(String error) {
                                                    Toast.makeText(getApplicationContext(), "Error getting picstures: "+error, Toast.LENGTH_SHORT).show();
                                                }
                                            });
                                    }

                                } catch (JSONException e) {
                                    e.getStackTrace();
                                }
                            }

                            @Override
                            public void OnFailure(String error) {
                                Toast.makeText(getApplicationContext(), "Error occured : "+error, Toast.LENGTH_SHORT).show();
                                return;
                            }
                        });
                    }
                }
            });
        }
    }

    private void changeColors(AppCompatButton clickedBtn){
        for (int i = 0; i < filterByCountry.getChildCount(); i++){
            if (filterByCountry.getChildAt(i) == clickedBtn){
                clickedBtn.setBackgroundTintList(getColorStateList(R.color.primary_color));
                clickedBtn.setTextColor(Color.BLACK);
            }
            else{
                ((AppCompatButton)filterByCountry.getChildAt(i)).setBackgroundTintList(ColorStateList.valueOf(Color.parseColor("#333333")));
                ((AppCompatButton)filterByCountry.getChildAt(i)).setTextColor(Color.WHITE);
            }
        }
    }

    private void getPics(String foodName){
        apiMethods.getPicsByFoodName(foodName, new ApiMethods.VolleyCallBack() {
            @Override
            public void OnSuccess(Object object) {
                Toast.makeText(getApplicationContext(), object.toString(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void OnFailure(String error) {
                Toast.makeText(getApplicationContext(), "Error getting pics : "+error, Toast.LENGTH_SHORT).show();
            }
        });
    }

}
