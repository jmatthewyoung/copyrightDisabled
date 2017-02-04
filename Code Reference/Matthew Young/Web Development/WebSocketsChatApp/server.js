var express = require('express');
var app = express();
var server = require('http').createServer(app);

var io = require('socket.io').listen(server);
users = [];
connections = [];

console.log("Running...");

server.listen(8080);

app.get('/', function(req, res) {
    res.sendFile(__dirname + '/public/index.html');
});

io.sockets.on('connection', function(socket) {
    connections.push(socket);
    console.log(socket.id + ' connected. Number of connections: %s', connections.length);

    //Disconnect
    socket.on('disconnect', function(socket) {
        users.splice(users.indexOf(socket.username), 1);
        connections.splice(connections.indexOf(socket), 1);
        console.log('Disconnection. Number of connections: %s', connections.length);
        updateUsernames();
    });

    //New Message
    socket.on('send message', function(data) {
        io.sockets.emit('new message', {
            msg: data,
            user: socket.username
        });
    });

    //New User
    socket.on('new user', function(data, callback) {
        callback(true);
        socket.username = data;
        users.push(socket.username);
        updateUsernames();
    });

    //Drawing
    socket.on('mouse', function(data) {
        socket.broadcast.emit('mouse', data);
    });

    function updateUsernames() {
        io.sockets.emit('get users', users);
    }
});
