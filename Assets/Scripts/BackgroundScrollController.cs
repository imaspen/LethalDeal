using UnityEngine;

public class BackgroundScrollController : MonoBehaviour
{
    private Renderer _renderer;
    public float Speed;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        var offset = new Vector2(0, Time.time * -Speed);
        _renderer.material.mainTextureOffset = offset;
    }
}