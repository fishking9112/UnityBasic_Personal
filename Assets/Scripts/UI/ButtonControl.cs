using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    private Image UIImage;


    private void Awake()
    {
        UIImage = GetComponent<Image>();
    }
    public void ChangeButtonImage(Sprite changeImage)
    {
        UIImage.sprite = changeImage;
    }
}
