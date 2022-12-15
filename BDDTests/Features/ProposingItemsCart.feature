Feature: Proposing items to a Client

@Client @Propose @CartNotEmpty
Scenario: The client can see proposed items based on his cart when cart is not empty
    Given Client is logged in
    And Clients cart is not empty
    When Client enters his cart
    Then Client get list of proposed products