using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    /*
     * Triggers are detected by the Collider component when the "Is Trigger"
     * bool is enabled. This won't cause a collision in the sense that it won't
     * stop nor affect the object that collided against the trigger. It will
     * however trigger specified actions. In this case, it is triggering the
     * power up behavior. A trigger may however be implemented in a switch to
     * open a door, or drop a chest, etc.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision was against the player.
        if (collision.CompareTag("Player"))
        {
            // Trigger the Player's power up.
            collision.gameObject.GetComponent<PlayerBehavior>().TogglePowerUp();

            // Destroy the coin after it has been picked up.
            Destroy(gameObject);
        }
    }
}
