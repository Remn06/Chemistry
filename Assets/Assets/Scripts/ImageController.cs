using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image image;
    private int imageState;
    private Vector3 imageFinalScale = new Vector3(1f, 1f, 1f);
    private Vector3 imageStartScale = new Vector3(0f, 0f, 0f);

    private void Update()
    {
        if(imageState == 1)
        {
            if (image.transform.localScale.x <= imageFinalScale.x)
            {
                image.transform.localScale = new Vector3(image.transform.localScale.x + 0.05f, image.transform.localScale.y + 0.05f, image.transform.localScale.z + 0.05f);
            }
            else
            {
                imageState = 0;
            }
        }
        else if (imageState == -1)
        {
            if (image.transform.localScale.x >= imageStartScale.x)
            {
                image.transform.localScale = new Vector3(image.transform.localScale.x - 0.05f, image.transform.localScale.y - 0.05f, image.transform.localScale.z - 0.05f);
            }
            else
            {
                imageState = 0;
                image.enabled = false;
            }
        }
    }

    public void ShowHideImage()
    {
        if (image.enabled == false)
        {
            image.enabled = true;
            imageState = 1;
        }
        else if (image.enabled == true)
        {
            imageState = -1;
        }
    }
}
