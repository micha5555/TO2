Feature: ListingItems
Admin can sign in to the applicaiton

@Client @List @FullOffer
Scenario: Client can list offer items
    Given Client is logged in
    And Offer is not empty
    When Client lists active products from offer 
    Then List of active products is not empty

@Client @List @EmptyOffer
Scenario: Client can list offer items when list empty
    Given Client is logged in
    And Offer is empty
    When Client lists active products from offer
    Then List of offer products is empty

@Client @List @FullCart
Scenario: Client can list cart items
    Given Client is logged in
    And Cart is not empty
    When Client lists cart items
    Then List of cart items is not empty

@Client @List @EmptyCart
Scenario: Client can list cart items when cart empty
    Given Client is logged in
    And Cart is empty
    When Client lists cart items
    Then List of cart items is empty

@Client @List @FullOrder
Scenario: Client can list items from his order
    Given Client is logged in
    And Order is not empty
    When Client lists order items
    Then List of ordered items is not empty

@Client @List @EmptyOrder
Scenario: Client can get empty list of his order when order is empty
    Given Client is logged in
    And Order is empty
    When Client lists order items
    Then List of ordered items is empty

@Client @List @FullOrders
Scenario Outline: Client can list his orders
    Given Client is logged in
    And Client have <number> orders
    When Client lists his orders
    Then <number> orders are in list of orders

    Examples:
        | number |
        | 1      | 
        | 2      |
        | 3      |
        | 10     |
        | 100    |
        | 1000   | 


@Client @List @FullOrders
Scenario: Client can get empty list of his orders when orders are empty
    Given Client is logged in
    And Client orders are empty
    When Client lists his orders
    Then List of orders is empty 

   


