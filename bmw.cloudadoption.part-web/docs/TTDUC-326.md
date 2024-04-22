### [Back](../README.md)

TTDUC-326 - Real-time part updates via asynchronous notifications
============

## Description
As a user, I want the app to display real-time part updates so that I can stay informed about the latest part changes.

## Acceptance Criteria
- Implement a real-time data update mechanism using WebSocket or Server-Sent Events.
- Subscribe to the real-time data source and update the parts list in the table accordingly.
- Jasmine tests should be added
- A mock provider is implemented to simulate server updates every 5 seconds
