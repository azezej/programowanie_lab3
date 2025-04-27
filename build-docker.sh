#!/bin/bash

newgrp docker
docker build -t lab3:release -f Dockerfile
docker run -it lab3:release
