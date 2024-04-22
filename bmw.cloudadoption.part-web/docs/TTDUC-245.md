### [Back](../README.md)

TTDUC-245 - Add Delete feature and only allow to Delete a part when it's status is "Discontinued" with confirmation
============

## Description
As a user, I want to delete a part from the list so that I can remove parts that are no longer required.

Only allow to Delete a part when it's status is "Discontinued" - otherwise should be greyed out (with help text on button/link)

## Acceptance Criteria
- Implement a "Delete" button for each part in the table. When clicked, open a confirmation dialog and, upon confirmation, send a delete request
- Jasmine tests should be added
