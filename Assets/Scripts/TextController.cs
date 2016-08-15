using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class TextController : MonoBehaviour
{
	protected Text textBox;

	public string fullSentence;
	public float typingDelay = 0.03f;

	[HideInInspector]
	public bool bFinishedTyping = false;
	string currentString;

	void Awake()
	{
		textBox = GetComponent<Text>();
		textBox.text = "";
	}

	void Start()
	{
		fullSentence = fullSentence.Replace("NEWLINE", "\n");
	}

	IEnumerator TypeText()
	{
		for (int strIndex = 0; strIndex < fullSentence.Length; strIndex++)
		{
			currentString = currentString + fullSentence[strIndex];
			textBox.text = currentString;
			yield return new WaitForSeconds(typingDelay);
		}
		currentString = currentString + "   ";
		bFinishedTyping = true;
		StartCoroutine(BlinkingCursor());
	}

	IEnumerator BlinkingCursor()
	{
		bool cursorOn = false;
		while (true)
		{
			if (cursorOn)
			{
				currentString = currentString.Substring(0, currentString.Length - 1);
				currentString = currentString + "   ";
				textBox.text = currentString;
				cursorOn = false;
				yield return new WaitForSeconds(0.5f);
			}
			else
			{
				currentString = currentString.Substring(0, currentString.Length - 3);
				currentString = currentString + "█";
				textBox.text = currentString;
				cursorOn = true;
				yield return new WaitForSeconds(0.5f);
			}
		}
	}

	public void SetString(string infoText, float delay = 0.03f)
	{
		textBox.text = "";
		currentString = "";
		bFinishedTyping = false;
		StopAllCoroutines();

		fullSentence = infoText;
		StartCoroutine(TypeText());
	}

	public void StartTyping()
	{
		textBox.text = "";
		currentString = "";
		bFinishedTyping = false;
		StopAllCoroutines();
		StartCoroutine(TypeText());
	}

	public void SkipTyping()
	{
		textBox.text = "";
		currentString = fullSentence + "   ";
		bFinishedTyping = true;
		StopAllCoroutines();
		StartCoroutine(BlinkingCursor());
	}
}