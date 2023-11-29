Feature: Login to SauceDemo
   As a user
   I want to login to SauceDemo
   So that I can access my inventory

Scenario: Successful login with standard user
   Given I navigate to the SauceDemo login page
   When I login with username "standard_user" and password "secret_sauce"
   Then I should be redirected to the inventory page

Scenario: Unsuccessful login with locked out user
   Given I navigate to the SauceDemo login page
   When I login with username "locked_out_user" and password "secret_sauce"
   Then I should see the error message

Scenario: Unsuccessful login without user
   Given I navigate to the SauceDemo login page
   When I login with username "" and password ""
   Then I should see the error message
