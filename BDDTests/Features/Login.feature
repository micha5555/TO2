Feature: Login to the application

@tag1
Scenario: Customer login to the app
    Given I am on the application main page
    Given I enter the option number "Logowanie Klienta"
    When Enter "login" in the "login" field
    And Enter "password" in the "hasło" field
    And Press enter
    Then "Menu Klienta" is visible
    And Option "Wylogowanie" is visible

@tag2
Scenario: Admin login to the app
    Given I am on the application main page
    Given I enter the option number "Logowanie Administratora"
    When Enter "login" in the "login" field
    And Enter "password" in the "hasło" field
    And Press enter
    Then "Menu Administratora" is visible
    And Option "Wylogowanie" is visible