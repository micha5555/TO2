Feature: Logging in as client
Admin can sign in to the applicaiton

@Client @Login @CorrectData
Scenario: The client can login to the system
    Given Client in not logged in
    And Client has registered before
        | name   | surname  | address | postalCode | login  | password |
        | Marian | Kowalski | XYZ     | 00-000     | marian | haslo123 |
    When Client enters correct login
    And Client enters correct password
    Then The clients' login data are correct

@Client @Login @NotCorrectData
Scenario Outline: The client can't login to the system when data are not correct
    Given Client in not logged in
    When Client enters incorrect login and password
        | invalid_login | invalid_password |
        | test          | test             |
        | marian        | test             |
        | test          | haslo123         |
        | marian        |                  |
        |               | haslo123         |
        |               |                  |
    Then The client's login data are not correct