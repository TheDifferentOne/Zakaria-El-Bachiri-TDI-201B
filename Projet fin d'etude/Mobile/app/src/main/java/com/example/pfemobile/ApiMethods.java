package com.example.pfemobile;

import android.content.Context;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class ApiMethods {
    private static Context context;

    public ApiMethods(Context context) {
        this.context = context;
    }

    public interface VolleyCallBack{
        void OnSuccess(Object object);
        void OnFailure(String error);
    }


    public void getUser(String email, String password,final VolleyCallBack volleyCallBack) {
        String url = "http://192.168.0.191:8070/api/accounts/"+email+"/"+password;
        User user = new User();

        JsonObjectRequest request = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                try {
                    user.setId(response.getInt("id"));
                    user.setFirstName(response.getString("firstName"));
                    user.setLastName(response.getString("lastName"));
                    user.setUserType(response.getString("userType"));
                    user.setEmail(response.getString("email"));
                    user.setPassword(response.getString("password"));
                } catch (JSONException error) {
                    Toast.makeText(context.getApplicationContext(), error.getMessage(), Toast.LENGTH_SHORT).show();
                }
                volleyCallBack.OnSuccess(user);
                Toast.makeText(context.getApplicationContext(), "👍", Toast.LENGTH_SHORT).show();
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                volleyCallBack.OnFailure(error.getMessage());
            }
        });
        Singelton.getInstance(context).addRequestQueue(request);
    }

    public void postUser(String firstName,String lastName,String email, String password,final VolleyCallBack volleyCallBack) {
        String url = "http://192.168.0.191:8070/api/accounts";

        JSONObject jsonObject = new JSONObject();
        try {
            jsonObject.put("userType","regular");
            jsonObject.put("firstName", firstName);
            jsonObject.put("lastName", lastName);
            jsonObject.put("email", email);
            jsonObject.put("password", password);
        } catch (JSONException e) {
            e.printStackTrace();
        }

        JsonObjectRequest request = new JsonObjectRequest(Request.Method.POST, url, jsonObject, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                volleyCallBack.OnSuccess(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                volleyCallBack.OnFailure(error.getMessage());
            }
        })
        {
            @Override
            public Map<String, String> getHeaders() throws AuthFailureError {
                HashMap<String, String> headers = new HashMap<>();
                headers.put("Content-Type", "application/json; charset=utf-8");
                return headers;
            }
        };

        Singelton.getInstance(context).addRequestQueue(request);
    }

    public void getAllRecipes(final VolleyCallBack volleyCallBack){
        String url = "http://192.168.0.191:8070/api/foods";
        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                volleyCallBack.OnSuccess(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                volleyCallBack.OnFailure(error.getMessage());
            }
        });
        Singelton.getInstance(context).addRequestQueue(request);

    }

    public void getRecipeByName(String foodName,final VolleyCallBack volleyCallBack){
        String url = "http://192.168.0.191:8070/api/foods/" + foodName;

        JsonObjectRequest request = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                volleyCallBack.OnSuccess(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                volleyCallBack.OnFailure(error.getMessage());
            }
        });
        Singelton.getInstance(context).addRequestQueue(request);
    }

    public void getPicsByFoodName (String foodName, final VolleyCallBack volleyCallBack){
        String url = "http://192.168.0.191:8070/api/foods/"+foodName;

        JsonObjectRequest request = new JsonObjectRequest(Request.Method.GET, url, null, new Response.Listener<JSONObject>() {
            @Override
            public void onResponse(JSONObject response) {
                volleyCallBack.OnSuccess(response);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                volleyCallBack.OnFailure(error.getMessage());
            }
        });
        Singelton.getInstance(context).addRequestQueue(request);
    }
}