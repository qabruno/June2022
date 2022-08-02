Feature: TMFeature

As a TunrUp portal admin
I would like to create, edit and delete time and material records
So that I can manage employees' time and material successfully

@myTag
Scenario: create material record with valid details
	Given I logged into TurnUp portal successfully
	When I navigate to time and material page
	When I create a new material record
	Then the record should be created successfully

@yourTag
Scenario Outline: edit existing material record with valid details
	Given I logged into TurnUp portal successfully
	When I navigate to time and material page
	When I update '<Code>', '<Description>' and '<Price>' of an existing material record
	Then the record should have the '<Code>', '<Description>' and '<Price>' updated

	Examples: 
	| Code     | Description | Price     |
	| Keyboard | White       | $160.00   |
	| Bottle   | Green       | $1,555.00 |
	| Pen      | Blue        | $10.00    |

