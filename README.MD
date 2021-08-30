# How to work with

## How to install

        git clone X
        cd calculator_console
        dotnet build
        dotnet run

## How to use

1. The calculator has two states: "start" and "flow".
2. Start is a default state, with which model welcomes a user. It asks the user for two numbers (which may be positive or negative, integer or non-integer), and operation to perform.
3. There are five operations: + (addition), * (multiplication), - (subtraction), / (division), and C (erasure from memory). + returns sum, difference, * returns product, / returns fraction, C erases everything from memory.
4. Division by zero is impossible with this calculator.
5. After getting the first result, the user is asked, whether they want to continue, or not. 
6. If the user does not want to continue, the calculator halts.
7. If the user wants to continue ("Y"/"y"), and C operation was performed or division by zero happened, the calculator will not exit start state (steps from 2 will repeat).
8. If the user wants to continue ("Y"/"y"), and C operation was not performed, and division by zero did not happen, the calculator will enter "flow" state.
9. It prints the result, and asks the user for the following number and operation, that is performed on result and this next number. It is important to remember, that result will be the number that the second one is subtracted from, or the number that is divided by the second one, and not vice versa.
10. If operation C was performed, memory is cleared, and then the calculator enters the start state again.
11. If division by zero happened, the calculator re-enters the flow state with the result of previous calculation as the first number.
12. Otherwise, the user is asked, whether they want to continue.
13. If no, the calculator halts.
14. If yes, the calculator re-enters the flow state with the result of the current calculation as the first number.

# Architecture

1. The application consists of three classes: Program, Utils, and Calculator.
2. Program class contains entry point, method Main(), that takes no arguments, creates an instance of Calculator class, and calls its Run() method, until Run() returns false, which means that a user decided to stop using the program.
3. Utils is a static class that contains two static methods, DecimalParse (that takes string parameter, declaring, of which order the number parsed will be) that loops until the user enters a correct decimal value, and OperationParse, that takes no arguments, and loops until the user chooses a correct operation to perform over two numbers.
4. Calculator is a non-static class that contains the main logic of the program. 
5. Its fields are decimal? res (by default, null), reserved for the results of calculation, decimals first, second and string op, reserved for the parameters of calculation, loopCondition, depicting the possible state of the calculator (start (by default) or flow) from enum LoopCondition, and by-default null Calculator calculator, with which (and method getInstance() that checks for the existence of this value and returns or creates it) the singleness of calculator is ensured. 
6. Constructor of the Calculator is private (due to the realization of Singleton method) and contains only greeting message for the user. 
7. Method Start() is used to get two numbers and performs Operation on them, Flow() takes result of the previous calculation, adds one more number and performs Operation on these two. Method Operation, taking two decimals and string, returns value, depending on the string operation (addition for +, subtraction for -, multiplication for *, division for /, clearing for C). If division by zero was attempted, the first number is returned, if C operation is performed, null is returned. Run() switches between Start and Flow executions, depending on loopCondition and the results of the previous two, calculates the result, and asks the user, whether they want to continue. If the answer is positive, Run() returns true, and call from entry point is made again, if false, program halts. 