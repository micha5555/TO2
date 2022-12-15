Feature: Registration as an admin
Admin can register 

@Admin @Registration @CorrectData
Scenario: The administrator can register to the system
    Given Admin is not registered
    When Admin provides correct login and password when registering
            | login | password |
            | test1 | test2    |
    Then The administrator account is created in the database

@Admin @Registration @NotCorrectData   
Scenario Outline: The administrator can't register to the system when data are not correct
    Given Admin is not registered
    When Admin provides invalid <login> and <password> while registering
    Then The administrator account is not created in the database

    Examples:
        | login  | password |
        | _admin | test     |
        |        | test     |
        | admin  |          |
        |        |          |

Scenario: The administrator can't register to the system when he is already registered
    Given Admin is registered using login and password
            | login | password |
            | test1 | test2    |
    When Admin provides already registered <login> and <password> while registering again
    Then The administrator can not register using existing login
