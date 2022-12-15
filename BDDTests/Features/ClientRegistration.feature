Feature: Registration as a client
Client can register

@Client @Registration @CorrectData
Scenario: The administrator can register to the system
    Given Client is not registered
    When Client provides correct data when registering
        | name   | surname  | address | postalCode | login  | password |
        | Marian | Kowalski | XYZ     | 00-000     | marian | haslo123 |
    Then The client account is created in the database

@Client @Registration @NotCorrectData   
Scenario Outline: The client can't register to the system when data are not correct
    Given Client is not registered
    When Client provides invalid <login> and invalid <password> and <name> and <surname> and <address> and <postalCode> while registering
    Then The client account is not created in the database

    Examples:
        | name   | surname  | address | postalCode | login   | password  |
        | Marian | Kowalski | XYZ     | 00-000     | _marian | haslo123  |
        | Marian | Kowalski | XYZ     | 00-000     | marian  | _haslo123 |
        | Marian | Kowalski | XYZ     | 00-000     | marian  |           |
        | Marian | Kowalski | XYZ     | 00-000     |         | haslo123  |
        | Marian | Kowalski | XYZ     | 00-000     |         |           |

Scenario: The administrator can't register to the system when he is already registered
    Given Client is registered using login and password
        | name   | surname  | address | postalCode | login  | password |
        | Marian | Kowalski | XYZ     | 00-000     | marian | haslo123 |
    When Client provides already registered <login> and <password> while registering again
    Then The client can not register using existing login