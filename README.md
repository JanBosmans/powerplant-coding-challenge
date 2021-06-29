# powerplant-coding-challenge


## Start the API

Execute Publish\ProductionPlanAPI.exe

## Logging

Logging is configured to the relative paths /internal_logs & /logs from the exe.
Log file locations can be configured in Publish/Nlog.config


## Calling the API

### Open API
The API is available through openAPI
https://localhost:8888/swagger/index.html

### Postman

The Postman folder contains an export of HTTP POST commands to process the example payload files.

### API Responses

200 ok: The payload was processed succesfully and the production plan is provided in the response body

400 Bad request: The payload was invalid; the response body contains the validation error message

404 Not Found: The production plan total power does not equal the requested load; the response body contains the production plan.

500 Internal server Error: An error occured; the response body contains the error type; the error is logged in the logs folder

