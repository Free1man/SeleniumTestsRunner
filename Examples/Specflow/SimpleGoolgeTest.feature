Feature: SimpleGoolgeTest


Scenario Outline: Google Search example test
	When I type <textToSearch> in the Search field
	Then I should see <results> on the webpage 

	Examples: 
	| textToSearch     | results                                            |
	| google translate | Google Translate on the App Store - iTunes - Apple |
	| testing          | Software testing - Wikipedia                       |


Scenario Outline: Google Translate example test
	When I type <textToSearch> in the Search field 
	And I click <textToClick> link 
	And I trying to translate <wordToTranslate>
	Then I should see <translationResults> on transaltion page
	Examples: 
	| textToSearch     | textToClick      | wordToTranslate | translationResults |
	| google translate | Google Translate | test            | test               |

