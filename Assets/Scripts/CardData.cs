using System;
using System.IO;
using UnityEngine;

[Serializable]
public class CardData : MonoBehaviour
{
    [SerializeField] private string _name;

    [SerializeField] private string _description;

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
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