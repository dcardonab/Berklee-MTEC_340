# GUI

* Canvas: The `Canvas` is the basic component of Unity UI. It generates meshes that represent the UI Elements placed on it (e.g., text and buttons), regenerates the meshes when UI Elements change, and issues draw calls to the GPU so that the UI is actually displayed.

    * Event System


## Multiple Resolutions

Oftentimes, you will find that you UI elements will not be properly positioned on different screen resolutions. To avoid this and automatically scale them, change the `UI Scale Mode` to `Scale With Screen Size` in the `Canvas Scaler` component of the `Canvas` object.

> Canvas > Canvas Scaler > UI Scale Mode > Scale With Screen Size
