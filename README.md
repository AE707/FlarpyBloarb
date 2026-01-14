# 🐦 FlarpyBloarb

A Flappy Bird-inspired endless runner game built with Unity. Guide your bird through increasingly challenging obstacles and compete for the highest score!

![Unity](https://img.shields.io/badge/Unity-2022.3+-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-12.0-blue?logo=c-sharp)
![License](https://img.shields.io/badge/License-MIT-green)

## 🎬 Gameplay Preview

![Gameplay Demo](Assets/Screenshots/GamePlay.gif)

> **Note:** To add your gameplay GIF, create a `Screenshots` folder inside `Assets` and place your `GamePlay.gif` file there. GitHub will automatically render it above!


## 🧠 Core Engineering Concepts Demonstrated

- **Singleton Pattern** - GameManager persists across scenes using DontDestroyOnLoad
- **State Machine** - Clean game state transitions (Menu → Playing → Paused → GameOver)
- **Event-Driven Architecture** - OnGameStateChanged event system for decoupled UI updates
- **Data-Driven Design** - Difficulty scaling through configurable parameters
- **Separation of Concerns** - Game logic, UI management, and input handling in separate scripts
- **Dynamic Object Management** - Procedural pipe spawning with automatic cleanup
- **Adaptive Systems** - Spawn rate adjusts dynamically based on pipe movement speed

### Code Example: Game State Machine

```csharp
public enum GameState { Menu, Playing, Paused, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameState currentState;
    
    public event Action<GameState, GameState> OnGameStateChanged;
    
    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            if (currentState != value)
            {
                GameState previousState = currentState;
                currentState = value;
                OnGameStateChanged?.Invoke(previousState, currentState);
            }
        }
    }
}
```

### Difficulty Scaling Formula

```csharp
// Progressive speed increase based on player score
currentSpeed = baseSpeed + (playerScore * speedIncreasePerPoint);
currentSpeed = Mathf.Min(currentSpeed, maxSpeed); // Capped at 15 units/s

// Dynamic spawn rate maintains consistent pipe spacing
spawnRate = desiredPipeSpacing / currentSpeed;
```

**Technical Details:**
- Base Speed: 5 units/s
- Max Speed: 15 units/s  
- Speed Increase: 0.2 units/s per point
- At score 10: speed = 7 units/s
- At score 25: speed = 10 units/s
- At score 50: speed = 15 units/s (capped)



## 🎮 Features


## 📋 Project Roadmap

**Completed:**
- [x] Core gameplay loop with endless spawning
- [x] Progressive difficulty system
- [x] Game state management (pause/resume)
- [x] Collision detection and boundary checks
- [x] Dynamic spawn rate balancing
- [x] UI panel system with settings menu

**In Progress / Planned:**
- [ ] High score system with PlayerPrefs persistence
- [ ] Sound effects and audio feedback
- [ ] Bird rotation animation based on velocity
- [ ] Enhanced death screen with statistics
- [ ] Achievement system
- [ ] Visual themes and unlockable skins
- [ ] Tutorial for first-time players
- [ ] Power-ups system
- [ ] Alternative game modes (Time Attack, Survival, Zen)
- [ ] Online leaderboards integration


## 🎬 Gameplay

> **Note:** Screenshots and gameplay GIFs coming soon! Check back for visual demonstrations of the game in action.



### Current Features
- **Endless Gameplay** - Navigate through infinite procedurally-spawned pipes
- **Progressive Difficulty** - Game speed increases based on your score
- **Dynamic Spawn System** - Pipe spacing adjusts to maintain consistent challenge
- **Game State Management** - Pause, resume, settings menu, and game over screens
- **Boundary Detection** - Game over when bird exits screen bounds
- **Responsive UI** - Clean interface with multiple menu panels
- **Collision Physics** - Realistic bird physics and collision detection

### Core Mechanics
- **Space Bar Control** - Press spacebar to make the bird flap
- **Gravity Simulation** - Bird falls naturally when not flapping
- **Score System** - Earn points by passing through pipes
- **Speed Progression** - Base speed: 5 units/s, Max speed: 15 units/s, Increase rate: 0.2 per point

## 🚀 Planned Features

### Phase 1: Polish (High Impact, Quick Wins)
- ✅ High Score System (PlayerPrefs)
- ✅ Sound Effects (flap, collision, score)
- ✅ Bird Rotation Animation (based on velocity)
- ✅ Enhanced Death Screen (stats display)
- ✅ TextMeshPro Font Upgrade

### Phase 2: Content
- 🎯 Achievement System
- 🎨 Visual Themes & Skins
- 📚 Tutorial for First-Time Players
- 📊 Statistics Screen

### Phase 3: Advanced
- ⚡ Power-ups System
- 🎲 Alternative Game Modes (Time Attack, Survival, Zen)
- 🏆 Online Leaderboards

## 🛠️ Technical Details

### Architecture
- **GameManager** - Singleton pattern for game state management
- **UIManager** - Centralized UI button event handling
- **LogicScript** - Score tracking and game over logic
- **Birdscript** - Player movement, collision, and boundary detection
- **PipeMoveScript** - Dynamic pipe movement with speed scaling
- **PipeSpawnerScript** - Adaptive pipe spawning system

### Key Systems
- **State Machine** - Menu, Playing, Paused, GameOver states
- **Event System** - OnGameStateChanged event for state transitions
- **Object Management** - Automatic pipe cleanup at screen boundaries
- **Scene Persistence** - DontDestroyOnLoad for game manager

## 📦 Installation

### Prerequisites
- Unity 2022.3 LTS or higher
- .NET Framework 4.x equivalent

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/AE707/FlarpyBloarb.git
   ```

2. Open the project in Unity Hub

3. Open the main scene: `Assets/Scenes/SampleScene.unity`

4. Press Play in Unity Editor to start

### Building
1. Go to **File → Build Settings**
2. Select your target platform (PC, Mac, Linux)
3. Click **Build** and choose output directory
4. Run the executable

## 🎯 How to Play

1. **Start Game** - Click "Play" on the main menu
2. **Control** - Press **Spacebar** to flap
3. **Survive** - Navigate through pipes without colliding
4. **Score** - Earn points by passing through pipe gaps
5. **Pause** - Press **ESC** during gameplay
6. **Settings** - Press **M** to open settings menu

## 🎨 Credits

### Assets Used
- **Bird Sprite** - unitytut-birdbody.png
- **Pipe Sprite** - PikPng.com_mario-pipe-png
- **UI Icons** - PikPng.com (play, close icons)

### Development
- **Developer** - [AE707](https://github.com/AE707)
- **Engine** - Unity 2022.3 LTS
- **Language** - C# 12.0

## 📝 Version History

### v1.0.0 (Current)
- ✅ Core gameplay mechanics
- ✅ Game state management system
- ✅ Progressive difficulty scaling
- ✅ UI panel management
- ✅ Boundary detection
- ✅ Dynamic pipe spawning

## 🤝 Contributing

Contributions are welcome! Feel free to:
- Report bugs via Issues
- Suggest features
- Submit pull requests

### Development Guidelines
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔗 Links

- **Repository** - [github.com/AE707/FlarpyBloarb](https://github.com/AE707/FlarpyBloarb)
- **Issues** - [Report a Bug](https://github.com/AE707/FlarpyBloarb/issues)
- **Developer** - [@AE707](https://github.com/AE707)

## 🌟 Acknowledgments

- Inspired by the original Flappy Bird by Dong Nguyen
- Unity community for tutorials and resources
- All contributors and testers

---

Made with ❤️ using Unity
