Feature: SimpleGoolgeTest


Scenario Outline: Google Search example test
	When I type <textToSearch> in the Search field 
	Then I should see <results> on the webpage 

	# first test will fail - for demo
	Examples: 
	| textToSearch     | results                                                  |
	| google translate | Google Translate1                                        |
	| test             | Speedtest.net by Ookla - The Global Broadband Speed Test |
	| testing          | Software testing - Wikipedia, the free encyclopedia      |


Scenario Outline: Google Translate example test
	When I type <textToSearch> in the Search field 
	And I click <linkToclick> link 
	And I trying to translate <wordToTranslate>
	Then I should see <translationResults> on transaltion page
	Examples: 
	| textToSearch     | linkToclick      | wordToTranslate | translationResults |
	| google translate | Google Translate | test            | test               |

