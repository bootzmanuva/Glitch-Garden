using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
    }
}
