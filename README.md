# Virus Infection Simulator

A top-down 2d RTS game where the player must protect the healthy cells using protector cells against the infection.

## Objectives

- Save as many healthy cells from the infection.
- Starve the infected cells by isolating them from the healthy ones via protector cells.


## Entities

This game consists mainly of three different entity cells: protector, healthy, and infected.

### Protector Cells
Protector cells are the only entities that the player can manipulate within the scene. These cells server to protect 
the healthy cells from the infected ones. The infector cells cannot infect protector cells. The protector cells can also
destroy infected cells.

### Healthy Cells
The healthy cells are the basic cells of the game. They do not do much other than wander aimlessly, but are aware of infected cells and tend to try and run away from them, if possible.

### Infected Cells
Infected cells are cells that have been infected (meta). The behavior of an infected cell is to spread the infection to
healthy cells, and will stop at nothing to infect them. Their own health gradually deteriorates, so they will not live very long after being infected.

## Game Mechanics

This game's first iteration will have very basic game mechanics.

### Borders
The game must have borders to prevent the cells from leaving the camera's current view.

### Continuous Gameplay
The game will only end under two conditions:
- All of the infected cells have died.
- All of the healthy cells have been infected.