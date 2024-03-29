using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > 1)
            _imagePositionX = 0;

        var rect = _image.uvRect;
        _image.uvRect = new Rect(_imagePositionX, rect.width, rect.width, rect.height);
    }
}
