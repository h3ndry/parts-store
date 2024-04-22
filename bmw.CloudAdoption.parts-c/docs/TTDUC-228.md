### [Back](../README.md)

TTDUC-228 - Correctly Manage the Part's 'PartNumber' Property on Create or Update API requests
============

## Description
As Business I want to manage Part revisions by appending a Change-Index number to the Part's 'PartNumber' Property on Creating or Updating a Part

How Part Numbers works:

7 digit number + 2 increments as a change index = 9 numbers in total.
Captured as a single string but must be displayed with a hyphen ( xxxxxxxxx -> xxxxxxx-xx )

Part change rule-set:

- Creating a new 7 digit PartNumber should add the Part to storage with a Change-Index of "01" and status: "NEW". e.g. full part number in storage is "123456701" (displayed as 1234567-01 on the screen)
- While updating Part in Status "NEW" only updates property values
- When setting the Part to Status "VALID" locks the Part from being Edited again.
- If Editing a Part in Status "VALID". Should create a new Part with incremented Change-Index and Status: NEW.  e.g. full part number in storage is "123456702" (displayed as 1234567-02 on the screen)
- When setting the new Part to Status "VALID" it should change existing VALID Part to Status "DISCONTINUED" (only one "VALID" part should be active on a 7 digit PartNumber)

<p align="center">
  <img src="pics/Part%20Number%20Flow%20Diagram.png" />
</p>

## Acceptance Criteria
- New 7 digit Part numbers should include Change-Index on persistance
- Created Parts should have Status = NEW
- Only Allow Updates on Part Status == NEW
- If Part Status is set to VALID, Lock the Part for editing and set previous Part's Status to DISCONTINUED
- On API GET request the PartNumber should be displayed/sent back as "{partNumber}-{changeIndex}" e.g. "1234567-01"
- Unit Tests should be added
- (optional) Integration Tests should be added
