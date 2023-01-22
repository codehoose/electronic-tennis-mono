# Electronic Tennis or Tennis for Two or Pong
Monogame version of Pong for two players.

# Playfield
The playfield is a boxed rectangle inside the game window. It is bisected by a dotted line running down the middle. Player 1 controls a bat (vertical bar) on the left hand side of the screen. The player's score is to the left of the dotted line. Player 2 controls a bat on the right hand side of the screen. Their score is to the right of the dotted line.

When the ball is served it will bounce off the bats and the top and bottom borders. If the ball comes into contact with either left- or right- side, the opposing player wins the point. e.g. if Player 1 (left) gets the ball to the right-most side of the screen, they win the point.

# Controls
Player 1: Q to move the bat up, A to move the bat down. You are on the left.
Player 2: P to move the bat up, L to move the bat down. You are on the right.

Press SPACE to serve the ball. First player to 5 wins. Winner is "announced" by the player's score flashing.

# Development
I was trying to develop a type-in style game that would help people get into game development. Pong (and space invaders) is such a "Hello World!" type for me I decided to implement it. I chose not to import sprites or other graphics and just use code. This fits in with the type-in style as well as making it easier for the coder who doesn't have to go and download an external zip file containing images etc.