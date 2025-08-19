# Phototelectric-Simulator

This project simulates the Photoelectric Effect, a fundamental quantum physics phenomenon where electrons are emitted from a material when light of sufficient frequency strikes its surface.

- Work Function: Each material has a threshold frequency; only photons with energy greater than this work function can release electrons.

- Intensity: Higher light intensity means more photons → more emitted electrons (since photon–electron interactions are one-to-one).

- Kinetic Energy: Excess photon energy (beyond the work function) becomes the kinetic energy of the emitted electrons. Electrons deeper in the material may have less kinetic energy.

- The simulator provides an interactive, visual way to explore these concepts across different materials and light sources.

<img width="1332" alt="Screenshot" src="https://github.com/angelorosu/Phototelectric-Simulator/assets/83517901/5b497018-b104-4038-8ab6-7dc9ce00aacd">




## Architecture Overview MVVM


This project uses the Model–View–ViewModel (MVVM) pattern to keep the code clean, modular, and easy to extend.
- Model: Defines the core data and logic (e.g., electron objects with position and size). The model does not interact with the UI directly; it only exposes data to the ViewModel.
- ViewModel: Acts as the middle layer, exposing model data and methods to the view. It handles updates, commands, and events triggered by user interaction.
- View: The user interface layer that displays data in a user-friendly format and allows interaction (e.g., sliders for light frequency/intensity). The view abstracts away model details.
- This separation made the code more maintainable and allowed new features to be added with minimal friction.

<img width="483" alt="MVVM Architecture" src="https://github.com/angelorosu/Phototelectric-Simulator/assets/83517901/e29847ee-7f08-4f28-bffe-944c9cdc6ed3">

## Key Features

- Visual simulation of the photoelectric effect.
- Adjustable light frequency and intensity.
- Multiple materials with different work functions.
- MVVM architecture for clean separation of concerns.

## Getting Started

Clone the repository and open the solution in your preferred IDE.
Build and run the project to interact with the simulator.

## License

MIT License. Free to use, modify, and share.
