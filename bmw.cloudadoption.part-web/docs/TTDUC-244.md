### [Back](../README.md)

TTDUC-244 - Add filter and sorting to the Part's list ag-grid
============

## Description
As a user I'd like to be able to filter and sort my parts
based on "Part String", "Unit Type", "Status" and optionally "Supplier Id", "Plant Id"
So that I can find specific parts more easily

The current UI is updated to have a separate section that has the option to filter the displayed list of parts based on some filter criteria's.

Filter criteria's:

- status
- plant id
- supplier id
- unload point

## Acceptance Criteria
- Parts result displayed on the UI Grid/Table can be filtered based on certain criteria's
- Update the part.service.ts methods accordingly
- Jasmine tests should be added
