Feature: ProfileLanguage
	In order update Profile information
	As a user
	I want to be update Language 

	@automate
Scenario: Edit or Update Language
    Given I Edit or update Language on profile page
	Then  I should be able to view the updated Language
	


	