Feature: Bunch of smoke tests, see each scenario name for details
		
Background: Log in
	Given I login as galperin.job@gmail.com with password Test1357900

Scenario: Verify that user can upload avatar (file upload)
	When I upload new avatar
	#Then I verify that avatar is updated

Scenario: Verify that user can log out
	When I click text galperin.job@gmail.com
	And I click text Log out
	Then I should see text Sign up to save your list and recipes!

Scenario: Verify that user can open Recipes page
	When I click text Recipes
	Then I should see text Save recipes from anywhere to your personal recipe box!

