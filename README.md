# 🐦 FlarpyBloarb

A Flappy Bird-inspired endless runner game built with Unity. Guide your bird through increasingly challenging obstacles and compete for the highest score!

![Unity](https://img.shields.io/badge/Unity-2022.3+-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-12.0-blue?logo=c-sharp)
![License](https://img.shields.io/badge/License-MIT-green)

## 🎮 Features

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
