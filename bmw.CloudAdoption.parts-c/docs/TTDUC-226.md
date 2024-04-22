### [Back](../README.md)

TTDUC-226 - Add Pagination to the existing Part GET endpoint using Query Parameters
============

## Description
As Business I want to prevent users from requesting large data-sets
By limiting the GETAll requests to a maximum on 100 items per request via pagination.
To reduce bandwidth usage and improve system performance under load.

## Acceptance Criteria
- Add Pagination with a max off 100 items per request to the GET All Endpoint
- Unit Tests should be added
- (optional) Integration Tests should be added
