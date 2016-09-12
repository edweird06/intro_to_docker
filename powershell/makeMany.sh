#!/bin/bash

NUM_OF_CONATINAERS=5

if [ $1 ]; then
    NUM_OF_CONATINAERS=$1
fi

echo "${NUM_OF_CONATINAERS}"

i=0
while [ $i -lt $NUM_OF_CONATINAERS ]
do
    docker run -itd --name "csharp_${i}" csharp http://192.168.99.1:8080 00:00:01
    i=$[$i+1]
done