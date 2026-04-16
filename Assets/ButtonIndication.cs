using UnityEngine;
using UnityEngine.UI;

public class ButtonIndication : MonoBehaviour
{
    private Image currentImage;

    private void Start()
    {
        currentImage = GetComponent<Image>();
    }

    void DisableButton()
    {
        currentImage.color = Color.red;
    }
}
