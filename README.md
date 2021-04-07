# Support api 

## Running project local

Install docker and docker-compose 

Create a .env file with the information below
```
#DOT NET CORE
APP_PORT=8080

#DATABASE
DATABASE_PORT=4000

#ContainerDabase
DBServer=database
DBPort=3306
DBName=amazonsupport
DBUser=root
DBPassword=1234

#APPLICATION VARIABLES
API_TITLE=Dream team support
API_VERSION=v1
SWAGGER_ENDPOINT=/swagger/v1/swagger.json

#KAFKA
KAFKA_TOPIC=test-topic
KAFKA_ADDRESS=kafka:29092
```

after this start application run the command docker-compose up -d

# Swagger documentation
http://localhost:8080/swagger-ui.html
