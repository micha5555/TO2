Feature: Logowanie do aplikacji jako klient
    Jako użytkownik chcę móc się zalogować, aby mieć dostęp do spersonalizowanych ofert.
    Scenario: Jako niezalogowany klient, chciałbym zalogować się do aplikacji
        Given Jestem na stronie logowania do aplikacji
        Given Wpisuję numer opcji Logowanie Klienta
        When Wpisuję "login" w polu "login"
        And Wpisuję "password" w polu "hasło"
        And Klikam enter
        Then Menu Klienta jest widoczne
        And Opcja "Wylogowanie" jest widoczna

Feature: Logowanie do aplikacji jako administrator
Jako administrator chcę móc się zalogować, aby móc korzystać z panelu administratora.
    Scenario: Jako niezalogowany administrator, chciałbym zalogować się do aplikacji
        Given Jestem na stronie logowania do aplikacji
        Given Wpisuję numer opcji Logowanie Administratora
        When Wpisuję "login" w polu "login"
        And Wpisuję "password" w polu "hasło"
        And Klikam enter
        Then Menu Administratora jest widoczne
        And Opcja "Wylogowanie" jest widoczna



