# Conceptual Background

## Scene Graph

An important concept in game engine development and in computer graphics is a Scene Graph. A scene graph dictates the interrelationship between objects, emphasizing hierarchical relationships that influence rendering (parent-child relationships), as well as relative placement in 3D space (children's transforms relative to the parent's position).

Scene graphs follow a tree like structure, each element in that will be rendered has a node assigned to it. Each node has a parent node (except for the root) and a number of child nodes (except for the leaves, which are nodes with no children).

Each node in the scene graph contains information about its graphical representation, generally represented as a pointer to a mesh, as well as spatial information in relation to its parent node. This is referred to as a *Local Transform*. This is achieved using a transformation matrix (similar to going from local space to world space) that translates the mesh in relation to its parent's node (local space to its parent's space). This means that **all transformation information cascades down the scene graph**.

It is necessary to traverse the graph to render the scene. This is so that we can apply each node's world transformation for usage in the vertex shader. This process starts from the root node, where the world transformation for each node can be calculated by multiplying a node's local transformation matrix with the world transformation of its parent. This process continues until reaching the leaf nodes.

To accelerate this process, it is optimal to store the world and local transformations of an object as we descend down the tree. This allows determining the world matrix of any object with a single multiplication: the child's local transform with the world transform of its parent. This prevents having to traverse the entire tree when a world matrix node was needed, which can be expensive for deeper and more complex scenes.

There are also transition nodes, which do not necessarily point to a mesh, but provide added functionality. E.g., the axles of a car may not need to be rendered, but they may be rotated to rotate the direction of both wheels independently.

State nodes also exist, which do not point to a mesh as well. These are useful for grouping children nodes that might need to use a specific shader, or a specific rendering options. E.g., a glowing armor in a character.


# Unity Anatomy

The different gameplay elements in Unity show up in the Hierarchy panel. The basic root element in Unity is called a Scene. 


## Scene

Technically speaking, each scene will correspond to the root node of a graph, containing all the objects and elements that make up that scene as children.

Scenes are useful for separating the content of different moments in our game, such as the opening scene, the play scene, and the game over scene. Each scene contains all of the objects that are relevant to a portion of our game.

Complex games may also use a scene per level, given that each one will require its own environments, characters, obstacles, decorations, and UI.

Any number of scenes can be created in a project.

When creating a new scene, it is possible to specify whether a template should be used, or if an empty scene is desired.

To create a new scene: **File > New Scene** or **CMD + N**.

> REF: https://docs.unity3d.com/Manual/CreatingScenes.html


## GameObjects

## Components
