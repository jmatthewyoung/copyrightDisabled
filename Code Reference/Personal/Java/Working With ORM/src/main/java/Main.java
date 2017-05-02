
import java.util.List;
import org.hibernate.Query;
import org.hibernate.Session;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Matthew
 */
public class Main {
    
    public static void main(String[] args){
        Session session = HUtility.getSessionFactory().openSession();
        
        session.beginTransaction();
        
        Person p = new Person(1, "First", "Last", 510191, 122334444, "8141513", "username", "password");
        session.save(p);
 
        session.getTransaction().commit();
 
        Query q = session.createQuery("From Person");
                 
        List<Person> resultList = q.list();
        System.out.println("Number of people: " + resultList.size());
        for (Person person : resultList) {
            System.out.println("Next person: " + person.getFirstName());
        }
        
        session.close();
    }
}
