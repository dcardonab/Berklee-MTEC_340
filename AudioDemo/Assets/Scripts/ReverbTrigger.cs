using UnityEngine;

public class ReverbTrigger : MonoBehaviour
{
    [SerializeField] ReverbCtrl reverbCtrl;
    [SerializeField] int triggerNr;

    void OnTriggerEnter(Collider other)
    {
        reverbCtrl.BlendSnapshots(triggerNr);
    }

    void OnTriggerExit(Collider other)
    {
        reverbCtrl.BlendSnapshots(0);
    }
}
