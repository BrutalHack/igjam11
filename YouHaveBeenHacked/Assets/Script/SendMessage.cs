using UnityEngine;
using UnityEngine.UI;

public class SendMessage : MonoBehaviour
{
	public InputField InputField;
	public RectTransform panel;
	public RectTransform prefab;
	public ScrollRect scrollView;
	public void SendStuff()
	{
		var newMessage = Instantiate(prefab);
		var setup = newMessage.GetComponent<SetupWhatsappPrefab>();
		setup.Layout = SetupWhatsappPrefab.ImagePosition.Left;
		setup.Text = InputField.text;
		newMessage.transform.SetParent(panel.transform,false);
		Canvas.ForceUpdateCanvases ();
		scrollView.verticalScrollbar.value=0f;
		Canvas.ForceUpdateCanvases ();
	}
}
