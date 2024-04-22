### [Back](../README.md)

TTDUC-327 - Add paging to the Part's list ag-grid
============

## Description
As a User I want to prevent requesting large data-sets

By limiting the GET requests to a maximum of 100 items per request via pagination.

To reduce bandwidth usage and improve system performance under load.

## Acceptance Criteria
- Add Pagination with options for 10, 20, 50 and 100 items per request to the GET Endpoint
- Jasmine tests should be added
