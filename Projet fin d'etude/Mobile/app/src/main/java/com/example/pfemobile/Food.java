package com.example.pfemobile;

public class Food {
    private String name, picsStrings[];
    private int cookingTime ,servings;

    public Food(String name, int cookingTime, int servings, String picsStrings[]) {
        this.name = name;
        this.cookingTime = cookingTime;
        this.servings = servings;
        this.picsStrings = picsStrings;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getCookingTime() {
        return cookingTime;
    }

    public void setCookingTime(int cookingTime) {
        this.cookingTime = cookingTime;
    }

    public int getServings() {
        return servings;
    }

    public void setServings(int servings) {
        this.servings = servings;
    }

    public String[] getPicsStrings() {
        return picsStrings;
    }

    public void setPicsStrings(String[] picsStrings) {
        this.picsStrings = picsStrings;
    }
}
