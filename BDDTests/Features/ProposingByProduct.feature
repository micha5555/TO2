Feature: Proposing products basing on product

@Client @Propose
Scenario: The client can see proposed items based on product
    Given Client is logged in
    And Previous orders exist
    When Client choose product
    Then Client get list of proposed products based on product