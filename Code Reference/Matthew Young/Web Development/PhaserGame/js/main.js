var Main = function(game) {

};

var platforms;

Main.prototype = {

    create: function() {

        game.physics.startSystem(Phaser.Physics.ARCADE);
        platforms = game.add.group();
        platforms.enableBody = true;

        game.world.setBounds(0,0, game.width, 10000);
        game.add.sprite(0, 0, "gameBG");
/*
        for (var i = 0; i < 200; i++) {
            var x = 0;
            var y = 0;
            //var widthScale = 7;
            //var offsetX = game.rnd.integerInRange(innerWidth/8, innerWidth/5);
            if (i % 2 !== 0) {
                x = game.width - 100;
                //offsetX = game.rnd.integerInRange(0, innerWidth/8);
            }
            y -= i * 200;

            var platform = platforms.create(x, y,"platform");
            platform.body.immovable = true;
            platform.scale.setTo(.5, .5);
        }*/

        var platform = platforms.create(game.world.centerX, game.world.centerY, "platform");
        platform.body.immovable = true;
        //platform.scale.setTo(.5, .5);
    },

    update: function() {
        //game.debug.cameraInfo(game.camera, 32, 32);
        //game.debug.spriteCoords(, 32, 500);

        game.camera.y--;
    },

    gameOver: function() {
        this.game.state.start('GameOver');
    },

};
