using UnityEngine;

public static class Utilities
{
    public static float SetYLimit(Camera cam, SpriteRenderer renderer) {
        Vector3 screenTop = new Vector3(0, cam.pixelHeight, 0);
        Vector3 screenTopInUnits = cam.ScreenToWorldPoint(screenTop);
        float heightInUnits = screenTopInUnits.y;

        float spriteHeight = renderer.bounds.size.y;

        return heightInUnits - spriteHeight * 0.5f;
    }
}
