# Design Document for Scientific Calculator

## Introduction
The Scientific Calculator is a software application that allows users to perform mathematical calculations with a variety of functions and operations. The purpose of this document is to provide a high-level overview of the design of the calculator and to describe the key features and functionalities of the application.

## Design Overview
The Scientific Calculator is designed as a modular and extensible application that can be easily customized and enhanced with new features and functions. The calculator is built on top of the Shunting Yard Algorithm, which is a widely used method for parsing and evaluating mathematical expressions.

The calculator is divided into three main modules:

- User Interface: The user interface module provides a graphical interface for users to input and view mathematical expressions and results. The user interface is built using Windows Forms and includes a variety of controls such as buttons, text boxes, and menus.

- Shunting Yard Algorithm: The Shunting Yard Algorithm module provides the core functionality of the calculator, including parsing and evaluating mathematical expressions. This module is implemented as a C# class called ShuntingYardAlgorithm, which can be easily integrated into other applications.

- Math Functions: The Math Functions module provides a collection of built-in mathematical functions that users can use in their calculations. These functions include basic operations such as addition, subtraction, multiplication, and division, as well as more advanced functions such as sine, cosine, tangent, and exponentiation.

## User Interface
The user interface of the Scientific Calculator is designed to be intuitive and user-friendly, with a variety of features and options to customize the calculator's behavior and appearance. The user interface includes the following key elements:

- Input Box: The input box is where users can enter their mathematical expressions using a keyboard or mouse.

- Output Box: The output box is where the results of calculations are displayed.

- Buttons: The calculator includes a variety of buttons that users can use to input numbers, operations, and functions. Buttons are grouped into categories such as basic operations, advanced functions, and constants.

Menus: The calculator includes a variety of menus that users can use to customize the calculator's behavior and appearance. Menus include options such as font size, theme, and scientific notation.

## Shunting Yard Algorithm
The Shunting Yard Algorithm module is the heart of the Scientific Calculator, providing the core functionality for parsing and evaluating mathematical expressions. The module is implemented as a C# class called ShuntingYardAlgorithm, which includes the following key methods:

- Parse: The Parse method takes a string containing a mathematical expression and converts it into a series of tokens that can be processed by the algorithm.

- Evaluate: The Evaluate method takes a series of tokens and uses the Shunting Yard Algorithm to evaluate the mathematical expression and return the result.

## Math Functions
The Math Functions module provides a collection of built-in mathematical functions that users can use in their calculations. The functions are implemented as C# methods that can be easily extended or customized to add new functions. The module includes the following functions:

- Basic Operations: Addition, subtraction, multiplication, and division.

- Advanced Functions: Sine, cosine, tangent, logarithm, and exponentiation.

- Constants: Pi and e.

## Conclusion
The Scientific Calculator is a powerful and flexible application that provides users with a wide range of mathematical functions and operations. The modular design of the calculator makes it easy to customize and extend with new features and functions, while the user-friendly interface makes it easy for users to perform complex calculations with ease.
