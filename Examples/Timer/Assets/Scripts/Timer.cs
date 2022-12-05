using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float spawnTime = 100f;
    [SerializeField] TextMeshProUGUI timerGUI;

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            // SpawnAsteroid();

            spawnTime += 100f;
        }

        DisplayTime(spawnTime);
    }

    private void DisplayTime(float time)
    {
        if (time < 0)
            time = 0;

        time += 1;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerGUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        return;
    }
}
