using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Card
{
    [Serializable]
    public class CardData : NetworkBehaviour
    {
        [SyncVar] [SerializeField] private string _description;
        [SyncVar] [SerializeField] private string _emitter;
        [SyncVar] [SerializeField] private string _spawns;
        [SyncVar] [SerializeField] private string _title;

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

        public string Spawns
        {
            get { return _spawns; }
            set { _spawns = value; }
        }

        public string Emitter
        {
            get { return _emitter; }
            set { _emitter = value; }
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