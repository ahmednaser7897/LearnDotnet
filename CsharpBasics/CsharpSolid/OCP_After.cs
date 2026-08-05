/*
===============================================================================
              OPEN / CLOSED PRINCIPLE (OCP) - AFTER
===============================================================================

Definition
----------
Software entities should be:

- Open for Extension.
- Closed for Modification.

Idea
----
Instead of modifying existing classes every time a new feature is needed,
we create new classes that extend the existing behavior.

In this example:

- PaymentProcessor doesn't know anything about payment types.
- Every payment method has its own class.
- Adding a new payment method requires creating a new class only.

Benefits
--------
✔ No huge if-else blocks.
✔ Easier maintenance.
✔ Easier testing.
✔ Easier to extend.
✔ Less chance of introducing bugs.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class OCP_After {

    public static void Run() {

        PaymentProcessor processor = new PaymentProcessor();

        // Create different payment methods
        PaymentMethod creditCard = new CreditCardPayment();
        PaymentMethod paypal = new PayPalPayment();
        PaymentMethod cash = new CashPayment();

        // Process payments
        processor.processPayment(creditCard);

        processor.processPayment(paypal);

        processor.processPayment(cash);

    }

}

/*
 * =============================================================================
 * ==
 * PAYMENT INTERFACE
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * This interface defines a common contract.
 * 
 * Every payment method MUST implement pay().
 * 
 * The PaymentProcessor only works with this interface.
 * 
 * It doesn't care if the payment is:
 * 
 * - Credit Card
 * - PayPal
 * - Cash
 * - Apple Pay
 * - Crypto
 * 
 * This makes the system flexible.
 * 
 * =============================================================================
 * ==
 */

interface PaymentMethod {

    void pay();

}

/*
 * =============================================================================
 * ==
 * CREDIT CARD PAYMENT
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Handle Credit Card payment only.
 * 
 * If Credit Card logic changes,
 * ONLY this class changes.
 * 
 * =============================================================================
 * ==
 */

class CreditCardPayment : PaymentMethod {

    public void pay() {

        Console.WriteLine("\n========== PAYMENT ==========");
        Console.WriteLine("Processing Credit Card payment...");
        Console.WriteLine("Payment completed.");

    }

}

/*
 * =============================================================================
 * ==
 * PAYPAL PAYMENT
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Handle PayPal payment only.
 * 
 * =============================================================================
 * ==
 */

class PayPalPayment : PaymentMethod {

    public void pay() {

        Console.WriteLine("\n========== PAYMENT ==========");
        Console.WriteLine("Processing PayPal payment...");
        Console.WriteLine("Payment completed.");

    }

}

/*
 * =============================================================================
 * ==
 * CASH PAYMENT
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Handle Cash payment only.
 * 
 * =============================================================================
 * ==
 */

class CashPayment : PaymentMethod {

    public void pay() {

        Console.WriteLine("\n========== PAYMENT ==========");
        Console.WriteLine("Processing Cash payment...");
        Console.WriteLine("Payment completed.");

    }

}

/*
 * =============================================================================
 * ==
 * PAYMENT PROCESSOR
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Execute any payment method.
 * 
 * Notice:
 * 
 * There is
 * 
 * ✔ No if
 * ✔ No else
 * ✔ No switch
 * 
 * The processor simply asks the object to pay().
 * 
 * This is called POLYMORPHISM.
 * 
 * No matter what object is passed,
 * the correct pay() method is executed.
 * 
 * =============================================================================
 * ==
 */

class PaymentProcessor {

    public void processPayment(PaymentMethod paymentMethod) {

        Console.WriteLine("Starting payment process...");

        paymentMethod.pay();

        Console.WriteLine("Payment process finished.");

    }

}

/*
 * =============================================================================
 * ==
 * HOW TO ADD A NEW PAYMENT?
 * =============================================================================
 * ==
 * 
 * Imagine the company wants to support Apple Pay.
 * 
 * Do we modify PaymentProcessor?
 * 
 * ❌ NO
 * 
 * Do we modify CreditCardPayment?
 * 
 * ❌ NO
 * 
 * Do we modify the interface?
 * 
 * ❌ NO
 * 
 * We ONLY create a new class:
 * 
 * -------------------------------------------------
 * 
 * class ApplePayPayment : PaymentMethod {
 * 
 * public void pay() {
 * 
 * Console.WriteLine("Processing Apple Pay...");
 * 
 * }
 * 
 * }
 * 
 * -------------------------------------------------
 * 
 * Now we can use it directly:
 * 
 * PaymentMethod apple = new ApplePayPayment();
 * 
 * processor.processPayment(apple);
 * 
 * No existing code changed.
 * 
 * This is exactly what OCP means.
 * 
 * =============================================================================
 * ==
 * SUMMARY
 * =============================================================================
 * ==
 * 
 * Before
 * ------
 * 
 * PaymentProcessor
 * 
 * ❌ if
 * ❌ else-if
 * ❌ else
 * ❌ Modify every new payment
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * After
 * -----
 * 
 * PaymentProcessor
 * 
 * ✔ No conditions
 * ✔ No modifications
 * ✔ Uses abstraction
 * ✔ Easy to extend
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * Interview Question
 * 
 * Q: Why does this code follow OCP?
 * 
 * Answer:
 * 
 * Because adding a new payment method does not require modifying
 * existing classes.
 * 
 * We simply create another class that implements PaymentMethod.
 * 
 * Existing code remains unchanged.
 * 
 * =============================================================================
 * ==
 */
