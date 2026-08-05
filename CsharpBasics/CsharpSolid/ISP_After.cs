/*
===============================================================================
         INTERFACE SEGREGATION PRINCIPLE (ISP) - AFTER
===============================================================================

Definition
----------
Clients should not be forced to depend on methods
they do not use.

Idea
----
Instead of creating one large interface,
we divide it into small, focused interfaces.

Each class implements only what it actually needs.

Benefits
--------
✔ Cleaner code.
✔ No unnecessary methods.
✔ Easier maintenance.
✔ Better flexibility.
✔ Easier testing.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class ISP_After {

    public static void Run() {

        HumanWorker human = new HumanWorker();

        RobotWorker robot = new RobotWorker();

        Console.WriteLine("===== Human Worker =====");

        human.work();
        human.eat();
        human.sleep();

        Console.WriteLine("\n===== Robot Worker =====");

        robot.work();

        /*
         * Notice:
         * 
         * Robot cannot call eat() or sleep()
         * because those methods don't exist
         * in RobotWorker anymore.
         * 
         * This is exactly what ISP wants.
         */

    }

}

/*
 * =============================================================================
 * ==
 * WORKABLE
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Contains only work behavior.
 * 
 * Any class capable of working
 * implements this interface.
 * 
 * =============================================================================
 * ==
 */

interface Workable {

    void work();

}

/*
 * =============================================================================
 * ==
 * EATABLE
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Contains eating behavior only.
 * 
 * Only living workers need this interface.
 * 
 * =============================================================================
 * ==
 */

interface Eatable {

    void eat();

}

/*
 * =============================================================================
 * ==
 * SLEEPABLE
 * =============================================================================
 * ==
 * 
 * Responsibility
 * --------------
 * Contains sleeping behavior only.
 * 
 * Only classes that actually sleep
 * should implement it.
 * 
 * =============================================================================
 * ==
 */

interface Sleepable {

    void sleep();

}

/*
 * =============================================================================
 * ==
 * HUMAN WORKER
 * =============================================================================
 * ==
 * 
 * A human can:
 * 
 * ✔ Work
 * ✔ Eat
 * ✔ Sleep
 * 
 * Therefore it implements all interfaces.
 * 
 * =============================================================================
 * ==
 */

class HumanWorker : Workable, Eatable, Sleepable {

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
 * A robot can only work.
 * 
 * It doesn't eat.
 * 
 * It doesn't sleep.
 * 
 * So it implements ONLY Workable.
 * 
 * Notice:
 * 
 * No empty methods.
 * 
 * No exceptions.
 * 
 * No fake implementations.
 * 
 * =============================================================================
 * ==
 */

class RobotWorker : Workable {

    public void work() {

        Console.WriteLine("Robot is working.");

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
 * Worker
 * 
 * ├── work()
 * ├── eat()
 * └── sleep()
 * 
 * Human
 * ✔ Work
 * ✔ Eat
 * ✔ Sleep
 * 
 * Robot
 * ✔ Work
 * ❌ Eat
 * ❌ Sleep
 * 
 * Robot was forced to implement
 * methods it never needed.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * After
 * 
 * Workable
 * |
 * |---- HumanWorker
 * |
 * |---- RobotWorker
 * 
 * Eatable
 * |
 * |---- HumanWorker
 * 
 * Sleepable
 * |
 * |---- HumanWorker
 * 
 * Each class depends only
 * on the behavior it actually needs.
 * 
 * This follows ISP perfectly.
 * 
 * =============================================================================
 * ==
 * 
 * Real Life Example
 * 
 * Imagine a company has one interface:
 * 
 * Employee
 * 
 * - work()
 * - driveTruck()
 * - manageTeam()
 * - cookFood()
 * 
 * Should every employee implement all of them?
 * 
 * Of course not.
 * 
 * Instead, create:
 * 
 * Workable
 * Driver
 * Manager
 * Cook
 * 
 * Each employee implements only
 * the required abilities.
 * 
 * Exactly the same idea.
 * 
 * =============================================================================
 * ==
 * 
 * Interview Question
 * 
 * Q:
 * Why is this design better?
 * 
 * Answer:
 * 
 * Because each class depends only on
 * the methods it actually uses.
 * 
 * No unnecessary implementations.
 * 
 * No empty methods.
 * 
 * No runtime exceptions.
 * 
 * This follows the Interface Segregation Principle.
 * 
 * =============================================================================
 * ==
 */