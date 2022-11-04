# GyF-Api-Challenge

Prerrequisitos
-----

I assume you have installed Docker and it is running.

Ver [Docker website](http://www.docker.io/gettingstarted/#h_installation) para realizar la instalación.

Build
-----
Para compilar

1. Clonar el repositorio

        git clone https://github.com/CarlosBustos1/GyF-Api-Challenge.git

2. Moverse al directorio donde se encuentra la solucion

3. Ejecutar en la consola los siguientes comandos
```
   dotnet publish -c Release
   docker build -t gyf-api-challenge -f GyF-Api-Challenge.Api/Dockerfile .
   docker run -d -p 1234:80 --name gyf_challenge gyf-api-challenge:latest
```

4. abrir un navegador y navegar a * [http://localhost:1234/swagger/index.html](http://localhost:1234/swagger/index.html)
