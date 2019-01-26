using System;
using UnityEngine;

[Serializable]
public class CardData : MonoBehaviour
{
    [SerializeField] private string _description;
    [SerializeField] private string _title;

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
