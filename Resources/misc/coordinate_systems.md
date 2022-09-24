# Coordinate Systems

## Reverse Cartesian

* The origin is in the top left.

* X-Axis points to the right.

* Y-Axis points down.

### Programs/Frameworks using Reverse Cartesian Coordinates

* Processing

    * For [P3D](https://processing.org/tutorials/p3d), the Z-axis points towards the camera (i.e., left handed system, Y-axis points down).

* LoVE2D


---


## Right-Handed and Left-Handed

To build a handed coordinate system with either hand:

1. Do thumbs-up, pointing your thumb upwards.
2. Extend your index finger, pointing it forwards.
3. Extend you middle finger so it's perpendicular to the other two fingers.

Your index will represent the X-axis, your middle finger will represent the Y-axis, and your thumb will represent the Z-axis.

Maintaining this structure, rotate your hand so that the X-axis (i.e., index finger) is pointing towards the right. If you perform a second rotation so that the Y-axis (i.e., middle finger) is pointing upwards, you will notice that the Z-axis (i.e., thumb) will point outwards (i.e., away from you) in left-handed systems, and inwards (i.e., towards you) in right-handed systems.


### Programs/Frameworks using Left-Handed Coordinates

* Unity
    * **X-Axis** points to the right.
    * **Y-Axis** points up.
    * **Z-Axis** points away from the initial camera, i.e., 90-degree counter-clockwise rotation from the X-axis.

* OpenGL - Y-Up
    * OpenGL is left-handed *window space*. However, it is right handed in *object space* and *world space*.
        * [Reference and explanation](https://stackoverflow.com/questions/4124041/is-opengl-coordinate-system-left-handed-or-right-handed).

### Programs/Frameworks using Right-Handed Coordinates

#### Y-Up

* Maya - Y-Up

* Subtance Painter - Y-Up

* Blender - Z-Up


---

## Tips

* You can swap the direction of an axis implementing a matrix multiplication transformation. For instance, to swap from left-handed to right-handed or from right-handed to left-handed coordinate system, change the direction of the X-axis, using the following transformation matrix (note that any axis can be swapped applying this transformation to the Model-View Matrix):

$$\begin{bmatrix}
-1 & 0 & 0 & 0\\
0 & 1 & 0 & 0\\
0 & 0 & 1 & 0\\
0 & 0 & 0 & 1
\end{bmatrix}$$
