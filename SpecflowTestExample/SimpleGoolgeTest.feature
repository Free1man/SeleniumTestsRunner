Feature: SimpleGoolgeTest


Scenario Outline: Google Search example test
	When I type <textToSearch> to search text field 
	Then in text results i should see <results>

	Examples: 
	| textToSearch     | results                                                  |
	| google translate | Google Translate                                         |
	| test             | Speedtest.net by Ookla - The Global Broadband Speed Test |
	| testing          | Software testing - Wikipedia, the free encyclopedia1      |
