Feature: Placing order

@Client @CreateOrder @NotEmptyCart
Scenario: Client can place an order with not empty cart
    Given Client is logged in
    And Cart is not empty
    When Client places an order
    Then Order is added to order list

@Client @CreateOrder @EmptyCart
Scenario: Client cannot place an empty order
    Given Client is logged in
    And Cart is empty
    When Client places an order
    Then Order is not added to order list