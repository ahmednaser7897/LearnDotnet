/*
===============================================================================
                    OCP vs DIP (Practical Comparison)
===============================================================================

Many developers think OCP and DIP are the same because both use interfaces.

They are NOT the same.

OCP
---
Goal:
Add new features WITHOUT modifying existing code.

Question:
"How can I add a new feature?"

DIP
---
Goal:
Reduce coupling between classes.

Question:
"What should my class depend on?"

In this example we will demonstrate both principles.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class OCP_vs_DIP {

    public static void Run() {

        Console.WriteLine("========== OCP Example ==========");

        PaymentProcessor paymentProcessor = new PaymentProcessor();

        paymentProcessor.process(new CreditCardPayment());

        paymentProcessor.process(new PayPalPayment());

        paymentProcessor.process(new CryptoPayment());

        Console.WriteLine("\n\n========== DIP Example ==========");

        NotificationService emailService = new NotificationService(new EmailNotification());

        emailService.send();

        NotificationService smsService = new NotificationService(new SMSNotification());

        smsService.send();

    }
    /*
     * =============================================================================
     * ==
     * OCP EXAMPLE
     * =============================================================================
     * ==
     * 
     * Goal:
     * Add new payment methods
     * WITHOUT changing PaymentProcessor.
     * 
     * PaymentProcessor never changes.
     * 
     * Only new payment classes are added.
     * 
     * =============================================================================
     * ==
     */

    interface PaymentMethod {

        void pay();

    }

    class CreditCardPayment : global::CsharpFundamentals.Solid.PaymentMethod {

        public void pay() {

            Console.WriteLine("Credit Card Payment");

        }

    }

    class PayPalPayment : global::CsharpFundamentals.Solid.PaymentMethod {

        public void pay() {

            Console.WriteLine("PayPal Payment");

        }

    }

    /*
     * New Feature
     * 
     * Company wants Crypto payment.
     * 
     * Did we modify PaymentProcessor?
     * 
     * NO
     * 
     * We simply created a new class.
     * 
     * This is OCP.
     */

    class CryptoPayment : global::CsharpFundamentals.Solid.PaymentMethod {

        public void pay() {

            Console.WriteLine("Crypto Payment");

        }

    }

    class PaymentProcessor {

        /*
         * This class never changes.
         * 
         * It accepts ANY PaymentMethod.
         * 
         * New payment?
         * -> Create a new class only.
         * 
         * OCP achieved.
         */

        public void process(global::CsharpFundamentals.Solid.PaymentMethod paymentMethod) {

            paymentMethod.pay();

        }

    }

    /*
     * =============================================================================
     * ==
     * DIP EXAMPLE
     * =============================================================================
     * ==
     * 
     * Goal:
     * NotificationService should NOT depend on EmailNotification.
     * 
     * Instead it depends on Notification.
     * 
     * This reduces coupling.
     * 
     * =============================================================================
     * ==
     */

    interface Notification {

        void send();

    }

    class EmailNotification : global::CsharpFundamentals.Solid.Notification {

        public void send() {

            Console.WriteLine("Email Notification");

        }

    }

    class SMSNotification : global::CsharpFundamentals.Solid.Notification {

        public void send() {

            Console.WriteLine("SMS Notification");

        }

    }

    class NotificationService {

        /*
         * Notice
         * 
         * We don't write:
         * 
         * EmailNotification email = new EmailNotification();
         * 
         * Instead we depend on Notification.
         * 
         * This is DIP.
         */

        private global::CsharpFundamentals.Solid.Notification notification;

        public NotificationService(global::CsharpFundamentals.Solid.Notification notification) {

            this.notification = notification;

        }

        public void send() {

            notification.send();

        }

    }

    /*
     * =============================================================================
     * ==
     * FINAL DIFFERENCE
     * =============================================================================
     * ==
     * 
     * OCP
     * 
     * Focus:
     * ------
     * Adding Features
     * 
     * Example:
     * --------
     * Need Apple Pay?
     * 
     * Create:
     * 
     * class ApplePayPayment : PaymentMethod
     * 
     * Nothing else changes.
     * 
     * =============================================================================
     * ==
     * 
     * DIP
     * 
     * Focus:
     * ------
     * Dependencies
     * 
     * Bad
     * 
     * NotificationService
     * |
     * V
     * EmailNotification
     * 
     * Good
     * 
     * NotificationService
     * |
     * V
     * Notification Interface
     * ^
     * |
     * EmailNotification
     * SMSNotification
     * PushNotification
     * 
     * =============================================================================
     * ==
     * 
     * Easy Way To Remember
     * 
     * OCP
     * ---
     * "Don't modify old code when adding new features."
     * 
     * DIP
     * ---
     * "Don't depend on concrete classes.
     * Depend on interfaces."
     * 
     * =============================================================================
     * ==
     * 
     * Important Note
     * 
     * Using DIP often HELPS you achieve OCP.
     * 
     * Because depending on interfaces makes
     * adding new implementations very easy.
     * 
     * But...
     * 
     * They solve DIFFERENT problems.
     * 
     * =============================================================================
     * ==
     */
}
