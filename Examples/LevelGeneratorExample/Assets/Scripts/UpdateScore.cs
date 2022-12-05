using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    private int m_score = 0;
    public int Score
    {
        get => m_score;
        set
        {
            m_score = value;
            GetComponent<TextMeshProUGUI>().text= $"Score: {m_score}";
        }
    }
}
