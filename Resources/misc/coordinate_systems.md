# Coordinate Systems

## Reverse Cartesian

### Programs/Frameworks using Reverse Cartesian Coordinates

* Processing

    * For [P3D](https://processing.org/tutorials/p3d), Z points towards the camera.

* LoVE2D


## Right-Handed Vs. Left-Handed

### Programs/Frameworks using Right-Handed Coordinates

* OpenGL - Y-Up

### Programs/Frameworks using Right-Handed Z-Up Coordinates

* Blender - Z-Up

* Maya - Y-Up

* Subtance Painter - Y-Up

* Unity - Y-Up


## Tips

* You can swap the direction of an axis implementing a matrix multiplication transformation. For instance, to swap frtom left-handed to right-handed or from right-handed to left-handed coordinate system, change the direction of the X-axis, using the following transformation matrix (note that any axis can be swapped applying this transformation to the Model-View Matrix):

> $\begin{bmatrix}
-1 & 0 & 0 & 0\\
0 & 1 & 0 & 0\\
0 & 0 & 1 & 0\\
0 & 0 & 0 & 1
\end{bmatrix}$