# Run With Docker Containers

## Dev mode
Generate a certificate file named shop.pfx in the cert folder of this folder with the following command:
```sh
dotnet dev-certs https -ep ./cert/shop.pfx -p Password123 -t
```

Run the compose project with the following command:
```sh
docker-compose up
```