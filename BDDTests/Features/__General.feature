Feature: Service

A short summary of the feature

@tag1
Scenario: Proposing products based on Cart
	Given Being logged in User
	And valid Cart
	When 
	Then User is proposed product based on Cart

@tag2
Scenario: Proposing products based on Product
	Given Being logged in User
	When User add product to cart
	Then User is proposed product based on Product