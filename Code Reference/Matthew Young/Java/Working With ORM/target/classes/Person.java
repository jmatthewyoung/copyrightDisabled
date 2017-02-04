import javax.persistence.*;

/**
 *
 * @author Matthew
 */
@Entity
@Table
public class Person {
    
    @Id
    private int id;
    private String firstName;
    private String lastName;
    private int dob;
    private int ssn;
    private String licenseID;
    private String userName;
    private String password;

    public Person(int id, String firstName, String lastName, int dob, int ssn, String licenseID, String userName, String password){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dob = dob;
        this.ssn = ssn;
        this.licenseID = licenseID;
        this.userName = userName;
        this.password = password;
    }
    
    /**
     * @return the id
     */
    public int getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return the firstName
     */
    public String getFirstName() {
        return firstName;
    }

    /**
     * @param firstName the firstName to set
     */
    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    /**
     * @return the lastName
     */
    public String getLastName() {
        return lastName;
    }

    /**
     * @param lastName the lastName to set
     */
    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    /**
     * @return the dob
     */
    public int getDob() {
        return dob;
    }

    /**
     * @param dob the dob to set
     */
    public void setDob(int dob) {
        this.dob = dob;
    }

    /**
     * @return the ssn
     */
    public int getSsn() {
        return ssn;
    }

    /**
     * @param ssn the ssn to set
     */
    public void setSsn(int ssn) {
        this.ssn = ssn;
    }

    /**
     * @return the licenseID
     */
    public String getLicenseID() {
        return licenseID;
    }

    /**
     * @param licenseID the licenseID to set
     */
    public void setLicenseID(String licenseID) {
        this.licenseID = licenseID;
    }

    /**
     * @return the userName
     */
    public String getUserName() {
        return userName;
    }

    /**
     * @param userName the userName to set
     */
    public void setUserName(String userName) {
        this.userName = userName;
    }

    /**
     * @return the password
     */
    public String getPassword() {
        return password;
    }

    /**
     * @param password the password to set
     */
    public void setPassword(String password) {
        this.password = password;
    }
}
