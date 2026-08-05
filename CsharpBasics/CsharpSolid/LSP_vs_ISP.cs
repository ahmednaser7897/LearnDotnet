/*
===============================================================================
                    LSP vs ISP (Real World Example)
===============================================================================

Scenario
--------

A company has different employees.

- Developer
- Manager
- Intern

We will compare LSP and ISP using this scenario.

===============================================================================
*/
namespace CsharpFundamentals.Solid;

public class LSP_vs_ISP {

    public static void Run() {

        Console.WriteLine("========== LSP ==========");

        FullTimeEmployee developer = new Developer();

        developer.work();

        developer.getSalary();

        Console.WriteLine("\n========== ISP ==========");

        Developer developer2 = new Developer();

        developer2.work();
        // developer2.writeCode();

        Manager manager = new Manager();

        manager.work();
        // manager.manageTeam();

    }

}

/*
 * =============================================================================
 * ==
 * LSP
 * =============================================================================
 * ==
 * 
 * Imagine every FullTimeEmployee
 * 
 * - works
 * - receives salary
 * 
 * Every child must respect this behavior.
 * 
 * =============================================================================
 * ==
 */

class FullTimeEmployee {

    public virtual void work() {

        Console.WriteLine("Employee is working.");

    }

    public virtual void getSalary() {

        Console.WriteLine("Monthly salary received.");

    }

}

class Developer : FullTimeEmployee {

    public override void work() {

        Console.WriteLine("Developer is writing code.");

    }

}

class Manager : FullTimeEmployee {

    public override void work() {

        Console.WriteLine("Manager is managing the team.");

    }

}

/*
 * Imagine we create:
 * 
 * class Volunteer : FullTimeEmployee
 * 
 * and then:
 * 
 * public override void getSalary(){
 * 
 * throw new NotSupportedException();
 * 
 * }
 * 
 * Now Volunteer cannot replace FullTimeEmployee.
 * 
 * This violates LSP.
 * 
 * The problem is inheritance.
 * 
 * =============================================================================
 * ==
 */

/*
 * =============================================================================
 * ==
 * ISP
 * =============================================================================
 * ==
 * 
 * Now suppose the company creates ONE interface.
 * 
 * =============================================================================
 * ==
 */

interface Employee {

    void work();

    void writeCode();

    void manageTeam();

}

/*
 * Developer writes code.
 * 
 * Manager manages the team.
 * 
 * But because of one huge interface,
 * both classes must implement everything.
 * 
 * This violates ISP.
 * 
 * =============================================================================
 * ==
 */

class Developer2 : Employee {

    public void work() {

        Console.WriteLine("Developer working.");

    }

    public void writeCode() {

        Console.WriteLine("Writing C# Code.");

    }

    public void manageTeam() {

        // meaningless
        throw new NotSupportedException();

    }

}

class Manager2 : Employee {

    public void work() {

        Console.WriteLine("Manager working.");

    }

    public void writeCode() {

        // meaningless
        throw new NotSupportedException();

    }

    public void manageTeam() {

        Console.WriteLine("Managing Team.");

    }

}

/*
 * Correct ISP Design
 * 
 * interface Workable
 * 
 * interface Coder
 * 
 * interface Leader
 * 
 * Developer : Workable, Coder
 * 
 * Manager : Workable, Leader
 * 
 * Nobody implements unnecessary methods.
 * 
 * =============================================================================
 * ==
 * 
 * FINAL DIFFERENCE
 * 
 * LSP
 * 
 * Problem
 * -------
 * 
 * Wrong inheritance.
 * 
 * Child cannot safely replace parent.
 * 
 * Example
 * 
 * Volunteer : FullTimeEmployee
 * 
 * but cannot receive salary.
 * 
 * Wrong.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * ISP
 * 
 * Problem
 * -------
 * 
 * Wrong interface design.
 * 
 * Developer forced to manage team.
 * 
 * Manager forced to write code.
 * 
 * Wrong.
 * 
 * -----------------------------------------------------------------------------
 * --
 * 
 * Easy Rule
 * 
 * LSP
 * 
 * "Is inheritance correct?"
 * 
 * ISP
 * 
 * "Is the interface too big?"
 * 
 * =============================================================================
 * ==
 */
