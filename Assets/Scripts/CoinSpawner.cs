using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    public bool IsCoinExist { get; private set;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin;

        if (collision.gameObject.TryGetComponent<Coin>(out coin))
        {
            IsCoinExist = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Coin coin;

        if (collision.gameObject.TryGetComponent<Coin>(out coin))
        {
            IsCoinExist = false;
        }
    }

    public void SpawnCoin()
    {
        Instantiate(_coin, transform.position, Quaternion.identity);
    }
}
