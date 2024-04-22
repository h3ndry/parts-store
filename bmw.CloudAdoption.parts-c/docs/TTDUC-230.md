### [Back](../README.md)

TTDUC-230 - Implement messaging pattern to send data asynchronously to the UI
============

## Description
As a user I would like the backend to send any data changes asynchronously to the Frontend
So that the eventually consistent data via Kafka automatically gets synchronized when processed

## Acceptance Criteria
- Implement a real-time data update mechanism using WebSocket or Server-Sent Events, which subscribes to the published events
- Unit Tests should be added
- (optional) Integration Tests should be added
