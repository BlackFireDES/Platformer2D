using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class —oin—ollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerDragon>(out PlayerDragon playerDragon))
        {
            Destroy(gameObject);
        }
    }
}
