Feature: SwaggerInventoryStep
  As a Dev Team,
  I want to place an order to inventory
  And verify the item

@Positive
Scenario Outline: Verify inventory after placing an order
  Given I have an API service '<endpoint>'
  When I hit the API to place the order
  Then I should get a valid response '<status>'

  Examples:
    | endpoint | status |
    | create   | 200    |

# @Positive
# Scenario Outline: Verify item after getting an order after create
#   Given I have an API service '<endpoint>'
#   When I hit the API to place the order
#   And I have an API service '<endpointtwo>'
#   And I hit the API to get the order details
#   Then I should get a valid response '<status>'

#   Examples:
#     | endpoint | endpointtwo | status |
#     | create   | get         | 200    |


# @Positive
# Scenario Outline: Verify item deleted after getting an order
#   Given I have an API service '<endpoint>'
#   When I hit the API to place the order
#   And I have an API service '<endpointtwo>'
#   And I hit the API to get the order details
#   And I hit the delete API '<endpointthree>'
#   Then I should get a valid response '<status>'

#   Examples:
#     | endpoint | endpointtwo | endpointthree | status |
#     | create   | get         | delete        | 200    |


# @Positive
# Scenario Outline: Verify User Info
#   Given I have an API service '<endpoint>'
#   When I hit the user API with user info
#   Then I should get a valid response '<status>'

#   Examples:
#     | endpoint   | status |
#     | usercreate | 200    |


@Positive
Scenario Outline: Verify status of response with time comparison
  Given I have an API service '<endpoint>'
  When I perform a web request
  And I perform a second web request
  Then I should get a valid response '<status>'

  Examples:
    | endpoint     | status |
    | findbystatus | 0      |

@Positive
Scenario Outline: Verify User Info for FindByStatus
  Given I have an API service '<endpoint>'
  When I hit the user API with user info
  Then I should get a valid response '<status>'

  Examples:
    | endpoint     | status |
    | findbystatus | 200    |
