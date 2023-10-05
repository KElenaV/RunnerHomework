using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Life : MonoBehaviour
{
    private float _fillDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void Init(float fillDuration)
    {
        _fillDuration = fillDuration;
    }

    public void Fill()
    {
        StartCoroutine(Filling(0, 1, ToFill));
    }

    

    public void Empty()
    {
        StartCoroutine(Filling(1, 0, ToEmpty));
    }

    private IEnumerator Filling(float startValue, float endValue, UnityAction<float> finalAction)
    {
        float elapsedTime = 0;

        while(elapsedTime <= _fillDuration)
        {
            elapsedTime += Time.deltaTime;
            float interpolation = elapsedTime / _fillDuration;

            _image.fillAmount = Mathf.Lerp(startValue, endValue, interpolation);

            yield return null;
        }

        finalAction?.Invoke(endValue);
    }

    private void ToEmpty(float emptyValue)
    {
        _image.fillAmount = emptyValue;
        Destroy(gameObject);
    }

    private void ToFill(float fillValue)
    {
        _image.fillAmount = fillValue;
    }
}

