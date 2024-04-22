### [Back](../README.md)

TTDUC-229 - Implement Validation and Exception handling in the solution
============

## Description
As a Developer I want prevent user from submitting invalid requests by adding data validation and exception handling.

The Following Part's properties are restricted to:

- PartNumber: 7 digit (string)
- UnitType: 'SINGLE_PIECE' | 'SMALL_BOX' | 'LARGE_BOX' (string)
- Assembled: (boolean)
- Status: 'NEW' | 'VALID' | 'DISCONTINUED' (string)
- GrossWeight: Min of 0 and Max of 1000 (int)
- NetWeight: Min of 0 and Max of 1000 (int)
- WeightUnit: 'grams' | 'killograms' | 'tons' (string)

For exception handling consider the following:

- Catch exceptions and handle them
- Status Codes returned to caller
- How exceptions are logged

## Acceptance Criteria
- Validation on Part added
- If Validation fails the correct Status code with message is sent back
- Log Validation exceptions
- Unit Tests should be added
- (optional) Integration Tests should be added
