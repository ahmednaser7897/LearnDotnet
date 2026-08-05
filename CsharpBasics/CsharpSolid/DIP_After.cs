/*
===============================================================================
         DEPENDENCY INVERSION PRINCIPLE (DIP) - AFTER
===============================================================================

Definition
----------
High-level modules should not depend on low-level modules.
Both should depend on abstractions.

Idea
----
Instead of making NotificationService depend directly on
EmailService, it depends on a Notification interface.

Now any notification type can be used
without changing NotificationService.

Benefits
--------
✔ Loose Coupling.
✔ Easy to extend.
✔ Easy to test.
✔ Easy to maintain.
✔ Reusable code.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class DIP_After {

    public static void Run() {

        /*
         * The NotificationService doesn't know
         * which notification type it is using.
         * 
         * It only knows the Notification interface.
         */

        Notification email = new EmailNotification();

        Notification sms = new SMSNotification();

        Notification push = new PushNotification();

        NotificationService service;

        service = new NotificationService(email);
        service.sendNotification();

        service = new NotificationService(sms);
        service.sendNotification();

        service = new NotificationService(push);
        service.sendNotification();

    }

}

/*
 * =============================================================================
 * ==
 * NOTIFICATION
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Defines a common contract for all
 * notification types.
 * 
 * Every notification must implement send().
 * 
 * The high-level module depends on this interface,
 * not on a specific implementation.
 * 
 * =============================================================================
 * ==
 */

interface Notification {

    void send();

}

/*
 * =============================================================================
 * ==
 * EMAIL NOTIFICATION
 * =============================================================================
 * ==
 * 
 * Low-Level Module
 * 
 * Responsible only for sending emails.
 * 
 * =============================================================================
 * ==
 */

class EmailNotification : Notification {

    public void send() {

        Console.WriteLine("\nSending Email Notification...");

    }

}

/*
 * =============================================================================
 * ==
 * SMS NOTIFICATION
 * =============================================================================
 * ==
 * 
 * Low-Level Module
 * 
 * Responsible only for sending SMS.
 * 
 * =============================================================================
 * ==
 */

class SMSNotification : Notification {

    public void send() {

        Console.WriteLine("\nSending SMS Notification...");

    }

}

/*
 * =============================================================================
 * ==
 * PUSH NOTIFICATION
 * =============================================================================
 * ==
 * 
 * Low-Level Module
 * 
 * Responsible only for sending Push Notifications.
 * 
 * =============================================================================
 * ==
 */

class PushNotification : Notification {

    public void send() {

        Console.WriteLine("\nSending Push Notification...");

    }

}

/*
 * =============================================================================
 * ==
 * NOTIFICATION SERVICE
 * =============================================================================
 * ==
 * 
 * High-Level Module
 * 
 * Notice:
 * 
 * NotificationService no longer creates
 * EmailNotification.
 * 
 * Instead, it receives any object
 * that implements Notification.
 * 
 * This is called Dependency Injection.
 * 
 * The service depends only on
 * the Notification abstraction.
 * 
 * =============================================================================
 * ==
 */

class NotificationService {

    /*
     * Depending on abstraction
     * instead of concrete implementation.
     */

    private Notification notification;

    /*
     * Constructor Injection
     * 
     * Dependency is provided from outside.
     * 
     * NotificationService doesn't care
     * whether it receives:
     * 
     * Email
     * SMS
     * Push
     * 
     * As long as it implements Notification.
     */

    public NotificationService(Notification notification) {

        this.notification = notification;

    }

    public void sendNotification() {

        Console.WriteLine("Preparing notification...");

        notification.send();

        Console.WriteLine("Notification Sent.");

    }

}

/*
 * =============================================================================
 * ==
 * WHY IS THIS BETTER?
 * =============================================================================
 * ==
 * 
 * Before
 * 
 * NotificationService
 * |
 * V
 * EmailService
 * 
 * Problem:
 * 
 * High-level module depends on
 * a concrete class.
 * 
 * Every new notification type
 * requires modifying NotificationService.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * After
 * 
 * Notification
 * ▲
 * ┌─────────────┼─────────────┐
 * │ │ │
 * │ │ │
 * EmailNotification SMSNotification PushNotification
 * │ │ │
 * └─────────────┼─────────────┘
 * ▲
 * │
 * NotificationService
 * 
 * Now the service depends only
 * on the interface.
 * 
 * Adding a new notification type
 * requires creating a new class only.
 * 
 * NotificationService remains unchanged.
 * 
 * =============================================================================
 * ==
 * 
 * Real Life Example
 * 
 * Imagine a TV.
 * 
 * The TV doesn't care whether you connect:
 * 
 * ✔ PlayStation
 * ✔ Xbox
 * ✔ Laptop
 * ✔ Chromecast
 * 
 * It only needs an HDMI connection.
 * 
 * HDMI = Interface (Abstraction)
 * 
 * PlayStation/Xbox = Implementations
 * 
 * The TV depends on the HDMI standard,
 * not on a specific device.
 * 
 * This is exactly how DIP works.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why does this code follow DIP?
 * 
 * Answer:
 * 
 * Because the high-level module
 * (NotificationService)
 * 
 * depends on the Notification interface
 * instead of depending on EmailNotification,
 * SMSNotification, or PushNotification.
 * 
 * This removes tight coupling and makes
 * the system easy to extend and maintain.
 * 
 * =============================================================================
 * ==
 * 
 * SOLID PRINCIPLES SUMMARY
 * =============================================================================
 * ==
 * 
 * S - Single Responsibility Principle
 * -----------------------------------
 * One class should have one responsibility.
 * 
 * Example:
 * User -> Stores user data only.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * O - Open / Closed Principle
 * ---------------------------
 * Open for extension.
 * Closed for modification.
 * 
 * Example:
 * Add a new payment method
 * without modifying existing code.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * L - Liskov Substitution Principle
 * ---------------------------------
 * Child classes must be replaceable
 * with their parent classes.
 * 
 * Example:
 * Penguin should not inherit flying behavior.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * I - Interface Segregation Principle
 * -----------------------------------
 * Don't force classes to implement
 * methods they don't need.
 * 
 * Example:
 * Robot shouldn't implement eat() or sleep().
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * D - Dependency Inversion Principle
 * ----------------------------------
 * Depend on abstractions,
 * not concrete implementations.
 * 
 * Example:
 * NotificationService depends on Notification
 * instead of EmailNotification.
 * 
 * =============================================================================
 * ==
 * 
 * Congratulations 🎉
 * 
 * You have completed the five SOLID principles.
 * 
 * The next recommended topics are:
 * 
 * 1. Composition vs Inheritance
 * 2. Association / Aggregation / Composition
 * 3. Abstract Class vs Interface
 * 4. Polymorphism
 * 5. Encapsulation
 * 6. Design Patterns (Factory, Strategy, Observer, Singleton)
 * 
 * These topics naturally build on SOLID and are
 * commonly asked in C# and .NET interviews.
 * 
 * =============================================================================
 * ==
 * 
 */
