### [Back](../README.md)

TTDUC-224 - Enhance the Delete endpoint to delete only discontinued parts
============

## Description
As a user I want to only delete parts in a DISCONTINUED status
So that I don't delete any NEW or VALID parts

Incase of validation failure a 400 Response Code with message should be returned

## Acceptance Criteria
- Prerequisite to check Part Status
- Incase of validation failure a 400 Response Code with message should be returned
- Unit Tests should be added
- (optional) Integration Tests should be added
