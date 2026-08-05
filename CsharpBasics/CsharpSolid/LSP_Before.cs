/*
===============================================================================
            LISKOV SUBSTITUTION PRINCIPLE (LSP) - BEFORE
===============================================================================

Definition
----------
Objects of a subclass should be replaceable with objects
of the parent class without breaking the program.

Idea
----
If class B extends class A,
then B should behave like A.

A child class should never remove or change
the expected behavior of its parent.

In this example,
Bird defines a fly() method.

However, Penguin cannot fly.

This forces Penguin to implement behavior
that doesn't make sense.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class LSP_Before {

    public static void Run() {

        OldBird sparrow = new OldSparrow();

        OldBird penguin = new OldPenguin();

        makeBirdFly(sparrow);

        makeBirdFly(penguin);

    }

    static void makeBirdFly(OldBird bird) {

        Console.WriteLine("\nTrying to fly...");

        bird.fly();

    }

}

/*
 * =============================================================================
 * ==
 * BIRD
 * =============================================================================
 * ==
 * 
 * Every bird is expected to fly.
 * 
 * This assumption is WRONG because
 * not every bird can actually fly.
 * 
 * =============================================================================
 * ==
 */

class OldBird {

    public virtual void fly() {

        Console.WriteLine("Bird is flying.");

    }

}

/*
 * =============================================================================
 * ==
 * SPARROW
 * =============================================================================
 * ==
 * 
 * A Sparrow can fly.
 * 
 * No problem here.
 * 
 * =============================================================================
 * ==
 */

class OldSparrow : OldBird {

    public override void fly() {

        Console.WriteLine("Sparrow is flying.");

    }

}

/*
 * =============================================================================
 * ==
 * PENGUIN
 * =============================================================================
 * ==
 * 
 * Penguins cannot fly.
 * 
 * But because Penguin extends Bird,
 * it MUST implement fly().
 * 
 * Some developers do this:
 * 
 * - Throw Exception
 * - Print "Can't fly"
 * - Leave method empty
 * 
 * All are bad designs.
 * 
 * The child class is no longer behaving
 * like its parent.
 * 
 * This violates LSP.
 * 
 * =============================================================================
 * ==
 */

class OldPenguin : OldBird {

    public override void fly() {

        throw new NotSupportedException(
                "Penguins cannot fly.");

    }

}

/*
 * =============================================================================
 * ==
 * WHY BAD?
 * =============================================================================
 * ==
 * 
 * Our method expects:
 * 
 * Any Bird can fly.
 * 
 * But when Penguin is passed,
 * the application crashes.
 * 
 * Parent says:
 * 
 * Bird -> fly()
 * 
 * Child says:
 * 
 * "I can't."
 * 
 * That breaks substitution.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why does Penguin violate LSP?
 * 
 * Answer:
 * 
 * Because Penguin cannot replace Bird safely.
 * 
 * Any code expecting a Bird that can fly
 * will fail when Penguin is used.
 * 
 * =============================================================================
 * ==
 */
