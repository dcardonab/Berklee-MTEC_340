// Code adapted from Harvard CS50 game development course,
// as taught by Colton Ogden and David Malan.

using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Prefabs
    // Each prefab has 1,1,1 dimensions and will generate a 3D tilemap.
    // Used to position the character at the beginning of the labyrinth
    [SerializeField] CharacterController m_charController;

    // The pickup will be scaled down once it is instantiated.
    [SerializeField] GameObject m_floorPrefab;
    [SerializeField] GameObject m_wallPrefab;
    [SerializeField] GameObject m_ceilingPrefab;
    [SerializeField] GameObject m_pickupPrefab;

    // Parent objects
    [SerializeField] Transform m_floorParent;
    [SerializeField] Transform m_wallParent;
    [SerializeField] Transform m_ceilingParent;

    // Avoid generating ceiling for debugging
    // The height of the ceiling can also be set.
    [SerializeField] bool m_genCeiling = true;
    [SerializeField] int m_height = 9;

    // Size of each dimension in the 2D map
    [SerializeField] int m_levelSize;

    // The random walk will carve out a path of this length minimum
    [SerializeField] int m_minTilesToRemove = 50;

    // Number of holes in the floor
    [SerializeField] int m_numHoles = 4;

    // 2D array to represent the level outline
    private int[,] m_levelData;

    // Values used to start and end the walk algorithm.
    // The are initialized as member variables to instantiate the pickup
    // at the end.
    private int m_posX = 4, m_posY = 1;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    void Reset()
    {
        m_levelData = GenLevelData();
        InstantiatePrefabs();
    }

    // The level will be represented as a 2D array using 0, 1, and -1.
    // The labyrinth's path will be carved using the random walk algorithm.
    //     1 - Walls
    //     0 - Floor
    //    -1 - Gaps
    int[,] GenLevelData()
    {
        // Create a square based on the levelSize
        int[,] data = new int[m_levelSize, m_levelSize];

        // Intialize all the level to walls
        for (int y = 0; y < m_levelSize; y++)
        {
            for (int x = 0; x < m_levelSize; x++)
            {
                data[y, x] = 1;
            }
        }

        // Number of steps
        int tilesConsumed = 0;

        // Random walk
        while (tilesConsumed < m_minTilesToRemove)
        {
            int xDir = 0, yDir = 0;

            // Pick only one direction to avoid diagonals
            if (Random.value < 0.5)
                xDir = Random.value < 0.5 ? 1 : -1;
            else
                yDir = Random.value < 0.5 ? 1 : -1;

            // Move by a random number of spaces in the given direction
            int numSpacesToMove = Random.Range(1, m_levelSize - 1);

            // Remove the specified number of tiles on the set direction
            for (int i = 0; i < numSpacesToMove; i++)
            {
                // Clamp values between 1 and size - 2 to ensure that there
                // is a margin around the edge of the generated labyrinth.
                m_posX = Mathf.Clamp(m_posX + xDir, 1, m_levelSize - 2);
                m_posY = Mathf.Clamp(m_posY + yDir, 1, m_levelSize - 2);

                // Update tile if it is set to a wall
                if (data[m_posY, m_posX] == 1)
                {
                    // 5% possibility of inserting holes.
                    // Note that the Random.value will not be calculated
                    // once all the holes have been placed, given that it
                    // is calculated only when the first condition evaluates
                    // to true.
                    if (m_numHoles != 0 && Random.value < 0.05)
                    {
                        data[m_posY, m_posX] = -1;
                        m_numHoles--;
                    }
                    else
                        data[m_posY, m_posX] = 0;

                    // As per the while loop, the random walker will stop once
                    // the number of tiles consumed has surpassed the set
                    // minumum number of tiles that are to be consumed.
                    tilesConsumed++;
                }
            }
        }

        return data;
    }

    void InstantiatePrefabs()
    {
        // Create level from generated data
        for (int z = 0; z < m_levelSize; z++)
        {
            for (int x = 0; x < m_levelSize; x++)
            {
                switch (m_levelData[z, x])
                {
                    // Instantiate the floor when the contained value is 0
                    case 0:
                        Instantiate(
                            m_floorPrefab,
                            new Vector3(x, 0, z),
                            Quaternion.identity,
                            m_floorParent
                        );
                        break;

                    // Instantiate walls when the contained value is 1
                    case 1:
                        for (int i = 1; i < m_height; i++)
                            Instantiate(
                                m_wallPrefab,
                                new Vector3(x, i, z),
                                Quaternion.identity,
                                m_wallParent
                            );
                        break;
                    // Note that the case for the hole will not be evaluated,
                    // as that outcome won't instantiate anything
                    default:
                        break;
                }

                if (m_genCeiling)
                    Instantiate(
                        m_ceilingPrefab,
                        new Vector3(x, m_height, z),
                        Quaternion.identity,
                        m_ceilingParent
                    );
            }
        }

        // Instantiate pickup and scale it down.
        GameObject pickup = Instantiate(
            m_pickupPrefab,
            new Vector3(m_posX, 1, m_posY),
            Quaternion.identity
        );
        pickup.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        // Move player to the first available space.
        for (int z = 0; z < m_levelSize; z++)
        {
            for (int x = 0; x < m_levelSize; x++)
            {
                if (m_levelData[z, x] == 0)
                {
                    m_charController.transform.SetPositionAndRotation(
                        new Vector3(x, 1, z), Quaternion.identity
                    );

                    // Complete level generation once the player has been set.
                    return;
                }
            }
        }

    }
}
