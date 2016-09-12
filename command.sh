#!/bin/bash

docker ps --all --filter name=redis
docker rm -f $(docker ps -f name=$NAME -aq)