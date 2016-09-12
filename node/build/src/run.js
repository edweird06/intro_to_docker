var Redis = require('ioredis');
var express = require('express');
var app = express();
var dockerRedis = new Redis({ host: '192.168.99.100' });
var port = 5000;


function getFromRedis(log) {
    var promises = [];
    var results = {};
    var run = dockerRedis.keys('*')
    .then(allKeys => {
        allKeys.forEach(key => {
            promises.push(dockerRedis.get(key).then(res => results[key]=res, err => console.log(key, err)));
        });
    })
    .then(() => Promise.all(promises))
    .then(() => results);
    if (log) {        
        run.then(() => console.log(results))
        .then(() => setTimeout(() => getFromRedis(true), 1000));
    }
    return run;
}

getFromRedis(true);

app.get('/', function (req, res) {
    getFromRedis()
    .then(result => res.send(result))
    .then(() => console.log('GET current value...'));
});

app.listen(port, function () {
  console.log(`Example app listening on port ${port}!`);
});