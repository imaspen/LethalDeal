using Dealer;
using UnityEngine;

public class DealerClockController : MonoBehaviour
{
    private DealerHandController _dealerHandController;
    private SpriteRenderer _renderer;
    public Sprite[] ClockSprites;

    private void Start()
    {
        _dealerHandController = transform.parent.GetComponentInChildren<DealerHandController>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var cooldown = _dealerHandController.Cooldown;
        if (cooldown <= 0)
            _renderer.sprite = ClockSprites[8];
        else if (cooldown <= .25)
            _renderer.sprite = ClockSprites[7];
        else if (cooldown <= .5)
            _renderer.sprite = ClockSprites[6];
        else if (cooldown <= .75)
            _renderer.sprite = ClockSprites[5];
        else if (cooldown <= 1)
            _renderer.sprite = ClockSprites[4];
        else if (cooldown <= 1.25)
            _renderer.sprite = ClockSprites[3];
        else if (cooldown <= 1.5)
            _renderer.sprite = ClockSprites[2];
        else if (cooldown <= 1.75)
            _renderer.sprite = ClockSprites[1];
        else
            _renderer.sprite = ClockSprites[0];
    }
}