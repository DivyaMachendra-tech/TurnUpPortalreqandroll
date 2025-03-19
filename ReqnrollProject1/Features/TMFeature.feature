Feature: Feature1

As a TurnUp Portsl admin user 
I would like to create,edit and delete Time and Material records
so that I can manage the employee time and material successfully

@regression @bvt @timeandmaterial
Scenario: Create new time and material record with valid data
	Given I logged into Turnup portal successfully
	And I navigate to the Time and Material Page
	When I create a new Time and Material record
	Then the record should be created successfully
