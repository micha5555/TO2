Feature: Logging in as admin
Admin can sign in to the applicaiton

@Admin @Login @CorrectData
Scenario: The administrator can login to the system
    Given Admin is not logged in
    And Admin has registered before using login and password
        | login | password |
        | test1 | test2    |
    When Admin enters correct login
    And Admin enters correct password
    Then The admin's login data are correct

# TODO Rozbić na mniejsze warunki (prawidlowy login, nieprawidlowe haslo; puste znaki; itd)
@Admin @Login @NotCorrectData   
Scenario Outline: The administrator can't login to the system when data are not correct
    Given Admin is not logged in
    When Admin enters incorrect <invalid_login> and <invalid_password>
    Then The admin's login data are not correct

    Examples:
        | invalid_login | invalid_password |
        | test          | test             |
        | test1         | test             |
        | test          | test2            |
        | test1         |                  |
        |               | test2            |
        |               |                  |