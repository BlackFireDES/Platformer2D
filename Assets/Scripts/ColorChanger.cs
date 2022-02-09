using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _changeTime;

    private bool _isWorking;

    private void Start()
    {
        _isWorking = true;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        int index = 0;

        while (_isWorking)
        {
            float timeElapsed = 0;
            Vector3 colorDifference = GetColorDifference(_sprite.color, _colors[index]);

            while(timeElapsed <= _changeTime)
            {
                timeElapsed += Time.deltaTime;
                _sprite.color -= new Color(colorDifference.x / _changeTime, colorDifference.y / _changeTime, colorDifference.z / _changeTime, 0) * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            timeElapsed = 0;
            index++;

            if (index == _colors.Length)
                index = 0;
        }
    }

    private Vector3 GetColorDifference(Color color1, Color color2)
    {
        return new Vector3(color1.r - color2.r, color1.g - color2.g, color1.b - color2.b);
    }
}
