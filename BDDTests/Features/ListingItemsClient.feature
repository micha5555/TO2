Feature: Listing items

Possibility to display a list of products

@EmptyList @Client
Scenario: Display empty list of products
	Given Being in the "Menu Klienta" section.
	When List of items is empty
	And Enter the option number "Przeglądanie produktów w ofercie"
	Then "Lista wszystkich produktów" is visible
	And Message "Lista jest pusta!" displays

@OneItemList @Client
Scenario Outline: Display list with one item
	Given Being in the "Menu Klienta" section.
	When List of items has one item <item_name>
	And Item <item_name> costs <item_price>
	And Item <item_name> has description <item_description>
	And Item <item_name> is of the category <item_category>
	Then "Lista wszystkich produktów" is visible
	And <item_name> with <item_category> category and <item_price> price displays

	Examples:
	| item_name  | item_price | item_description       | item_category   |
	| Szlifierka | 300        | Szlifierka o wadze 2kg | Narzędzia       |
	| Pralka     | 2300       | Max ładowność: 5kg     | AGD             |
	| Oscyloskop | 800        | Nie lizać ekranu       | Elektrotechnika |
	| Kask       | 80         | Mocny, odporny         | Ubiór           |
