/*
===============================================================================
            LISKOV SUBSTITUTION PRINCIPLE (LSP) - AFTER
===============================================================================

Definition
----------
Objects of a subclass should be replaceable with objects
of the parent class without changing the correctness of the program.

Idea
----
The problem wasn't Penguin.

The problem was our design.

We assumed that every Bird can fly,
which is not true.

The solution is to separate birds into:

1- Bird         -> Common behavior.
2- FlyingBird   -> Birds that can fly.

Now only birds that actually fly inherit fly().

Benefits
--------
✔ Correct inheritance.
✔ No fake implementations.
✔ No runtime exceptions.
✔ Easy to extend.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class LSP_After {

    public static void Run() {

        FlyingBird sparrow = new Sparrow();

        Bird penguin = new Penguin();

        makeBirdFly(sparrow);

        penguin.eat();

    }

    /*
     * This method accepts ONLY birds that can fly.
     * 
     * We no longer assume every Bird can fly.
     */

    static void makeBirdFly(FlyingBird bird) {

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
 * Responsibility
 * --------------
 * Contains behavior shared by ALL birds.
 * 
 * Every bird can eat.
 * 
 * But NOT every bird can fly.
 * 
 * Notice that fly() no longer exists here.
 * 
 * =============================================================================
 * ==
 */

class Bird {

    public virtual void eat() {

        Console.WriteLine("Bird is eating.");

    }

}

/*
 * =============================================================================
 * ==
 * FLYING BIRD
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Represents only birds that are capable of flying.
 * 
 * Any class extending FlyingBird
 * must be able to fly.
 * 
 * =============================================================================
 * ==
 */

class FlyingBird : Bird {

    public virtual void fly() {

        Console.WriteLine("Flying...");

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
 * So it extends FlyingBird.
 * 
 * This is a valid substitution.
 * 
 * =============================================================================
 * ==
 */

class Sparrow : FlyingBird {

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
 * A Penguin cannot fly.
 * 
 * So it extends Bird directly.
 * 
 * No need to override fly().
 * 
 * No fake implementation.
 * 
 * No exceptions.
 * 
 * This is the correct design.
 * 
 * =============================================================================
 * ==
 */

class Penguin : Bird {

    public override void eat() {

        Console.WriteLine("Penguin is eating fish.");

    }

}

/*
 * =============================================================================
 * ==
 * WHY IS THIS BETTER?
 * =============================================================================
 * ==
 * 
 * Old Design
 * 
 * Bird
 * ├── Sparrow ✔
 * └── Penguin ❌
 * 
 * Problem:
 * 
 * Bird promised that every bird can fly.
 * 
 * Penguin broke that promise.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * New Design
 * 
 * Bird
 * ├── FlyingBird
 * │ └── Sparrow
 * │
 * └── Penguin
 * 
 * Now:
 * 
 * ✔ Sparrow can replace FlyingBird.
 * 
 * ✔ Penguin can replace Bird.
 * 
 * No broken behavior.
 * 
 * No runtime exceptions.
 * 
 * =============================================================================
 * ==
 * 
 * Real Life Example
 * 
 * Vehicle
 * |
 * |---- Car
 * |
 * |---- Bicycle
 * 
 * Imagine Vehicle has:
 * 
 * startEngine()
 * 
 * Bicycle doesn't have an engine.
 * 
 * Wrong design.
 * 
 * Better:
 * 
 * Vehicle
 * 
 * MotorVehicle extends Vehicle
 * 
 * Car extends MotorVehicle
 * 
 * Bike extends Vehicle
 * 
 * Same idea as Bird/FlyingBird.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why is this design following LSP?
 * 
 * Answer:
 * 
 * Because every subclass fulfills the behavior
 * promised by its parent.
 * 
 * FlyingBird objects can always fly.
 * 
 * Bird objects are not forced to fly.
 * 
 * No subclass breaks the parent's contract.
 * 
 * =============================================================================
 * ==
 */
