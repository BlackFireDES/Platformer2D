using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnSystem : MonoBehaviour
{
    private CoinSpawner[] _spawners;
    private bool _isWorking;

    private void Start()
    {
        _spawners = gameObject.GetComponentsInChildren<CoinSpawner>();
        _isWorking = true;
        StartCoroutine(Spawn());        
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(5);
        while (_isWorking)
        {
            int index = Random.Range(0, _spawners.Length);

            while (_spawners[index].IsEmpty == true)
            {
                index = Random.Range(0, _spawners.Length);
                yield return new WaitForEndOfFrame();
            }
            _spawners[index].Spawn();

            yield return  waitForSeconds;
        }
    }


}
