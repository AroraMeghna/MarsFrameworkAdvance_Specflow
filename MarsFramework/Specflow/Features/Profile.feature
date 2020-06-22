Feature: Profile
	In order to update Profile
	As a user
	I should be able to update data on Pofile  page

	@automate
Scenario: Select Availability
    Given I have navigated to profile page  and I clicked on Availability
	When  I select  Availability
	Then I should be able to select availability time 

@automate
Scenario: Edit Availability
    Given I have navigated to profile page and clicked on Availability
	When I Edit Availability time
	Then the updated availability time is displayed on profile page

	
@automate
Scenario: Edit Hours
    Given I have navigated to profile page and clicked on Edit Hours
	When I Select the Hours
	Then I should be able to select the Hours

	@automate
Scenario: Select Earn Target
    Given I have navigated to profile page and clicked on Earn Target
	When I Select Earn target
	Then I should be able to select Earn target successfully

	@automate
Scenario: Edit Earn Target
    Given I have navigated to profile page and clicked on Earn Target
	When I click on Edit Earn Target
	Then I should be able to Edit earn target successfully

	@automate
Scenario: Add Language
    Given I have clicked on Add language in the Language tab on profile page
	When I enter language and select language level and click on add new button
	Then I should be able to add new language and view added language on profile page

	@automate
Scenario: Edit Language
    Given I have clicked on Edit button  in the Language tab on profile page
	When I Edit the language and click on update button
	Then I should be able to view the updated Language on profile page


	@automate
	Scenario: Delete Language
    Given I have clicked on  the Language tab on profile page
	When I click on Delete button
	Then I should be able to delete the language and the message " Language deleted" is displayed on screen


	@automate
	Scenario: Add Description
    Given I have clicked on  the Language tab on profile page
	When I click on Delete button
	Then I should be able to delete the language and the message " Language deleted" is displayed on screen


	@automate
	Scenario: Edit Description
    Given I have clicked on  the Language tab on profile page
	When I click on Delete button
	Then I should be able to delete the language and the message " Language deleted" is displayed on screen