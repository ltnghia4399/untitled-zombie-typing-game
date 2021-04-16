using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
public class ButtonTween : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Button btn;

    public Vector2 originalSize, scaleToSize;
    public float duration;

    public Ease easeIn, easeOut;

    public void OnPointerEnter(PointerEventData eventData)
    {
        btn.transform.DOScale(scaleToSize, duration).SetEase(easeOut).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btn.transform.DOScale(originalSize, duration).SetEase(easeIn).SetUpdate(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (System.Object.ReferenceEquals(btn, null))
        {
            btn = GetComponent<Button>();
        }
    }

    
}
