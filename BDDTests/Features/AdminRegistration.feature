Feature: Registration as an admin
Admin can register 

@Admin @Registration @CorrectData
Scenario: The administrator can register to the system
    Given Admin is not registered
    When Admin provides correct login and password when registering
            | login | password |
            | test1 | test2    |
    Then The administrator account is created in the database

# TODO Rozbić na mniejsze warunki (prawidlowy login, nieprawidlowe haslo; puste znaki; itd)
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


#case 1: admin juz zarejestrowany
#case 2: pusty login
#case 3: puste haslo
#case 4: puste login i haslo
