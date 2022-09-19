# What can Unity build?

For additional details, see the [References](#references) at the bottom of this document.


## Terminology

* **Sprite:** Two-dimensional bitmap integrated into a scene. This term has been standardized to mean a 2D image.

* **Bitmap:** is an array of bits that specify the color of each pixel in a rectangular array of pixels. The number of bits representing each pixel determins the number of colors that can be assigned to that pixel.

## 3D

Both 3D modes are better suited to the Editor in 3D mode, due to working 3D models and assets. In 3D, materials and textures are rendered on GameObject surfaces.

### Full 3D

* Three-dimensional geometry.

* Generally rendered in perspective, implying larger objects closer to the camera.

* Free perspective mode moving camera.

### Orthographic 3D or 2.5D

* Three-dimensional geometry.

* Orthographic camera instead of perspective, resulting in bird's-eye view.

* For 2.5D games, switch the Camera and Scene view to Orthographic.

    * Camera: Switch the **Projection** parameter of the **Camera** component to **Ortographic**.

    * Scene: Click the center of the **Scene Gizmo** to toggle between Perspective and Isometric (i.e., Orthographic).

## 3D Settings

* Imported images are NOT assumed to be sprites.

---

## 2D

There are various possible approaches for 2D games.

### Full 2D

* Flat graphics (aka. Sprites) --> No 3D geometry. Drawn as flat images.

* Camera is in orthographic mode, as opposed to perspective.

* Start editor in 2D mode


### 2D Gameplay with 3D Graphics (2.5D)

* Usage of 3D geometry for environment and characters.

* Gameplay restricted to two dimensions.

* 3D perspective camera.

* 3D effect is stylistic as opposed to functional.

* Start editor in 3D mode, since the game is built of 3D objects.


### 2D Gameplay and Graphics with Perspective Camera

* Both gameplay and graphics (i.e., geometry) are in 2D.

* Perspective camera to achieve parallax scrolling. Graphics are arranged at different distances from the camera.

* To achieve this gameplay:

    * Use editor in 2D mode.

    * Change Camera's Projection mode to **Perspective** in the camera object.
    
    * Change Scene View mode to 3D by clicking on the **Scene Gizmo** in the Scene panel.

---

> To switch from 2D to 3D mode or vice versa, go to" *Edit > Project Settings... > Editor > Default Behavior.


## References

[2D or 3D Projects](https://docs.unity3d.com/Manual/2Dor3D.html)

[2D and 3D Settings](https://docs.unity3d.com/Manual/2DAnd3DModeSettings.html)
