using System;
using UnityEngine;

public class WifeTrigger : MonoBehaviour
{
    public GameObject dogMoment;
    public GameObject ostanovkaTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        dogMoment.SetActive(true);
        ostanovkaTrigger.SetActive(true);
    }
}
