package com.example.pfemobile;

import android.os.Bundle;
import android.util.Base64;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.bumptech.glide.Glide;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class RecipeAcivity extends AppCompatActivity {
    TextView foodNameTxtVw,ingredientsList,directionsList;
    ApiMethods apiMethods;
    LinearLayout picsContainer;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipe);
        String foodName = getIntent().getStringExtra("foodName");


        ingredientsList = findViewById(R.id.ingredientsList);
        directionsList = findViewById(R.id.directionsList);
        foodNameTxtVw = findViewById(R.id.foodNameInRecipe);
        foodNameTxtVw.setText(foodName);

        picsContainer = findViewById(R.id.picsContainer);

        apiMethods = new ApiMethods(getApplicationContext());

        //Get recipes
        apiMethods.getRecipeByName(foodName, new ApiMethods.VolleyCallBack() {
            @Override
            public void OnSuccess(Object object) {
                try {
                    //Get pics
                    JSONArray pics = ((JSONObject) object).getJSONArray("foodPics");

                    for (int i = 0; i < 3; i++){
                        ImageView imageView = new ImageView(getApplicationContext());
                        imageView.setLayoutParams(new LinearLayout.LayoutParams(670,600));
                        imageView.setScaleType(ImageView.ScaleType.FIT_XY);

                        //Convert to image
                        Glide.with(getApplicationContext())
                                .asBitmap()
                                .load(Base64.decode(pics.getJSONObject(0).getString("pic"+ (i+1)).getBytes(),Base64.DEFAULT))
                                .into(imageView);

                        picsContainer.addView(imageView);
                    }

                    //Get ingredients
                    JSONArray recipes = ((JSONObject)object).getJSONArray("recipes");

                    String stringList ="";

                    for (int i = 0; i < recipes.length(); i++){
                        JSONObject jsonObject = recipes.getJSONObject(i);
                        double ingredientQte = jsonObject.getDouble("quantity");
                        String ingredientName = jsonObject.getString("name");

                        stringList += ingredientQte +" * "+ ingredientName + "\n";
                    }

                    ingredientsList.setText(stringList);

                    //Get directions
                    JSONArray directions = ((JSONObject)object).getJSONArray("directions");

                    stringList ="";

                    for (int i = 0; i < directions.length(); i++){
                        JSONObject jsonObject = directions.getJSONObject(i);
                        String direction = jsonObject.getString("directions");

                        stringList +="Setup "+ (i+1) + "\n\n" + direction +"\n\n\n";
                    }

                    directionsList.setText(stringList);

                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void OnFailure(String error) {
                Toast.makeText(getApplicationContext(), "Error occured: "+error, Toast.LENGTH_SHORT).show();
            }
        });
    }
}