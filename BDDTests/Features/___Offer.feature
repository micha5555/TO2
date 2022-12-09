Feature: Service

A short summary of the feature

@tag1
Scenario: Adding product to offer
	Given valid product
	And Being logged in Admin
	When Admin adding product
	Then Product is added to offer

@tag2
Scenario: Removing product from offer
	Given valid product
	And Being logged in Admin
	When Admin deleting product
	Then Product is deleted from offer

@tag3
Scenario: Getting all products from offer
	Given Being logged in User or Admin
	When User getting all products
	Then User have have access to list of all products

@tag4
Scenario: Getting active products from offer
	Given Being logged in Admin
	When Admin getting active products
	Then Admin have have access to list of active products

@tag5
Scenario: Searching for all products by name
	Given Being logged in User or Admin
	When Admin getting all products filtered by name
	Then Admin have have access to list of products filtered by name

@tag6
Scenario: Searching for active products by name
	Given Being logged in Admin
	When Admin getting all active products filtered by name
	Then Admin have access to list of active products filtered by name

@tag6
Scenario: Activating product
	Given valid product
	And Being logged in Admin
	When Admin activating product
	Then Product is activated

@tag8
Scenario: Deactivating product
	Given valid product
	And Being logged in Admin
	When Admin deactivating proudct
	Then Product is deactivated