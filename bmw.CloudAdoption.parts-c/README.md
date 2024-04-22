# Introduction

This repository contains the C# implementation for the parts-service for the Cloud Adoption hackathon.

# Getting Started

The parts service uses a kafka compact topics to store parts. Setting up and hosting a kafka instance can be done with the following steps:

Create the kafka using docker by running this command

```shell script
docker-compose up kafka
```

If you want to view your topics run the following command and navigate to `localhost:8070`

```shell script
docker-compose up akhq
```

Create a local SQL docker instance

```shell script
docker-compose up sql
```

# Build and Test

Setup your local api project by adding the config file `appsettings.Development.json` with the following content

```javascript script
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost,1433;Initial Catalog=TechTalentDay;Persist Security Info=False;User ID=sa;Password=Passw0rd!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
    },
    "KafkaTopics" :{
        "Parts": "bmw.ttd.parts.v2"
    },
    "Kafka": {
        "BootstrapServers": "localhost:9094",
        "SaslUsername": "user",
        "SaslPassword": "password",
        "EnableSslCertificateVerification": false,
        "SaslMechanism": "PLAIN",
        "SecurityProtocol": "Plaintext",
        "AllowAutoCreateTopics": true,
        "groupId": "bmw.ttd.parts.local"
    }
}
```

You should now be able to run the service and connect to your kafka instance.

### User Stories

| Difficulty |           User Story           | Description                                                                                |
| ---------- | :----------------------------: | :----------------------------------------------------------------------------------------- |
| hard       | [TTDUC-228](docs/TTDUC-228.md) | Correctly Manage the Part's 'PartNumber' Property on Create or Update API requests         |
| hard       | [TTDUC-231](docs/TTDUC-231.md) | Persist data to SQL database                                                               |
| hard       | [TTDUC-230](docs/TTDUC-230.md) | Implement messaging pattern to send data asynchronously to the UI                          |
| medium     | [TTDUC-225](docs/TTDUC-225.md) | Update existing GET endpoint to allow filtering and sorting parts based on multiple fields |
| medium     | [TTDUC-226](docs/TTDUC-226.md) | Add Pagination to the existing Part GET endpoint using Query Parameters                    |
| medium     | [TTDUC-229](docs/TTDUC-229.md) | Implement Validation and Exception handling in the solution                                |
| easy       | [TTDUC-227](docs/TTDUC-227.md) | Update Part's model WeightUnit to be an Enum                                               |
| easy       | [TTDUC-224](docs/TTDUC-224.md) | Enhance the Delete endpoint to delete only discontinued parts                              |
