/*
===============================================================================
            SINGLE RESPONSIBILITY PRINCIPLE (SRP) - AFTER
===============================================================================

Definition
----------
A class should have only one reason to change.

Idea
----
Instead of putting everything inside the User class,
we split each responsibility into its own class.

Classes in this example:

1- User            -> Holds user data.
2- UserRepository  -> Saves user.
3- EmailService    -> Sends emails.
4- UserPrinter     -> Prints user information.

Now every class has ONE responsibility only.

Benefits
--------
✔ Easy to maintain.
✔ Easy to test.
✔ Easy to reuse.
✔ Easy to modify.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class SRP_After {

    public static void Run() {

        // Create a user object
        OldUser user = new OldUser(
                "Ahmed",
                "ahmed@gmail.com");

        /*
         * Instead of asking User to do everything,
         * each specialized class performs its own job.
         */

        UserRepository repository = new UserRepository();
        EmailService emailService = new EmailService();
        UserPrinter printer = new UserPrinter();

        // Save user
        repository.save(user);

        // Send welcome email
        emailService.sendWelcomeEmail(user);

        // Print user information
        printer.print(user);
    }
}

/*
 * =============================================================================
 * ==
 * USER
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Store user information ONLY.
 * 
 * Notice:
 * 
 * No database.
 * No printing.
 * No email.
 * 
 * This class now has only ONE reason to change:
 * 
 * "If user information changes."
 * 
 * =============================================================================
 * ==
 */

class User {

    private string name;
    private string email;

    public User(string name, string email) {

        this.name = name;
        this.email = email;
    }

    public string getName() {
        return name;
    }

    public string getEmail() {
        return email;
    }

}

/*
 * =============================================================================
 * ==
 * USER REPOSITORY
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Database operations ONLY.
 * 
 * If tomorrow:
 * 
 * - MySQL changes
 * - PostgreSQL changes
 * - MongoDB changes
 * - API replaces Database
 * 
 * ONLY this class changes.
 * 
 * User class remains untouched.
 * 
 * =============================================================================
 * ==
 */

class UserRepository {

    public void save(OldUser user) {

        Console.WriteLine("\n========== DATABASE ==========");

        Console.WriteLine("Connecting to database...");

        Console.WriteLine("Saving user : " + user.getName());

        Console.WriteLine("User saved successfully.");

    }

}

/*
 * =============================================================================
 * ==
 * EMAIL SERVICE
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Sending emails ONLY.
 * 
 * If tomorrow:
 * 
 * - Gmail API changes
 * - SMTP changes
 * - Outlook is used
 * - SMS replaces Email
 * 
 * Only this class changes.
 * 
 * =============================================================================
 * ==
 */

class EmailService {

    public void sendWelcomeEmail(OldUser user) {

        Console.WriteLine("\n========== EMAIL ==========");

        Console.WriteLine("Connecting to mail server...");

        Console.WriteLine("Sending welcome email to:");

        Console.WriteLine(user.getEmail());

        Console.WriteLine("Email sent successfully.");

    }

}

/*
 * =============================================================================
 * ==
 * USER PRINTER
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Display user information ONLY.
 * 
 * If tomorrow:
 * 
 * Console output changes
 * PDF is required
 * HTML report is required
 * 
 * Only this class changes.
 * 
 * =============================================================================
 * ==
 */

class UserPrinter {

    public void print(OldUser user) {

        Console.WriteLine("\n========== USER ==========");

        Console.WriteLine("Name  : " + user.getName());

        Console.WriteLine("Email : " + user.getEmail());

    }

}

/*
 * =============================================================================
 * ==
 * SUMMARY
 * =============================================================================
 * ==
 * 
 * Before SRP
 * 
 * User Class
 * -----------
 * ❌ Store Data
 * ❌ Save Data
 * ❌ Send Email
 * ❌ Print Data
 * 
 * Too many responsibilities.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * After SRP
 * 
 * User
 * ✔ Store data
 * 
 * UserRepository
 * ✔ Save data
 * 
 * EmailService
 * ✔ Send email
 * 
 * UserPrinter
 * ✔ Print data
 * 
 * Each class has ONE responsibility.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * Interview Question
 * 
 * Q: Why is this design better?
 * 
 * Answer:
 * 
 * Because every class has only one responsibility.
 * A change in the database, email, or printing logic
 * will not affect the User class.
 * 
 * This follows the Single Responsibility Principle.
 * 
 * =============================================================================
 * ==
 */