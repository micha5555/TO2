Feature: ListingItems
Admin can sign in to the applicaiton

@Client @List @FullOffer
Scenario: Client can list offer items
    Given Client is logged in
    And Offer list is not empty
    When Client lists offer 
    Then Offer list display is not empty

@Client @List @EmptyOffer
Scenario: Client can list offer items when list empty
    Given Client is logged in
    And Offer list is empty
    When Client lists offer
    Then Offer list display is empty

@Client @List @FullCart
Scenario: Client can list cart items
    Given Client is logged in
    And Cart list is not empty
    When Client lists cart items
    Then Cart list display is not empty

@Client @List @EmptyCart
Scenario: Client can list cart items when cart empty
    Given Client is logged in
    And Cart list is empty
    When Client lists cart items
    Then Cart list display is empty

@Client @List @FullOrders
Scenario: Client can list his orders
    Given Client is logged in
    And Order list is not empty
    When Client lists orders
    Then Order list display is not empty

@Client @List @EmptyOrders
Scenario: Client can list his orders when orders empty
    Given Client is logged in
    And Order list is empty
    When Client lists orders
    Then Order list display is empty

   


