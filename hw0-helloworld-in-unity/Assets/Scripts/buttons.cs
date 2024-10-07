using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public Image helloThereImg;
    public Button showImageBtn;

    public void Start()
    {
        helloThereImg.gameObject.SetActive(false);
    }


    public void showImage() {
        helloThereImg.gameObject.SetActive(true);
    }
}
