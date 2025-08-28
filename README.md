# Medieval Hell Shooter 🎯

**Medieval Hell Shooter** is a bullet-shooting simulation game.  
The main focus is to simulate intense projectile patterns from enemy spawners.

---

## Gameplay 🕹️

- The boss spawns bullets using spawner prefabs.
- Spawners are shield sprites that act as bullets.
- Various bullet patterns are implemented, such as:
  - Straight
  - Snake
  - Spin
- Implemented this way to allow spawner rotation independently of the boss, so bullets can be emitted at multiple angles.

---

## Features ⚙️

- Multiple spawner types with unique movement and rotation patterns.
- Dynamic bullet instantiation with direction and speed control.
- UI displays the active bullet count in real-time.
- Configurable spawner settings:
  - Bullet object
  - Bullet speed
  - Number of arms (number of directions bullets are fired)
  - Spawner type
  - Spawn rate

---

## Implementation ⚒️

- Developed in **Unity** using **C#**.
- Spawner logic handled through the **Skull_Spawner** script.

---

## Future Enhancements 🎯

- Add player-controlled character movement.
- Include destructible objects and collision detection.
- Implement more complex bullet patterns.

---

## References

### Assets
- **Dungeon Tale - Fantasy RPG Sprites FX Tileset**. (2025). Unity Asset Store. [Link](https://assetstore.unity.com/packages/2d/environments/dungeon-tale-fantasy-rpg-sprites-fx-tileset-296458)
- **Fake Shadow For 2D**. (2025). Unity Asset Store. [Link](https://assetstore.unity.com/packages/2d/textures-materials/fake-shadow-for-2d-281626)
- **Free - Casual & Relaxing Game Music Pack**. (2025). Unity Asset Store. [Link](https://assetstore.unity.com/packages/audio/music/free-casual-relaxing-game-music-pack-262740)

### Videos
- [Video 1](https://www.youtube.com/watch?v=YNJM7rWbbxY)
- [Video 2](https://www.youtube.com/watch?v=_YgeNG6MtQQ&t=3s)
- [Video 3](https://www.youtube.com/watch?v=QQ3Yub9So2k&t=184s)

### Documentation
- Unity Technologies. (2025). *Unity - Scripting API: Time.deltaTime*. [Link](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-deltaTime.html)
- Unity Technologies. (2022). *Cannot implicitly convert type “string” to “TMPro.TextMeshProUGUI.”* [Link](https://discussions.unity.com/t/cannot-implicitly-convert-type-string-to-tmpro-textmeshprougui/884511)
