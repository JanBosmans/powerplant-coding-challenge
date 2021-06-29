# powerplant-coding-challenge


## Start the API

Execute Publish\ProductionPlanAPI.exe

## Logging

Logging is configured to the relative paths /internal_logs & /logs from the exe. <br/>
Log file locations can be configured in Publish/Nlog.config


## Calling the API

### Open API
The API is available through openAPI <br/>
https://localhost:8888/swagger/index.html

### Postman

The Postman folder contains an export of HTTP POST commands to process the example payload files.

### API Responses

<li>200 ok:<br/> 
  &nbsp;&nbsp;&nbsp;&nbsp;
  The payload was processed succesfully and the production plan is provided in the response body<br/>

<li>400 Bad request:<br/> 
  &nbsp;&nbsp;&nbsp;&nbsp;
  The payload was invalid; the response body contains the validation error message<br/>

<li>404 Not Found:<br/> 
  &nbsp;&nbsp;&nbsp;&nbsp;
  The production plan total power does not equal the requested load; the response body contains the production plan.<br/>

<li>500 Internal server Error:<br/> 
  &nbsp;&nbsp;&nbsp;&nbsp;
  An error occured; the response body contains the error type; the error is logged in the logs folder<br/>

## C# solutions file
The solutions file ProductionPlanAPI.sln is provided in folder /ProductionPlanAPI
