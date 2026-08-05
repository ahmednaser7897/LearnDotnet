# C# Object-Oriented Programming Reference

This folder is a practical, commented reference for object-oriented programming in modern C#.
It follows the same learning style as `CsharpBasics`: every topic has a `Run()` method, and
`OopProgram.Run()` executes the complete reference in a logical order.

## How to use this folder

1. Copy `CsharpOop` beside the existing `CsharpBasics` folder.
2. Make sure the project uses C# 14 / .NET 10 for every example, especially `field`-backed
   properties and extension blocks.
3. Call `CsharpFundamentals.CsharpOop.OopProgram.Run()` from the application entry point.
4. Study one file at a time. Read the comments, predict the output, then run the example.

## Learning order

| File | Main concepts |
| --- | --- |
| `ClassesAndObjects.cs` | Classes, objects, members, access modifiers, static members, nested and partial classes |
| `AccessModifiersAndMembers.cs` | Accessibility, fields, constants, properties, indexers, static and instance members |
| `ConstructorsAndInitialization.cs` | Constructors, chaining, primary constructors, object initializers, `required`, `init` |
| `Encapsulation.cs` | Private state, properties, validation, readonly state, invariants |
| `Inheritance.cs` | Base and derived types, `base`, `protected`, virtual members, `sealed`, member hiding |
| `Polymorphism.cs` | Runtime polymorphism, overloads, operators, substitutability |
| `Abstraction.cs` | Abstract classes and template methods |
| `Interfaces.cs` | Contracts, multiple interfaces, explicit implementation, default and static abstract members |
| `ObjectRelationships.cs` | Association, aggregation, composition, dependency, composition over inheritance |
| `ObjectMethodsAndEquality.cs` | `object`, `ToString`, equality, hash codes, identity versus value |
| `CopySemantics.cs` | Reference assignment, shallow copies, deep copies, copy constructors |
| `RecordsAndImmutability.cs` | Records, record structs, value equality, `with`, deconstruction, immutable models |
| `GenericsAndConstraints.cs` | Generic classes and methods, constraints, covariance, contravariance |
| `DelegatesEventsAndCallbacks.cs` | Delegates, events, callbacks, Observer and Strategy |
| `ObjectLifetimeAndDisposal.cs` | Garbage collection basics, `IDisposable`, `IAsyncDisposable`, finalizers |
| `PatternMatchingAndTypeChecks.cs` | `is`, `as`, switch expressions, property and list patterns |
| `ModernCsharpOop.cs` | Modern syntax: primary constructors, `field`, extension members, collection expressions |
| `SolidPrinciples.cs` | SRP, OCP, LSP, ISP, DIP with practical code |
| `MiniProject.cs` | A small order-processing model combining the major concepts |

## The four pillars

- Encapsulation protects valid object state behind a controlled public API.
- Inheritance creates a specialized type from a suitable base abstraction.
- Polymorphism lets the same contract select different behavior at runtime or compile time.
- Abstraction exposes essential behavior while hiding implementation details.

## Important design guidance

- Prefer behavior-rich objects over public data bags when modeling a domain.
- Keep every object valid after construction; reject invalid state early.
- Program against abstractions at boundaries, but do not create an interface for every class.
- Prefer composition when there is no genuine and stable "is-a" relationship.
- Keep inheritance hierarchies shallow and verify the Liskov Substitution Principle.
- Use records for value-oriented data and classes for identity-oriented domain entities.
- Make invalid operations impossible or explicit through methods and types.
- Use dependency injection to supply collaborators; avoid hidden global dependencies.
- Override `Equals` and `GetHashCode` together, and avoid mutable equality keys.
- Dispose owned resources deterministically with `using` or `await using`.

## Practice checklist

- Add another `Shape` without changing the area calculator.
- Add a new payment method to the mini-project through `IPaymentMethod`.
- Create an immutable value object and implement equality correctly.
- Replace an inheritance relationship with composition and compare the designs.
- Write a fake repository and unit-test `CheckoutService` without a database.

## Official references

- Object-oriented programming: <https://learn.microsoft.com/dotnet/csharp/fundamentals/tutorials/oop>
- Classes and objects: <https://learn.microsoft.com/dotnet/csharp/fundamentals/types/classes>
- Interfaces: <https://learn.microsoft.com/dotnet/csharp/fundamentals/types/interfaces>
- Records: <https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record>
- C# 14 features: <https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14>
