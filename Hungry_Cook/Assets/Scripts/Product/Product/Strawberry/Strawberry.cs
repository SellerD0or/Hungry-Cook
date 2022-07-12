using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Strawberry : Product, ICut
{
     private Sprite _overcookedSignSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _sign;
    [SerializeField] private Sprite _cutSprite;
    [SerializeField] private string _name;

    public override string Name { get => _name; set => _name = value; }

    [SerializeField] private Sprite _sprite;

    public override Sprite Sprite { get => _sprite; set => _sprite = value; }
    public override SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
    public override SpriteRenderer Sign { get => _sign; set => _sign = value; }
    public override Sprite OvercookedSignSprite { get => _overcookedSignSprite; set => _overcookedSignSprite = value; }
   private void Start() 
    {
        SpriteRenderer.sprite = Sprite;
        DictionaryOfSprites.Add("C", _cutSprite);
        Rigidbody = GetComponent<Rigidbody2D>();
        IMovable = GetComponent<IMovable>();
        IAnimated = GetComponent<IAnimated>();
    }
    public void Cut()
    {
       if (CanGrillAndCut("C"))
       {
         AddName("C");
       }
    }

    public void Overbrew()
    {
        _spriteRenderer.color = OverbrewColor;
        TurnOnOvercookSign();
    }

    public void Overfry()
    {
        _spriteRenderer.color = OverfryColor;
        TurnOnOvercookSign();
    }
    private void TurnOnOvercookSign()
    {
        MakeOvercookedProduct();
        Sign.gameObject.SetActive(true);
        _name ="";
        _name += "N";
    }
}
