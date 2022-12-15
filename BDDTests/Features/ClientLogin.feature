Feature: Logging in as a client
Admin can sign in to the applicaiton

@Client @Login @CorrectData
Scenario: The client can login to the system
    Given Client is not logged in
    And Client has registered before
        | name   | surname  | address | postalCode | login  | password |
        | Marian | Kowalski | XYZ     | 00-000     | marian | haslo123 |
    When Client enters correct login
    And Client enters correct password
    Then The clients' login data are correct

@Client @Login @NotCorrectData
Scenario Outline: The client can't login to the system when data are not correct
    Given Client is not logged in
    When Client enters incorrect <invalid_login> and <invalid_password>
    Then The client's login data are not correct
    
    Examples:
        | invalid_login | invalid_password |
        | _test         | test             |
        | marian        | _test            |
        | marian        |                  |
        |               | haslo123         |
        |               |                  |
