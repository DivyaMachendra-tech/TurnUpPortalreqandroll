Feature: TMFeature

As a TurnUp Portsl admin user 
I would like to create,edit and delete Time and Material records
so that I can manage the employee time and material successfully
#
#Background: 
#    Given I logged into Turnup portal successfully
#	And I navigate to the Time and Material Page
#

@regression @bvt @timeandmaterial
Scenario: Create new time and material record with valid data
    Given I logged into Turnup portal successfully
	And I navigate to the Time and Material Page
    When I create a new Time and Material record
	Then the record should be created successfully

Scenario Outline: Edit existing time record with valid data
    Given I logged into Turnup portal successfully
	And I navigate to the Time and Material Page
    When I update the '<code>' and '<description>' on the existing time record.
	Then  the record have the updated '<code>' and '<description>'

Examples: 
| code             | description |
| Industry Connect | Laptop     |
| TA Job Ready     | Keyboard   |
| Divya            | Mouse      |
