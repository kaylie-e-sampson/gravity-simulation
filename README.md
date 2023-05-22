# Earth & Moon Gravity Simulation

This project was created to experiment with gravity in outer space. First, I played around with simulating gravity by disabiling the "Use Gravity" Unity preset and applying my own gravity calculations based on Newtown's Laws of Physics. I was inspired by this video demonstrating how to [Simulate Gravity in Unity](https://www.youtube.com/watch?v=Ouu3D_VHx9o). From there, I worked independently to simulate the moon orbiting the earth (inspired by a CS1 lab, which was used as reference)!

<img width="748" alt="Screenshot 2023-05-22 at 4 37 46 AM" src="https://github.com/kaylie-e-sampson/gravity-simulation/assets/67167039/e9d9144a-d015-4bbb-9046-d928b3e05518">
<img width="748" alt="Screenshot 2023-05-22 at 4 37 46 AM" src="https://github.com/kaylie-e-sampson/gravity-simulation/assets/67167039/e58379ef-9cf1-47a3-a965-9415347824b9">

## Architecture
### Tech Stack 🥞
The app is built using Unity3D

#### Assets 📦
* [Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717)
* [Earth Model](https://assetstore.unity.com/packages/3d/environments/sci-fi/planet-earth-free-23399)
* [Moon Texture](https://www.reddit.com/r/Unity3D/comments/6sdq7s/i_just_made_a_seamless_lunar_surface_texture_you/)

### File Structure

```
├──[gravity-simulation]/              # root directory
|  └──[Assets]                        # all the assets
|     └──[Scenes]                     # the different scenes/versions of the project
|     └──[Scripts]                    # all the scripts used in the scenes
|     └──[Models]                     # all the 3D models used in the scenes
|     └──[Images]                     # all images used in the project
|  └──[Packages]/                     # all the packages used for the project
```

For more detailed documentation on our file structure and specific functions in the code, feel free to check the project files themselves.

#### Pre-requisites
1. Unity Hub: https://unity3d.com/get-unity/download
2. Visual Studio Code: https://code.visualstudio.com/download (optional, but good platform for writing scripts)

#### Development Setup Instructions
1. Fork/Clone the project.
2. Open the project with `Unity Hub` and make sure to use the correct Unity version (2020.3.18f1).

#### Building and Running
1. You can run it directly from Unity -- otherwise, you can build an executable and run it from there.

## Authors
* Kaylie Sampson '25, Developer
