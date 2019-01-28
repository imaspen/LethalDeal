using System;
using UnityEngine;

namespace Card
{
    [Serializable]
    public class CardData : MonoBehaviour
    {
        [SerializeField] private string _description;
        [SerializeField] private string _title;
        [SerializeField] private GameObject _spawns;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                BroadcastMessage("OnCardTextChanged");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                BroadcastMessage("OnCardTextChanged");
            }
        }

        public GameObject Spawns
        {
            get { return _spawns; }
            set { _spawns = value; }
        }

        private void Start()
        {
            LoadJson("testcard");
        }

        public void LoadJson(string cardName)
        {
            JsonUtility.FromJsonOverwrite(
                Resources.Load<TextAsset>("Cards/" + cardName).text, this
            );
            BroadcastMessage("OnCardTextChanged");
        }
    }
}
