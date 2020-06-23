Feature: SignIn
	In order to login to the website
	As a user
	I want to SignIn successfully with valid credentials


@automate
Scenario: Sign In with Valid Credential
	Given I have entered valid credentials on SignIn page
	Then  I should be able to login to the application

@auto
Scenario: Sign In with Invalid Credential
	Given I have entered invalid credentials on SignIn page
	Then  I should not be able to login to the application
