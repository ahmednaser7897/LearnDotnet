/*
================================================================================
                  SINGLE RESPONSIBILITY PRINCIPLE (SRP) - BEFORE
================================================================================

Definition
----------
A class should have one, and only one, reason to change.

Meaning
-------
A class should have only ONE responsibility.
If the class changes because of more than one reason,
then it violates the Single Responsibility Principle.

Why was SRP introduced?
-----------------------
In large projects, developers used to put everything inside one class.

For example:
- Store user information.
- Save data to the database.
- Send emails.
- Print reports.
- Write logs.

At first, everything seems fine.

As the project grows, every new requirement forces developers
to edit the same class.

Eventually, the class becomes very large, difficult to understand,
hard to test, and risky to modify.

What does "One Reason To Change" mean?
--------------------------------------
A class should change for ONLY ONE business reason.

Example:

If the database changes
-> Only the database class should change.

If email logic changes
-> Only the email class should change.

If printing changes
-> Only the printing class should change.

NOT the User class.

Real Life Example
-----------------
Imagine a restaurant.

One employee:

- Takes customer orders.
- Cooks food.
- Cleans tables.
- Answers phone calls.
- Collects payments.

This employee has many responsibilities.

If anything changes,
the same employee must learn and change.

Better design:

Waiter
Chef
Cashier
Cleaner

Each person has ONE responsibility.

This is exactly what SRP teaches.

Why is this example BAD?
------------------------
The User class below has FOUR responsibilities.

1- Hold user data.
2- Save data.
3- Send email.
4- Print information.

That means it has FOUR different reasons to change.

This file intentionally violates SRP.

================================================================================
*/
namespace CsharpFundamentals.Solid;

public class SRP_Before {

    public static void Run() {

        OldUser user = new OldUser(
                "Ahmed",
                "ahmed@gmail.com");

        // Database responsibility
        user.saveUser();

        // Email responsibility
        user.sendWelcomeEmail();

        // Printing responsibility
        user.printUserInformation();
    }

}

/*
 * =============================================================================
 * ===
 * USER CLASS
 * =============================================================================
 * ===
 * 
 * This class is doing TOO MANY JOBS.
 * 
 * Responsibilities:
 * 
 * 1- Store user data.
 * 2- Save user.
 * 3- Send emails.
 * 4- Print user information.
 * 
 * According to SRP,
 * this class should ONLY store user data.
 * 
 * Everything else belongs to different classes.
 * 
 * =============================================================================
 * ===
 */

class OldUser {

    /*
     * --------------------------------------------------------------------------
     * Responsibility #1
     * 
     * Store user data.
     * 
     * This is the ONLY responsibility
     * that should remain inside this class.
     * --------------------------------------------------------------------------
     */

    private string name;
    private string email;

    public OldUser(string name, string email) {

        this.name = name;
        this.email = email;
    }

    public string getName() {

        return name;
    }

    public string getEmail() {

        return email;
    }

    /*
     * --------------------------------------------------------------------------
     * Responsibility #2
     * 
     * Save user into database.
     * 
     * WHY IS THIS WRONG?
     * 
     * Because database logic is a completely different responsibility.
     * 
     * If tomorrow:
     * 
     * - Database changes
     * - SQL changes
     * - MongoDB is used
     * - API replaces database
     * 
     * We must modify THIS class.
     * 
     * User should never change because of database changes.
     * 
     * This violates SRP.
     * --------------------------------------------------------------------------
     */

    public void saveUser() {

        Console.WriteLine("\n========== DATABASE ==========");

        Console.WriteLine("Connecting to database...");

        Console.WriteLine("Saving user...");

        Console.WriteLine("User saved successfully.");

    }

    /*
     * --------------------------------------------------------------------------
     * Responsibility #3
     * 
     * Send email.
     * 
     * WHY IS THIS WRONG?
     * 
     * Email has nothing to do with User.
     * 
     * Imagine tomorrow:
     * 
     * Gmail API changes.
     * 
     * SMTP changes.
     * 
     * We start using Outlook.
     * 
     * We send SMS instead of Email.
     * 
     * User class must change again.
     * 
     * Another reason to change.
     * 
     * This violates SRP.
     * --------------------------------------------------------------------------
     */

    public void sendWelcomeEmail() {

        Console.WriteLine("\n========== EMAIL ==========");

        Console.WriteLine("Connecting to mail server...");

        Console.WriteLine("Sending welcome email...");

        Console.WriteLine("Recipient : " + email);

        Console.WriteLine("Email sent.");

    }

    /*
     * --------------------------------------------------------------------------
     * Responsibility #4
     * 
     * Print user information.
     * 
     * WHY IS THIS WRONG?
     * 
     * Printing belongs to presentation logic.
     * 
     * Tomorrow:
     * 
     * Console output changes.
     * 
     * PDF report is required.
     * 
     * HTML report is required.
     * 
     * Printer changes.
     * 
     * User class changes AGAIN.
     * 
     * Another reason to change.
     * 
     * This violates SRP.
     * --------------------------------------------------------------------------
     */

    public void printUserInformation() {

        Console.WriteLine("\n========== USER ==========");

        Console.WriteLine("Name  : " + name);

        Console.WriteLine("Email : " + email);

    }

}

/*
 * =============================================================================
 * ===
 * SUMMARY
 * =============================================================================
 * ===
 * 
 * Problems in this design
 * 
 * [1] Too many responsibilities.
 * 
 * [2] Too many reasons to change.
 * 
 * [3] Difficult to maintain.
 * 
 * [4] Difficult to test.
 * 
 * [5] Difficult to reuse.
 * 
 * [6] High chance of introducing bugs.
 * 
 * Interview Question
 * ------------------
 * 
 * Q: Why does this class violate SRP?
 * 
 * A:
 * Because it is responsible for storing data,
 * saving data,
 * sending emails,
 * and printing information.
 * 
 * It has multiple reasons to change.
 * 
 * The next file (SRP_After.java) will separate each responsibility
 * into its own class.
 * 
 * =============================================================================
 * ===
 */