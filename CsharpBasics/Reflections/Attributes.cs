using System.Diagnostics;
using System.Reflection;

namespace CsharpFundamentals.Reflections;

internal class Attributes
{
    public static void Run()
    {
        //AttributesBasics();
        CreatingCustomAttributes();
    }

    // ============================================================
    // Built-in Attributes
    // ============================================================

    public static void AttributesBasics()
    {
        Console.WriteLine("===================== Attributes Basics =====================");

        Update[] updates =
        {
            new Update(1, "First update"),
            new Update(2, "Second update"),
            new Update(3, "Third update")
        };

        // [Obsolete] marks a member as deprecated.
        // The compiler will show a warning when we use it.
        UpdateProcessor.Download(updates);
        UpdateProcessor.Install(updates);

        UpdateProcessor.DownloadAndInstall(updates);

        Console.WriteLine("==========================================");
        Console.WriteLine();
    }

    // ============================================================
    // Custom Attributes
    // ============================================================

    public static void CreatingCustomAttributes()
    {
        Console.WriteLine("===================== Creating Custom Attributes =====================");

        // Each skill has a valid range defined by SkillAttribute.
        var players = new List<Player>
        {
            new Player
            {
                Name = "Ahmed",
                Control = -17,
                Passing = 4,
                Power = 850,
                Speed = 92,
                Dribbling = 18
            },

            new Player
            {
                Name = "Mohamed",
                Control = 19,
                Passing = 159,
                Power = 780,
                Speed = 88,
                Dribbling = 20
            },

            new Player
            {
                Name = "Omar",
                Control = 78,
                Passing = 10,
                Power = 1200,
                Speed = 81,
                Dribbling = 16
            }
        };

        var errors = new List<ValidationError>();

        foreach (var player in players)
        {
            // Reflection allows us to inspect the player's properties.
            foreach (var property in player.GetType().GetProperties())
            {
                // Get the SkillAttribute applied to the property.
                var skillAttribute =
                    property.GetCustomAttribute<SkillAttribute>();

                if (skillAttribute is null)
                    continue;

                var value = property.GetValue(player);

                // Validate the property using its attribute.
                if (!skillAttribute.IsValid(value))
                {
                    errors.Add(
                        new ValidationError(
                            $"{player.Name}.{property.Name}",
                            $"Invalid value: {value}. " +
                            $"Valid range: {skillAttribute.Min} - {skillAttribute.Max}"
                        )
                    );
                }
            }
        }

        foreach (var error in errors)
        {
            Console.WriteLine(error);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine();
    }
}


// ================================================================
// Update Processor
// ================================================================

public class UpdateProcessor
{
    // [Obsolete] marks old code that should no longer be used.
    // true = compilation error
    // false = compiler warning
    [Obsolete(
        "This method is deprecated. Use DownloadAndInstall instead.",
        false)]
    public static void Download(Update[] updates)
    {
        foreach (var update in updates)
        {
            Console.WriteLine($"Downloading {update}");
            Thread.Sleep(750);
        }
    }

    [Obsolete(
        "This method is deprecated. Use DownloadAndInstall instead.",
        false)]
    public static void Install(Update[] updates)
    {
        foreach (var update in updates)
        {
            Console.WriteLine($"Installing {update}");
            Thread.Sleep(750);
        }
    }

    public static void DownloadAndInstall(Update[] updates)
    {
        foreach (var update in updates)
        {
            Console.WriteLine($"Downloading {update}");
            Thread.Sleep(750);

            Console.WriteLine($"Installing {update}");
            Thread.Sleep(750);
        }
    }
}


// ================================================================
// DebuggerDisplay Attribute
// ================================================================

// Controls how the object appears in the debugger.
// Without it, the debugger normally uses ToString().
[DebuggerDisplay("{Number} -> {Title}")]
public class Update
{
    private int Number { get; }
    private string Title { get; }

    public Update(int number, string title)
    {
        Number = number;
        Title = title;
    }

    public override string ToString()
    {
        return $"Update number: {Number} -> {Title}";
    }
}


// ================================================================
// Player
// ================================================================

public class Player
{
    public string Name { get; set; } = string.Empty;

    // The attribute stores the valid range for each skill.
    [Skill(1, 20)]
    public int Control { get; set; }

    [Skill(1, 4)]
    public int Passing { get; set; }

    [Skill(1, 1000)]
    public int Power { get; set; }

    [Skill(1, 100)]
    public int Speed { get; set; }

    [Skill(1, 20)]
    public int Dribbling { get; set; }
}


// ================================================================
// Custom Attribute
// ================================================================

// AttributeUsage defines where this attribute can be applied.
// Here it can only be applied to properties.
[AttributeUsage(AttributeTargets.Property)]
public class SkillAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public SkillAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    // Checks whether the value is inside the allowed range.
    public bool IsValid(object? value)
    {
        if (value is int number)
        {
            return number >= Min && number <= Max;
        }

        return false;
    }
}


// ================================================================
// Validation Error
// ================================================================

public class ValidationError
{
    public string PropertyName { get; }
    public string Message { get; }

    public ValidationError(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }

    public override string ToString()
    {
        return $"{PropertyName}: {Message}";
    }
}