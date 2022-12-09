Feature: Service

A short summary of the feature

@tag1
Scenario: Client tries to log in with proper credentials
	Given I enter login and password
		| login | password |
		| test  | test     |
	When Check credentials is checked
	Then Client is logged in

@tag2
Scenario: User tries to register new client
	Given valid login and password
	When Register new Client is being activated
	Then User added new "Client"

@tag3
Scenario: Client tries to update address
	Given valid clientID and address and postalCode
	When User updates address
	Then User address is updated

@tag4
Scenario: User tries to add new order
	Given valid order
	When User adding new order
	Then New order is added

