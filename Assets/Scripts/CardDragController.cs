using UnityEngine;

public class CardDragController : MonoBehaviour
{
    private Animator _animator;
    private bool _isDragging;
    private Vector3 _mouseOffset;

    private Vector3 _startPosition;
    public float DistanceToPlay;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        Debug.Log("hello");
        _animator.SetBool("MouseDragging", true);
        _isDragging = true;
        _startPosition = transform.parent.position;
        if (Camera.main != null)
            _mouseOffset = _startPosition -
                           Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseUp()
    {
        _animator.SetBool("MouseDragging", false);
        _isDragging = false;
        if (transform.parent.position.y > _startPosition.y + DistanceToPlay)
            Destroy(transform.parent.gameObject);
        else
            transform.parent.position = _startPosition;
    }

    private void OnMouseDrag()
    {
        if (!_isDragging) return;
        var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)) +
                       _mouseOffset;
        Debug.Log(mousePos);
        transform.parent.position = mousePos;
    }
}