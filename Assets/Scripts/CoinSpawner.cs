using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    public bool IsEmpty { get; private set;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            IsEmpty = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            IsEmpty = false;
    }

    public void Spawn()
    {
        Instantiate(_coin, transform.position, Quaternion.identity);
    }
}
