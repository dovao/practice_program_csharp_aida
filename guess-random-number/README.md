# Goal

## What do we want to build?

We want to create a small game. The game consists of a player trying to guess a random integer number between 1 and 12. 
The player will have three attempts to guess the number. 
If the number is correctly guessed, then the player wins, if not, the player loses.

If the player fails to guess the number, the game must notify the user if the number it's higher or lower.

## Business rules

- The user starts playing, the game generates a random number that must not change until the game it's over.
- If the user guesses the number the player wins and the game is over.
- If the user does not guess the number the system would have to notify the user if the number it's higher or lower.
- If the user does not guess the number on three intents it will lose and the game is over.

## Constraints

This is the interface of the game object:

`public void run()`