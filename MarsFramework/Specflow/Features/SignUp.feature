Feature: Registration
	In Order to login to the website,
	as a user, I want to register successfully

@automate
Scenario: Successful SignUp
Given I have navigated to registration page and entered all valid credentials 
When I clickon Join
Then the I get message " User has joined successfully"

@automate
	Scenario: UnSuccessful SignUp
	Given I have entered  invalid credentials 

	When I clickon Signup
	Then the I get error message message " "

