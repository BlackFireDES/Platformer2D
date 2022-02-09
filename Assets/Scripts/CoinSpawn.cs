using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    private CoinSpawner[] _coinSpawners;
    private bool _isWorking;

    private void Start()
    {
        _coinSpawners = gameObject.GetComponentsInChildren<CoinSpawner>();
        _isWorking = true;
        StartCoroutine(SpawnCoin());        
    }

    private IEnumerator SpawnCoin()
    {
        while (_isWorking)
        {
            int index = Random.Range(0, _coinSpawners.Length);

            while (_coinSpawners[index].IsCoinExist == true)
            {
                index = Random.Range(0, _coinSpawners.Length);
                yield return new WaitForEndOfFrame();
            }
            _coinSpawners[index].SpawnCoin();

            yield return new WaitForSeconds(5);
        }
    }


}
