using Dealer;
using Projectile;
using UnityEngine;
using UnityEngine.Networking;

namespace Card
{
    public class CardDragController : MonoBehaviour
    {
        private Animator _animator;
        private DealerHandController _dealerHandController;
        private NetworkIdentity _networkIdentity;
        
        private bool _isDragging;
        private Vector3 _mouseOffset;

        private Vector3 _startPosition;

        public float DistanceToPlay;

        private void Start()
        {
            transform.parent.SetParent(GameObject.Find("Hand").transform);
            _networkIdentity = transform.parent.GetComponent<NetworkIdentity>();
            if (!_networkIdentity.hasAuthority) return;
            _animator = GetComponent<Animator>();
            _dealerHandController = transform.parent.parent.gameObject.GetComponent<DealerHandController>();
        }

        private void OnMouseDown()
        {
            if (!_networkIdentity.hasAuthority) return;
            _animator.SetBool("MouseDragging", true);
            _isDragging = true;
            _startPosition = transform.parent.position;
            if (Camera.main != null)
                _mouseOffset = _startPosition -
                               Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                   Input.mousePosition.y));
        }

        private void OnMouseUp()
        {
            if (!_networkIdentity.hasAuthority) return;
            _animator.SetBool("MouseDragging", false);
            _isDragging = false;
            if (transform.parent.position.y > _startPosition.y + DistanceToPlay)
                _dealerHandController.PlayCard(transform.parent.GetComponent<CardData>(), _startPosition.z);
            ResetCard();
        }

        private void OnMouseDrag()
        {
            if (!_networkIdentity.hasAuthority) return;
            if (!_isDragging) return;
            if (Camera.main == null) return;
            var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)) +
                           _mouseOffset;
            transform.parent.position = mousePos;
        }

        private void ResetCard()
        {
            transform.parent.position = _startPosition;
        }
    }
}
