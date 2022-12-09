Feature: Admin login
Admin can sign in to the applicaiton

@Admin @Login
Scenario: Admin login to the app
        Given Being on the application login page
        Given Enter the option number "Logowanie Administratora"
        When Enter the following details
             | login | password |
             | test  | test     |
        And Press enter
        Then "Menu Administratora" is visible
        And Option "Wylogowanie" is visible
