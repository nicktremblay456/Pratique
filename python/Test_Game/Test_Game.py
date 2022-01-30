import arcade
import random

SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600
SCREEN_TITLE = "Game Test"

SPRITE_SCALING_COIN = 0.2
SPRITE_SCALING_PLAYER = 1
COIN_COUNT = 10


class MyGame(arcade.Window):
    """ Main application class. """

    def __init__(self, width, height, title):
        super().__init__(width, height, title)

        arcade.set_background_color(arcade.color.AMAZON)

    def setup(self):
        """ Set up the game and initialize the variables. """

        # Create the sprite lists
        self.player_list = arcade.SpriteList()
        self.coin_list = arcade.SpriteList()

        # Score
        self.score = 0

        # Set up the player
        # Character image from kenney.nl
        self.player_sprite = arcade.Sprite("images/circle.jpg", SPRITE_SCALING_PLAYER)
        self.player_sprite.center_x = 300 # Starting position
        self.player_sprite.center_y = 300
        self.player_list.append(self.player_sprite)

        # Create the coins
        #for i in range(COIN_COUNT):
        #
        #    # Create the coin instance
        #    # Coin image from kenney.nl
        #    coin = arcade.Sprite("images/ship.png", SPRITE_SCALING_COIN)
        #
        #    # Position the coin
        #    coin.center_x = random.randrange(SCREEN_WIDTH)
        #    coin.center_y = random.randrange(SCREEN_HEIGHT)
        #
        #    # Add the coin to the lists
        #    self.coin_list.append(coin)

    def on_draw(self):
        """ Draw everything """
        arcade.start_render()
        self.coin_list.draw()
        self.player_list.draw()

    def update(self, delta_time):
        """ All the logic to move, and the game logic goes here. """
        pass


def main():
    game = MyGame(SCREEN_WIDTH, SCREEN_HEIGHT, SCREEN_TITLE)
    game.setup()
    arcade.run()


if __name__ == "__main__":
    main()