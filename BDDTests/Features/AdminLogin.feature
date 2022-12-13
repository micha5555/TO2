Feature: Logging in
Admin can sign in to the applicaiton

@Admin @Login
Scenario: The administrator can login to the system
    Given Admin in not logged in
    And Admin has registered before using <login> and <password>
        | login | password |
        | test1 | test2    |
    When Admin enters correct login
    And Admin enters correct password
    Then The login data are correct




   


