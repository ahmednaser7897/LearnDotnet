/*
===============================================================================
             OPEN / CLOSED PRINCIPLE (OCP) - BEFORE
===============================================================================

Definition
----------
Software entities should be:

- Open for Extension.
- Closed for Modification.

Idea
----
When adding a new feature, we should NOT modify existing code.
Instead, we should extend it.

The following example violates OCP because every new payment method
requires modifying the OldPaymentProcessor class.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class OCP_Before {

    public static void Run() {

        OldPaymentProcessor processor = new OldPaymentProcessor();

        processor.pay("Credit Card");

        processor.pay("PayPal");

        processor.pay("Cash");
    }

}

/*
 * =============================================================================
 * ==
 * PAYMENT PROCESSOR
 * =============================================================================
 * ==
 * 
 * Problem
 * -------
 * Every payment type is handled using if-else.
 * 
 * Whenever a new payment method is added:
 * 
 * Apple Pay
 * Google Pay
 * Visa
 * MasterCard
 * Crypto
 * 
 * We must come back and edit this class.
 * 
 * This violates OCP because existing code is constantly modified.
 * 
 * =============================================================================
 * ==
 */

class OldPaymentProcessor {

    public void pay(string paymentType) {

        if (string.Equals(paymentType, "Credit Card", StringComparison.OrdinalIgnoreCase)) {

            Console.WriteLine("\n========== PAYMENT ==========");
            Console.WriteLine("Processing Credit Card payment...");

        } else if (string.Equals(paymentType, "PayPal", StringComparison.OrdinalIgnoreCase)) {

            Console.WriteLine("\n========== PAYMENT ==========");
            Console.WriteLine("Processing PayPal payment...");

        } else if (string.Equals(paymentType, "Cash", StringComparison.OrdinalIgnoreCase)) {

            Console.WriteLine("\n========== PAYMENT ==========");
            Console.WriteLine("Processing Cash payment...");

        } else {

            Console.WriteLine("Unknown payment method.");

        }

    }

}

/*
 * =============================================================================
 * ==
 * WHY BAD?
 * =============================================================================
 * ==
 * 
 * Imagine the company adds:
 * 
 * ✔ Apple Pay
 * 
 * What should we do?
 * 
 * Go back to PaymentProcessor
 * ↓
 * Add another else-if
 * 
 * Tomorrow:
 * 
 * Google Pay
 * ↓
 * Modify again
 * 
 * Next month:
 * 
 * Crypto
 * ↓
 * Modify again
 * 
 * The class keeps changing forever.
 * 
 * Large if-else blocks become difficult to:
 * 
 * ✔ Read
 * ✔ Test
 * ✔ Maintain
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why does this code violate OCP?
 * 
 * Answer:
 * 
 * Because every new payment method requires modifying
 * the PaymentProcessor class instead of extending it.
 * 
 * =============================================================================
 * ==
 */
