using System;
using UnityEngine;

public class InitializeCursor : MonoBehaviour
{
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.ForceSoftware;
	public Vector2 hotSpot = Vector2.zero;

	void Start()
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
}
