/*
===============================================================================
         INTERFACE SEGREGATION PRINCIPLE (ISP) - BEFORE
===============================================================================

Definition
----------
Clients should not be forced to depend on methods
they do not use.

Idea
----
A class should only implement methods it actually needs.

In this example, we created one large interface
that contains every possible worker action.

This forces some classes to implement
methods that don't make sense.

This violates ISP.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class ISP_Before {

    public static void Run() {

        OldHumanWorker human = new OldHumanWorker();

        OldRobotWorker robot = new OldRobotWorker();

        Console.WriteLine("===== Human Worker =====");
        human.work();
        human.eat();
        human.sleep();

        Console.WriteLine("\n===== Robot Worker =====");
        robot.work();

        // These methods exist only because
        // the interface forced RobotWorker to implement them.
        robot.eat();
        robot.sleep();

    }

}

/*
 * =============================================================================
 * ==
 * WORKER INTERFACE
 * =============================================================================
 * ==
 * 
 * Problem
 * -------
 * This interface contains responsibilities
 * for every possible worker.
 * 
 * But not every worker:
 * 
 * ✔ Eats
 * ✔ Sleeps
 * 
 * Robot workers don't.
 * 
 * Still, they are forced to implement them.
 * 
 * =============================================================================
 * ==
 */

interface Worker {

    void work();

    void eat();

    void sleep();

}

/*
 * =============================================================================
 * ==
 * HUMAN WORKER
 * =============================================================================
 * ==
 * 
 * A human worker performs all operations.
 * 
 * No problem here.
 * 
 * =============================================================================
 * ==
 */

class OldHumanWorker : Worker {

    public void work() {

        Console.WriteLine("Human is working.");

    }

    public void eat() {

        Console.WriteLine("Human is eating lunch.");

    }

    public void sleep() {

        Console.WriteLine("Human is sleeping.");

    }

}

/*
 * =============================================================================
 * ==
 * ROBOT WORKER
 * =============================================================================
 * ==
 * 
 * Problem
 * -------
 * A robot can work.
 * 
 * But it cannot:
 * 
 * - Eat
 * - Sleep
 * 
 * However, because of the large interface,
 * it MUST implement these methods.
 * 
 * Most developers either:
 * 
 * - Leave them empty.
 * - Throw exceptions.
 * 
 * Both are signs of bad design.
 * 
 * =============================================================================
 * ==
 */

class OldRobotWorker : Worker {

    public void work() {

        Console.WriteLine("Robot is working.");

    }

    public void eat() {

        throw new NotSupportedException(
                "Robot does not eat.");

    }

    public void sleep() {

        throw new NotSupportedException(
                "Robot does not sleep.");

    }

}

/*
 * =============================================================================
 * ==
 * WHY BAD?
 * =============================================================================
 * ==
 * 
 * Worker Interface
 * 
 * ├── work()
 * ├── eat()
 * └── sleep()
 * 
 * Human
 * ✔ Works
 * ✔ Eats
 * ✔ Sleeps
 * 
 * Robot
 * ✔ Works
 * ❌ Eats
 * ❌ Sleeps
 * 
 * Robot is forced to implement methods
 * it never uses.
 * 
 * This is exactly what ISP tries to prevent.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why does this design violate ISP?
 * 
 * Answer:
 * 
 * Because RobotWorker depends on methods
 * that are meaningless for it.
 * 
 * Large interfaces should be divided into
 * smaller, focused interfaces.
 * 
 * =============================================================================
 * ==
 */