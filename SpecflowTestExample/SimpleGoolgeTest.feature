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
