using UnityEngine;
using UnityEngine.Networking;

namespace Card
{
    public class CardTextureController : MonoBehaviour
    {
        public Sprite CardBack;
        
        private void Start()
        {
            if (!transform.parent.GetComponent<NetworkIdentity>().isServer) return;
            GetComponent<SpriteRenderer>().sprite = CardBack;
            foreach (var mesh in GetComponentsInChildren<TextMesh>())
            {
                mesh.text = "";
            }
        }
    }
}