Feature: Logging in
Admin can sign in to the applicaiton

@Admin @Login @CorrectData
Scenario: The administrator can login to the system
    Given Admin in not logged in
    And Admin has registered before using <login> and <password>
        | login | password |
        | test1 | test2    |
    When Admin enters correct login
    And Admin enters correct password
    Then The login data are correct

@Admin @Login @NotCorrectData
Scenario: The administrator can't login to the system when data are not correct
    Given Admin in not logged in
    And Admin has registered before using <login> and <password>
        | login | password |
        | test1 | test2    |
    When Admin enters incorrect login
    And Admin enters incorrect password
    Then The login data are not correct




   


