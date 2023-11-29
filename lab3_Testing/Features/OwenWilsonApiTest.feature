Feature: Owen Wilson Wow API functionality

Scenario: Retrieving random Owen Wilson "wow" moments
    When I request a random "wow" moment
    Then I should receive a "wow" moment details

Scenario: Retrieving all Owen Wilson "wow" moments
    When I request all "wow" moments
    Then I should receive a list of "wow" moments

Scenario: Retrieving "wow" moments by year
    Given I have a specific year "2006"
    When I request "wow" moments for that year
    Then I should receive "wow" moments from "2006"
