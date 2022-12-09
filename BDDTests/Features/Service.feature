Feature: Service

A short summary of the feature

@tag1
Scenario: Administrator tries to log in with proper credentials
	Given I enter login and password
		| login | password |
		| test  | test     |
	When Check credentials is checked
	Then Admin is logged in

@tag2
Scenario: Administrator tries to register new administrator
	Given valid login and password
	When Register new Administrator is being activated
	Then Admin added new "Administrator"