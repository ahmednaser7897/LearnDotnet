/*
===============================================================================
         DEPENDENCY INVERSION PRINCIPLE (DIP) - BEFORE
===============================================================================

Definition
----------
High-level modules should not depend on low-level modules.
Both should depend on abstractions.

Idea
----
A high-level class should not create or directly depend on
specific implementations.

Instead, it should depend on an interface (abstraction).

In this example, NotificationService directly depends on
EmailService.

If we want to send SMS or Push Notifications later,
we must modify NotificationService.

This violates DIP.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class DIP_Before {

    public static void Run() {

        OldNotificationService notificationService = new OldNotificationService();

        notificationService.sendNotification();

    }

}

/*
 * =============================================================================
 * ==
 * EMAIL SERVICE
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

class OldEmailService {

    public void sendEmail() {

        Console.WriteLine("Sending Email...");

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
 * Problem
 * -------
 * NotificationService creates EmailService itself.
 * 
 * It is tightly coupled to EmailService.
 * 
 * If tomorrow the company decides to send:
 * 
 * ✔ SMS
 * ✔ Push Notification
 * ✔ WhatsApp
 * ✔ Telegram
 * 
 * We must modify this class.
 * 
 * That breaks DIP.
 * 
 * =============================================================================
 * ==
 */

class OldNotificationService {

    /*
     * Tight Coupling
     * 
     * NotificationService knows exactly
     * which implementation it is using.
     * 
     * This is bad because the class
     * depends on a concrete class.
     */

    private OldEmailService emailService = new OldEmailService();

    public void sendNotification() {

        Console.WriteLine("Preparing notification...");

        emailService.sendEmail();

        Console.WriteLine("Notification Sent.");

    }

}

/*
 * =============================================================================
 * ==
 * WHY BAD?
 * =============================================================================
 * ==
 * 
 * Current Design
 * 
 * NotificationService
 * |
 * |
 * V
 * EmailService
 * 
 * Tomorrow:
 * 
 * Need SMS?
 * 
 * Modify NotificationService.
 * 
 * Need Push Notification?
 * 
 * Modify NotificationService.
 * 
 * Need WhatsApp?
 * 
 * Modify NotificationService.
 * 
 * Every new notification type requires
 * changing the high-level class.
 * 
 * This violates DIP.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why does this code violate DIP?
 * 
 * Answer:
 * 
 * Because the high-level module
 * (NotificationService)
 * 
 * directly depends on a concrete class
 * (EmailService)
 * 
 * instead of depending on an abstraction.
 * 
 * =============================================================================
 * ==
 */