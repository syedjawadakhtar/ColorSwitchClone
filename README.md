# Color Switch Clone Game
Assignment Submission - HXRC

Submitted by: Syed Jawad Akhtar

## Table of Content

 1. [Description](#description)
 2. [Mechanics](#mechanics)
 3. [HUD (Heads-Up Display)](#hud-heads-up-display)
 4. [Installation and Setup](#installation-and-setup)
 5. [WebGL Build](#webgl-build)
 6. [Controls](#controls)
 7. [Future Prospects of the Project](#future-prospects-of-the-project)
 8. [Time distribution for the assignment](#time-distribution-for-the-assignment)

### Description

In this game, the player controls a colored ball that moves along the Y-axis under the influence of gravity. The player must tap the screen to make the ball jump upward, avoiding obstacles of different colors. The ball can only pass through obstacles of the same color.

### Mechanics

1. The Ball: Controlled by a single input (screen tap or mouse click).
    Moves only along the Y-axis. Changes color upon colliding with a Color Switcher object.
    Follows gravity when no input is given.
    Game ends if the ball hits an obstacle of a different color or falls below the screen.
    The ball is initialized with one of four colors.

2. Obstacles: There are three types of obstacles are present falling in the game. The obstacles block the ball's movement along the Y-axis. Obstacles are colored similarly to the ball, and the ball can only pass through matching colors.

3. Stars: The player can collect stars scattered in the game. Collecting a star increases the total score. A visual particle system and sound effects are triggered when a star is collected.

4. Color Switcher: Changes the ball's color to a new, random color upon collision. Ensures the new color is different from the current one. The object is destroyed after collision.

### HUD (Heads-Up Display)
The HUD displays the total stars collected in the top-left corner of the screen. Upon game over, a Game Over message is displayed along with the total stars collected.

### Installation and Setup

1. Clone the repository:

```bash
git clone https://github.com/SyedJawadAkhtar/ColorSwitchClone.git
```
2. Open in Unity:

- Use Unity Version 2022.3.21f to open the project.
- Open the GameScene and press Play to run the game from the Unity Editor.

### WebGL Build

You can find the WebGL build here: [https://syedjawadakhtar.github.io/ColorSwitchClone/](https://syedjawadakhtar.github.io/ColorSwitchClone/)
 
### Controls

- Tap the screen (or click with the mouse) to make the ball jump.
- The ball will continuously fall due to gravity when no input is given.

### Future Prospects of the Project

1. Introduce 3D depth illusions for the game objects.
2. Develop additional levels featuring diverse themes and challenges.
3. Add more game objects with various colors and shapes to enhance gameplay complexity and visual appeal.
4. Add more sound elements, including background music and sound effects.
5. Implement additional power-ups for the player, such as speed boosts and invincibility.
6. Create new game modes, including time trials and races.
7. Introduce more game characters, each with unique abilities and powers.
8. Expand the range of rewards and achievements for players to collect.

### Time distribution for the assignment

| Task                                                                             | Time (hrs) |
|----------------------------------------------------------------------------------|------------|
| Planning and formulating the logic for each part of the game                    | 3          |
| Designing the game and scripting                                                  | 15         |
| Building & Documentation                                                          | 2          |
| **Total**                                                                        | **20**     |

