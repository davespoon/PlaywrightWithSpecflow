Feature: EaAppTest
Simple calculator for adding two numbers

    @mytag
    Scenario: Test Login operation of EA application
        Given I navigate to application
        And I click Login link
        And I eneter following login details
          | Username | Password |
          | admin    | password |
        Then I see Employee list