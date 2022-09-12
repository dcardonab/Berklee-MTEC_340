# What can Unity build?

## Terminology

* **Sprite:** Two-dimensional bitmap integrated into a scene. This term has been standardized to mean a 2D image.

* **Bitmap:** is an array of bits that specify the color of each pixel in a rectangular array of pixels. The number of bits representing each pixel determins the number of colors that can be assigned to that pixel.

## 3D

Both 3D modes are better suited to the Editor in 3D mode, due to working 3D models and assets. In 3D, materials and textures are rendered on GameObject surfaces.

### Full 3D

* Three-dimensional geometry.

* Generally rendered in perspective, implying larger objects closer to the camera.

* Free moving camera.

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

## References

[2D or 3D Projects](https://docs.unity3d.com/Manual/2Dor3D.html)

[2D and 3D Settings](https://docs.unity3d.com/Manual/2DAnd3DModeSettings.html)
