## Welcome to the BWM Group - Tech Talent Day

This repository contains the Angular implementation for the parts-service for the Tech Talent Day hackathon.

## Getting Started

### Branching and Commits

After cloning the `main` branch create a new Branch in the `feature/{{your-name}}` sub folder

> example: `git checkout -b feature/john-doe main`

Use this single branch to push all your commits to.
Commit messages should start with the User Story in question.

> example: `git commit -am "TTDUC-123: Add validation to data Model"`

### Development server

Run `npm install` and `ng serve` for a dev server. Navigate to `http://localhost:4200/`.

The application will automatically reload if you change any of the source files.

#### Connect to cloud hosted backend

If you would like to rather connect to the cloud hosted backend follow these steps:

- Navigate to `src/environments/environment.ts`
- Update `baseUrl` to `https://parts-service-ui.ttd.aws.bmw.cloud/csharp`
- When running your angular app ensure that you select the `localhost` backend option via the UI

### User Stories

| Difficulty |           User Story           | Description                                                                                             |
|------------|:------------------------------:|:--------------------------------------------------------------------------------------------------------|
| easy       | [TTDUC-246](docs/TTDUC-246.md) | Validate Part before saving                                                                             |
| easy       | [TTDUC-243](docs/TTDUC-243.md) | Visual representation Part's by 'UnitType'                                                              |
| medium     | [TTDUC-244](docs/TTDUC-244.md) | Add filter and sorting to the Part's list ag-grid                                                       |
| medium     | [TTDUC-327](docs/TTDUC-327.md) | Add paging to the Part's list ag-grid                                                                   |
| medium     | [TTDUC-245](docs/TTDUC-245.md) | Add Delete feature and only allow to Delete a part when it's status is "Discontinued" with confirmation |
| hard       | [TTDUC-319](docs/TTDUC-319.md) | Create Form component(s) to add or update Parts                                                         |
| hard       | [TTDUC-326](docs/TTDUC-326.md) | Real-time part updates via asynchronous notifications                                                   |

