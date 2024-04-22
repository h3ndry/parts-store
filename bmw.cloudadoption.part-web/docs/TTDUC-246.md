### [Back](../README.md)

TTDUC-246 - Validate Part before saving
============

## Description
As a Developer I want prevent user from submitting invalid requests by adding input validation

If there is a validation error, than the user should be properly informed of the issue

The Following Part's properties are restricted to:

- PartNumber: 7 digit (string)
- UnitType: 'SINGLE_PIECE' | 'SMALL_BOX' | 'LARGE_BOX' (string)
- Assembled: (boolean)
- Status: 'NEW' | 'VALID' | 'DISCONTINUED' (string)
- GrossWeight: Min of 0 and Max of 1000 (int)
- NetWeight: Min of 0 and Max of 1000 (int)
- WeightUnit: 'grams' | 'killograms' | 'tons' (string)

## Acceptance Criteria
- The UI has been updated to include the validations as specified in the description
- Jasmine tests should be added
