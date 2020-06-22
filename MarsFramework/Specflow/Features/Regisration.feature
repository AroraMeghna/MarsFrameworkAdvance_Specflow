Feature: Regisration
	In order to login to the website
	As a user 
	I want to be register successfully

@automate
Scenario: Registration( successful)
	Given I have navigated to registration page and entered all valid credentials
	When I click on Join button
	Then the message confirmation is displayed on screen
