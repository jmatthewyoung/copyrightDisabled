/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pa1_jyoung;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Iterator;

/**
 *
 * @author Matthew
 */
public class Main {
    public static void main(String[] args){
        
        int numRows = 0;
        
        try {
            ArrayList<Person> persons = new ArrayList<>();
            String connectionString = "jdbc:derby://localhost:1527/myDatabase;user=mis320;password=mis320";
            Connection conn = DriverManager.getConnection(connectionString);
            if (conn != null) {
                System.out.println("Connected to database.");
            }
            
            Statement statement = conn.createStatement();
            ResultSet resultSet = statement.executeQuery("SELECT * FROM person order by id");
            
            while (resultSet.next()) {
                numRows++;
                int id = resultSet.getInt("id");
                String firstName = resultSet.getString("firstname");
                String lastName = resultSet.getString("lastname");
                int dob = resultSet.getInt("dob");
                int ssn = resultSet.getInt("ssn");
                String licenseID = resultSet.getString("licenseid");
                String userName = resultSet.getString("username");
                String password = resultSet.getString("password");
                
                Person p = new Person(id, firstName, lastName, dob, ssn, licenseID, userName, password);
                persons.add(p);
            }
            
            Iterator<Person> i = persons.iterator();
            
            System.out.println("Number of rows returned: " + numRows);
            while(i.hasNext()){
                Person p = i.next();
                int id = p.getId();
                String licenseID = p.getLicenseID();
                System.out.println("ID: " + id + " | License #: " + licenseID);
            }
            
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
