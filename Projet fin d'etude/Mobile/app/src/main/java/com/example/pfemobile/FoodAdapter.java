package com.example.pfemobile;

import android.content.Context;
import android.content.Intent;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import java.util.List;

public class FoodAdapter extends RecyclerView.Adapter<FoodAdapter.viewHolder> {
    private List<Food> foods;
    Context context;

    public  FoodAdapter(Context context, List<Food> foods){
        this.context = context;
        this.foods = foods;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public int getItemViewType(int position) {
        return position;
    }

    @NonNull
    @Override
    public viewHolder onCreateViewHolder(@NonNull  ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.food_item, parent, false);
        return new viewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull FoodAdapter.viewHolder holder, int position) {
        holder.servingsTxtVw.setText("* "+String.valueOf(foods.get(position).getServings()));
        holder.foodNameTxtVw.setText(foods.get(position).getName());

        //Split Cooking time into hours and minutes
        int cookingTime = foods.get(position).getCookingTime();
        if (cookingTime < 60)
            holder.cookingTimeTxtVw.setText(String.valueOf(cookingTime)+" m");
        else{
            int hours = cookingTime/60;
            int minutes = cookingTime - (hours * 60);
            if (minutes == 0)
                holder.cookingTimeTxtVw.setText(String.valueOf(hours) +" h");
            else
                holder.cookingTimeTxtVw.setText(String.valueOf(hours) +" h "+String.valueOf(minutes)+" m");
        }

        //Convert to image
        Glide.with(context)
                .asBitmap()
                .load(Base64.decode(foods.get(position).getPicsStrings()[0].getBytes(),Base64.DEFAULT))
                .into(holder.foodPic);

        holder.mainLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(context, RecipeAcivity.class);
                intent.putExtra("foodName", foods.get(position).getName());
                context.startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        return foods.size();
    }

    public class viewHolder extends RecyclerView.ViewHolder {

        TextView foodNameTxtVw, servingsTxtVw, cookingTimeTxtVw;
        ImageView foodPic ;
        ConstraintLayout mainLayout ;

        public viewHolder(@NonNull View itemView) {
            super(itemView);
            foodNameTxtVw = itemView.findViewById(R.id.foodNameTxtVw);
            servingsTxtVw = itemView.findViewById(R.id.servingsTxtVw);
            cookingTimeTxtVw = itemView.findViewById(R.id.cookingTimeTxtVw);
            foodPic = itemView.findViewById(R.id.foodPic);

            mainLayout = itemView.findViewById(R.id.mainLayout);
        }
    }

}