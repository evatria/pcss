package application.dataTypes;

import java.util.Random;

public class User {


    private String username;
    private String password;
    private int id;


    public User(String username, String password){
        this.username = username;
        this.password = password;

        Random cd = new Random();
        id = cd.nextInt();
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getId() {
        return id;
    }

}