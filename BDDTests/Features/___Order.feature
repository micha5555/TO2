Feature: Service

A short summary of the feature

@tag1
Scenario: Updating order
	Given valid order
	And Being logged in Admin
	When Admin updating order
	Then Order is updated

@tag2
Scenario: Getting all orders
	Given Being logged in Admin
	When Admin getting all orders
	Then Admin have access to all orders