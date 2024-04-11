using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] private Transform point;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.isTrigger == false)
        {
            col.gameObject.GetComponent<Player>().UpdateCheckPoint(point);
        }
    }
}
