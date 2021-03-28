# Barcode microservice
A basic donet showcase app

## Building and running

Build the application:
```bash
$ dotnet build
```

Start the application:
```bash
$ cd api
$ dotnet run
```
Application will start on port 5001.

## Testing

### Unit tests

Run unit tests
```bash
$ dotnet test
```

### Swagger
[Swagger](https://swagger.io/) api browsing util is enabled by default on: [https://localhost:5001/swagger/index.html]()

or you can use curl

### CURL

Save a barcode
```bash
$ curl -X PUT "https://localhost:5001/api/barcode/{{CODE}}" -H  "accept: text/plain"
```

Save multiple barcodes
```bash
$ curl -X PUT "https://localhost:5001/api/barcode/batch" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "[\"BARCODE1\",\"BARCODE2\",\"BARCODE3\",...]"
```

Get the barcode count
```bash
$ curl -X GET "https://localhost:5001/api/barcode/count" -H  "accept: text/plain"
```

Get the barcode count by courier
```bash
$ curl -X GET "https://localhost:5001/api/barcode/count-by-courier" -H  "accept: text/plain"
```

## Docker

Build the docker image:
```bash
$ cd api
$ dotnet publish -c Release 
$ docker build -t barcode-image -f Dockerfile .  
```

Create and start the docker container:
```bash
$ docker create -p80:80 -p443:443 --name barcode barcode-image
$ docker start
```
Swagger is available also in docker





