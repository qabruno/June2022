Feature: TMFeature

As a TunrUp portal admin
I would like to create, edit and delete time and material records
So that I can manage employees' time and material successfully


Scenario: create material record with valid details
	Given I logged into TurnUp portal successfully
	When I navigate to time and material page
	When I create a new material record
	Then the record should be created successfully


