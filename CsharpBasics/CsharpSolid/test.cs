/*

In this file you can find violation of Single Responsibility Principle.
You should refactor this file.
You can remove this file completely, because it will not be used during the evaluation of the solution.

*/
namespace CsharpFundamentals.Solid;

class UserDataManager {

    public static void Run() {
        UserClass user = new UserClass("john_doe", "Password123");
        LoginClass loginClass = new LoginClass(user, new UserNameValidator(), new PasswordNameValidator());
        RegisterClass registerClass = new RegisterClass(user, new UserNameValidator(), new PasswordNameValidator());
        loginClass.loginUser();
        registerClass.registerUser();
    }
}

class UserClass {
    internal string username;
    internal string password;

    public UserClass(string username, string password) {
        this.username = username;
        this.password = password;
    }
}

interface Validator {
    bool validate(string value);
}

class UserNameValidator : Validator {

    public bool validate(string value) {
        // Validate username (e.g., length, characters allowed)
        return value.Length >= 5 && System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z_0-9]+$");
    }
}

class PasswordNameValidator : Validator {

    public bool validate(string value) {
        // Validate username (e.g., length, characters allowed)
        return value.Length >= 8 && System.Text.RegularExpressions.Regex.IsMatch(
            value,
            "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$");
    }
}

class LoginClass {
    UserClass user;
    Validator userNameValidator;
    Validator passwordValidator;

    internal LoginClass(UserClass user, Validator userNameValidator, Validator passwordValidator) {
        this.user = user;
        this.userNameValidator = userNameValidator;
        this.passwordValidator = passwordValidator;
    }

    public void loginUser() {
        // Validate username and password
        if (userNameValidator.validate(user.username) && passwordValidator.validate(user.password)) {
            // Authenticate user
            Console.WriteLine("User logged in successfully.");
        } else {
            Console.WriteLine("Invalid username or password.");
        }
    }
}

class RegisterClass {
    UserClass user;
    Validator userNameValidator;
    Validator passwordValidator;

    internal RegisterClass(UserClass user, Validator userNameValidator, Validator passwordValidator) {
        this.user = user;
        this.userNameValidator = userNameValidator;
        this.passwordValidator = passwordValidator;
    }

    public void registerUser() {
        // Validate username and password
        if (userNameValidator.validate(user.username) && passwordValidator.validate(user.password)) {
            // Register user in the database
            Console.WriteLine("User registered successfully.");
        } else {
            Console.WriteLine("Invalid username or password.");
        }
    }
}
