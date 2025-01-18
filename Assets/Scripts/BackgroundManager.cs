using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] GameObject normalBackground;
    private SpriteRenderer[] normalSprites;
    [SerializeField] GameObject nightmareBackground;
    private SpriteRenderer[] nightmareSprites;

    private void Start()
    {
        GameManager.instance.onNightmare += ChangeToNightmare;
        GameManager.instance.onNightmareFinish += ChangeToNormal;
        normalSprites = normalBackground.GetComponentsInChildren<SpriteRenderer>();
        nightmareSprites = nightmareBackground.GetComponentsInChildren<SpriteRenderer>();
    }
    public void ChangeToNightmare()
    {
        foreach(SpriteRenderer sprite in normalSprites)
        {
            //lerp alpha
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0), 1f);
        }
        foreach (SpriteRenderer sprite in nightmareSprites)
        {
            //lerp alpha
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255), 1f);
        }
    }
    public void ChangeToNormal()
    {
        Debug.Log("ChangeToNormal");
        foreach (SpriteRenderer sprite in normalSprites)
        {
            //lerp alpha
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255), 1f);
        }
        foreach (SpriteRenderer sprite in nightmareSprites)
        {
            //lerp alpha
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0), 1f);
        }
    }
}
