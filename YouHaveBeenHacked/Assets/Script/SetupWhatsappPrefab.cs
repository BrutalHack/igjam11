using UnityEngine;
using UnityEngine.UI;

public class SetupWhatsappPrefab : MonoBehaviour
{
    public enum ImagePosition
    {
        Left,
        Right
    }

    public ImagePosition Layout;
    public string Text;
    public Sprite Sprite;
    public Text TextComponent;
    public Image AvatarImage;

    void Start()
    {
        if (Layout == ImagePosition.Left)
        {
            var child = transform.GetChild(0);
            child.SetAsLastSibling();
        }
        TextComponent.text = Text;
        AvatarImage.sprite = Sprite;
    }
}