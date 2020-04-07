Feature: Example for Whisk

Background: Delete all lists before start
	Given I login as galperin.job@gmail.com with password Test1357900
	And I delete all lists except default

Scenario: Create list with one item	
	When I create list with next name Test123
	And I add next items to exiting Test123 list 
	| itemName |
	| Milk     |
	Then there is 1 item(s) in the list


Scenario: Create list with few items	
	When I create list with next name Test123
	And I add next items to exiting Test123 list 
	| itemName |
	| Milk     |
	| Bread    |
	| Egg      |
	Then there is 3 item(s) in the list






