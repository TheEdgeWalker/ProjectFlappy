# Project Flappy
One day, I had the honor of having lunch with some fine game developers.

We were talking about procedural generation, and the game developer mentioned that they had worked on a prototype similar to Flappy Birds with procedurally generated terrain.
Unfortunately, the game developer told me that the game had to be canceled because they could not figure out how to monetize it.

I cam home, and I began thinking about our conversation. I was curious why the game developer said that it was difficult to monetize a game that is similar to Flappy Birds. 

So I have decided to try it out for myself.

# Objectives
1. Implement a full functioning endless runner game with Flappy Birds core gameplay and aesthetics.
2. Implement a meta game loop to ensure replay value.
3. Implement a mock monetization layer (in-game ads, in-game purchase).
4. Implement a data driven story system.

# To-do
- Implement
  - Gameplay
    - (Done!) Scrolling
    - (Done!) Skill
      - (Done!) Flap
      - (Done!) Brake
      - Zoom
      - Invincible
        - Buff
  - UI
    - (Done!) Sprite number (Score)
    - Skill buttons
      - (Done!) Cooldown timer
      - Icons
  - (Done!) ata System
    - (Done!) Skill
    - Character (Bird)
- Refactor
  - Split skill button and cooldown timer
  - (Done!) Move speed property from FlappyManager to Bird
- Fix
  - Sprite gap flickering
    - Make sprite atlas
  - Make brake more smooth
