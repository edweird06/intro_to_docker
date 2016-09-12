#!/bin/bash

NUM_OF_CONATINAERS=5

if [ $1 ]; then
    NUM_OF_CONATINAERS=$1
fi

echo "${NUM_OF_CONATINAERS}"

i=0
while [ $i -lt $NUM_OF_CONATINAERS ]
do
    docker run -itd --name "demo-csharp_${i}" edweird06/httpreq_csharp http://192.168.99.100:8080 00:00:01
    i=$[$i+1]
done