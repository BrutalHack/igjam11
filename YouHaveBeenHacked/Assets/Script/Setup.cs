using UnityEngine;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
	public enum ImagePosition
	{
		Left,Right
	}
	public ImagePosition layout;
	public string Text;

	void Start()
	{
		if (layout == ImagePosition.Left)
		{
			var child = transform.GetChild(0);
			child.SetAsLastSibling();
		}
		var textComponent = GetComponentInChildren<Text>();
		textComponent.text = Text;
	}

}
