Feature: Proposing products basing on product

@Client @Propose
Scenario: The client can see proposed items based on product
    Given Client is logged in
    When Client choose product
    Then Client get list of proposed products