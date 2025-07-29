Feature: SwaggerInvntoryStep
	As a Dev Team
	I want to place an order to inventory
	And verify the item.

@Positive
Scenario: Vefiry inventory after placing an order
	Given I have a Api Service '<endpoint>'
	When I hit the api to place the order 
	Then I should get a vlid response'<status>'

Examples: 
| endpoint | status |
| create   | 200    |

@Positive
Scenario: Vefiry item after getting an order after create
	Given I have a Api Service '<endpoint>'
	When I hit the api to place the order 
	Given I have a Api Service '<endpointtwo>'
	When I hit the api to get the order details
	Then I should get a vlid response'<status>'

Examples: 
| endpoint | endpointtwo | status |
| create		| get		 | 200    |

@Positive
Scenario: Vefiry item deleted after getting an order
	Given I have a Api Service '<endpoint>'
	When I hit the api to place the order 
	Given I have a Api Service '<endpointtwo>'
	When I hit the api to get the order details
	When I hit the delete Api'<endpointthree>'
	Then I should get a vlid response'<status>'


Examples: 
| endpoint| endpointtwo | endpointthree | status |
| create	  | get         | delete        | 200    |

@Positive
Scenario: Verify User Info
	Given I have a Api Service '<endpoint>'
	When I hit the user api with user info
	Then I should get a vlid response'<status>'

Examples: 
| endpoint		| status |
| usercreate   | 200    |

@Positive
Scenario: Vefiry Status of actual response of Current time with actual respone with previous time
	Given I have a Api Service '<endpoint>'
	When I perform a web request
	Given I have a Api Service '<endpoint>'
	When I perform a second web request
	Then I should get a valid response'<status>'

Examples: 
| endpoint		| status |
| findbystatus   | 0    |


@Positive
Scenario: Verify User Info For FindByStatus
	Given I have a Api Service '<endpoint>'
	When I hit the user api with user info
	Then I should get a valid response'<status>'

Examples: 
| endpoint		| status |
|  findbystatus | 200    |
