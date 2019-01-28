using UnityEngine;

namespace Card
{
    public class CardDragController : MonoBehaviour
    {
        private Animator _animator;
        private CardData _cardData;
        
        private bool _isDragging;
        private Vector3 _mouseOffset;

        private Vector3 _startPosition;
    
        public float DistanceToPlay;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _cardData = GetComponent<CardData>();
        }

        private void OnMouseDown()
        {
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
                DoCard();
            else
                transform.parent.position = _startPosition;
        }

        private void OnMouseDrag()
        {
            if (!_isDragging) return;
            if (Camera.main == null) return;
            var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)) +
                           _mouseOffset;
            transform.parent.position = mousePos;
        }

        private void DoCard()
        {
            Instantiate(_cardData.Spawns);
            Destroy(transform.parent.gameObject);
        }
    }
}
