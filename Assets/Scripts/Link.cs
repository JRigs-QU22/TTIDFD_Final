using UnityEngine;
using System.Runtime.InteropServices;

public class Link : MonoBehaviour
{
	//this is taken from https://va.lent.in/opening-links-in-a-unity-webgl-project/
	public void OpenTrello()
	{
#if !UNITY_EDITOR
		openWindow("https://trello.com/b/tthN0xL2/the-things-i-do-for-drachma");
#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}