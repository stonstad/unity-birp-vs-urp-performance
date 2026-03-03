# BIRP vs URP: Multi-Camera Performance Comparison
Compares BIRP vs URP Pipeline Performance across Low-End and High-End GPUs with a Multiple Camera Configuration

## Test Setup

#### Build
* Unity 6000.3.10f1 LTS (Latest)
* DirectX 11 and DirectX 12
* IL2CPP .NET Standard 2.1
* Release Build w/o Debugging
* Frame Timing Enabled

#### Scripts
*  CPUI/GPU Frame Timing ([Script](https://github.com/stonstad/unity-birp-vs-urp-performance/blob/main/CameraOverhead-BIRP/Assets/FrameTimingScript.cs))

## Scene

#### Cameras
* 2 Camera Stacks (Base + Overlay). 
* 1 Stacked Camera with Render Texture Output (Base + Overlay)
* Base Cameras Render Sky
* Overlay Cameras Render Depth

#### Game Objects
* 1 Terrain Mesh (4096x4096 Base Texture Resolution)
* 1 Directional Light

#### Rendering
* 1920x1080 Resolution
* Full Screen Window
* VSync Disabled
* No Post-Processing

## Methodology
* First Samples Ignored
* One Sample Per Second

## Results 
* Raw Log Files with Frame Timing ([Link](https://github.com/stonstad/unity-birp-vs-urp-performance/tree/main/Results))
* Summary ([Link](https://github.com/stonstad/unity-birp-vs-urp-performance/raw/refs/heads/main/Results/Summary.xlsx))

CPU, GPU, and Total Frame Timing


Percentage Change


Data Visualized


Frame Rate


Build Time





