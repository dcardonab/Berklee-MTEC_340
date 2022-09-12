# Unity UI

## Panels

Panels are the small windows that are found in Unity. There are 6 different panels in Unity:

1. Toolbar
    * Used to handle login info, services, play/pause the game, see undo history, search, toggle render layers and masks, and select layouts.
    > Note that contrary to the textbook, recent versions of the Unity have moved the object modifiers to the Scene panel.

2. Scene / Game
    * Scene: Used to place objects in the 2D or 3D space.
    * Game: When hitting the `Play` button, the game panel renders the Scene view and all the programmed interactions, simulating what the game will look like.

3. Hierarchy
    * Shows scenes and objects.
    * Parenting: Groups objects as children, and allows them to be controlled by the parent’s transforms.

4. Console
    * Displays errors, warnings, and other messages via `Debug.Log()`.

5. Project
    * Folder and File organizer displaying all the assets in the Unity project.

6. Inspector
    * Displays components of a game object and allows editing the properties of those components.
    * Note that every component will have a `?` symbol on the top right to directly access the Unity reference manual page for that component.

> **Tip** - Double clicking on a panel tab maximizes that panel to fit the Unity application window.

More info: [Unity Manual - Using the Editor](https://docs.unity3d.com/Manual/UsingTheEditor.html)

## Layouts

A layout is an arrangement of Panels in the Unity application window.

Use **Window > Layouts** or the dropdown menus in the top right of the Unity application window for different panel arrangements.

## Tips

* To center an object in the Scene panel:
    * Select object in the hierarchy.
    * Move cursor over the Scene panel.
    * Press the `F` key.