Feature: Regisration
	In order to login to the website
	As a user 
	I want to be register successfully

@automate
Scenario: NewRegistration
	Given I have navigated to registration page and entered all valid credentials and click join
	Then the message confirmation is displayed on screen
