using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] private GameObject StartText;
    [SerializeField] private GameObject MovingTrigger;
    [SerializeField] private GameObject MovingText;

    private void OnTriggerEnter(Collider other)
    {
        StartText.SetActive(false);
        MovingText.SetActive(true);
        MovingTrigger.SetActive(false);
    }
}
