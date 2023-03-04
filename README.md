# C# Scientific Calculator

This project is a C# scientific calculator that uses the Shunting Yard Algorithm to parse and evaluate mathematical expressions. The calculator supports the following operations and functions:

- Parentheses
- Addition
- Subtraction
- Multiplication
- Division
- Exponentiation
- Unary operations (for negative numbers)
- The sin function
- The cos function
- The tan function
- The pi constant

## Usage

To use the scientific calculator, you can create a new instance of the `ShuntingYardAlgorithm` class and call its `Evaluate` method with a string containing a mathematical expression. For example:

```csharp
double result = ShuntingYardAlgorithm.Evaluate("2 + 3 * 4");
Console.WriteLine(result); // Output: 14
```

If the input expression is invalid or contains errors, the Evaluate method throws an exception. You can catch the exception and handle the error as appropriate. For example:

```csharp
try
{
    double result = ShuntingYardAlgorithm.Evaluate("2 + * 3");
    Console.WriteLine(result);
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e.Message);
}
```

## Installation
To use the scientific calculator in your C# project, you can add the ShuntingYardAlgorithm.cs file to your project and include it in your code. Alternatively, you can compile the ShuntingYardAlgorithm.cs file into a separate DLL and reference it in your project.

## Testing
This project includes a test project ScientificCalculatorTests that contains unit tests for the ShuntingYardAlgorithm class. You can run the tests using a testing framework such as MSTest or NUnit. For example, to run the tests using MSTest, you can use the following command:

```bash
dotnet test ScientificCalculatorTests
```

## Contributing
Contributions to this project are welcome! If you find a bug, have a suggestion, or want to add a new feature, please open an issue or submit a pull request. Before submitting a pull request, please make sure that all tests pass and that the code follows the project's coding conventions.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
