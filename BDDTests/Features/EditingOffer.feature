Feature: Editing Offer

Scenario: Admin can add product to offer
    Given Admin is logged in
    And Primary offer exists
    When Admin adds product to offer
    Then Offer contains this product