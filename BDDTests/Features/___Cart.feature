Feature: Service

A short summary of the feature

@tag
Scenario: Adding product to cart
	Given valid cart product
	When adding cart to product
	Then product is added to cart

@tag
Scenario: Removing product from cart
	Given valid cart product
	When User remove cart to product
	Then product is removed from cart

@tag
Scenario: Calculating cart price
	Given valid cart
	When User calculates cart price
	Then Cart price is calculated

@tag
Scenario: Getting products from cart
	Given valid cart
	When User getting products from cart
	Then User have have access to cart products