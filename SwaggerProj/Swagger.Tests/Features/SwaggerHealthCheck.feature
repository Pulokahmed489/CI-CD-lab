Feature: HealthCheck
	As a Dev Team
	I want a health end point via Swagger Services API
	So that I can Verify the connectivity


@SmokeTests
Scenario: Verify Swagger Services Health
	Given I have a Swagger Services API '<endpoint>'
	When I perform a web request
	Then I should see a valid response'<status>'

Examples: 

| endpoint | status |
| health   | 200    |

