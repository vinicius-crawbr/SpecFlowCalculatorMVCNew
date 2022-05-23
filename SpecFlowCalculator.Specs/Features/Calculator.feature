Feature: Calculator

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are subtract
	Then the result should be -20

Scenario: Multiply two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are multiply
	Then the result should be 3500

Scenario: Divide two numbers
	Given the first number is 12
	And the second number is 2
	When the two numbers are divide
	Then the result should be 6