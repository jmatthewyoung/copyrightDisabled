var Preload = function(game){};

Preload.prototype = {

    preload: function(){
        game.load.image("leftStill", "assets/leftStill.png");
        game.load.image("leftWalk1", "assets/leftWalk1.png");
        game.load.image("leftWalk2", "assets/leftWalk2.png");

        game.load.image("rightStill", "assets/rightStill.png");
        game.load.image("rightWalk1", "assets/rightWalk1.png");
        game.load.image("rightWalk2", "assets/rightWalk2.png");

        game.load.image("platform", "assets/platform.jpg");
        game.load.image("menuBG", "assets/bg.png");
        game.load.image("gameBG", "assets/jungle.jpg");
    },

    create: function(){
        this.game.state.start("GameTitle");
    }
}
