Feature:SearchSkills
	User should be able to search skills by categories and by filters

@automate
Scenario: Search Skills by Categories and by SubCategories
	Given I have navigated to searchskills page and click on category and suncategory 
	When I click category and subcategory
	Then The search results should be displayed by category and subcategory

@automate
Scenario: Search Skills by filters Online
	Given I click search icon on Profile Page
	And I input search skills
	When I choose Filter by Online
	Then The search results should be filtered by Online