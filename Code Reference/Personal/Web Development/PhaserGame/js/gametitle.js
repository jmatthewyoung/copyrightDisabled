var GameTitle = function(game){};
var background;

GameTitle.prototype = {

    create: function(){
        background = game.add.sprite(0,0,"menuBG");
        button = game.add.button(game.world.centerX, game.world.centerY, "Start", this.startGame, this, 2, 1, 0);
    },

    startGame: function(){
        this.game.state.start("Main");
    }

}
