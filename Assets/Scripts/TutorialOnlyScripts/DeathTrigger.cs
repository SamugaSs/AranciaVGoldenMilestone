using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject MovingText;
    [SerializeField] private GameObject AirSpindashText;

    private void OnTriggerEnter(Collider other)
    {
        MovingText.SetActive(false);
        AirSpindashText.SetActive(true);
    }
}
