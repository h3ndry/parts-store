### [Back](../README.md)

TTDUC-225 - Update existing GET endpoint to allow filtering and sorting parts based on multiple fields
============

## Description
As a user I'd like to be able to filter and sort my parts
based on "Part String", "Unit Type", "Status" and optionally "Supplier Id", "Plant Id"
So that I can find specific parts more easily

## Acceptance Criteria
- Filtering is added to existing GET All endpoint as query parameters
- Sorting by Part ID or Part String is added to existing GET All endpoint as query parameter
- Unit Tests should be added
- (optional) Integration Tests should be added
