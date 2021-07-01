package com.example.pfemobile;

import android.content.Context;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;

public class Singelton {
    private static  Singelton instance;
    private RequestQueue requestQueue;
    private Context context;

    public Singelton(Context context){
        this.context = context;

    }

    public static synchronized Singelton getInstance(Context context){
        if (instance==null){
            instance = new Singelton(context);
        }
        return instance;
    }

    public RequestQueue getRequestQueue(){
        if (requestQueue == null){
            requestQueue = Volley.newRequestQueue(context.getApplicationContext());
        }
        return requestQueue;
    }

    public <T> void addRequestQueue(Request<T> req){
        getRequestQueue().add(req);
    }
}