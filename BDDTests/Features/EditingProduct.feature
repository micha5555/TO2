Feature: Editing product

@Admin @Edit @ProductActivity
Scenario: Admin can edit product activity
    Given Admin is logged in
    And Product exists
    When Admin edit product activity
    Then Product activity is changed

@Admin @Edit @ProductPrice
Scenario: Admin can edit product price
    Given Admin is logged in
    And Product exists
    When Admin edit product price
    Then Product price is changed