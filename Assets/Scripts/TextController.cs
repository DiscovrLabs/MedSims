using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{
	public Text textBox;

	string fullSentence;
	string currentString;

	protected string item1 = null;
	protected string item2 = null;
	protected int strCount = 0;

	void Start()
	{
		textBox.text = "";
		StartCoroutine(NeutralCursor());
	}
	
	/*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SetString("THIS SKELETON IS TOO HIGH POLY█", true);
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			SetString("THIS SKELETON IS dicks HIGH POLY█", true);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			SetString("THIS SKELETON IS TOO HIGH POLY█", false);
		}
	}
	*/

	IEnumerator TypeText()
	{
		for (int strIndex = 0; strIndex < fullSentence.Length; strIndex++)
		{
			currentString = currentString + fullSentence[strIndex];
			textBox.text = currentString;
			yield return new WaitForSeconds(0.03f);
		}
		currentString = currentString + "   ";
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

	IEnumerator NeutralCursor()
	{
		bool cursorOn = true;
		while (true)
		{
			if (cursorOn)
			{
				textBox.text = "";
				cursorOn = false;
				yield return new WaitForSeconds(0.5f);
			}
			else
			{
				textBox.text = "█";
				cursorOn = true;
				yield return new WaitForSeconds(0.5f);
			}
		}
	}

	public void SetString(string infoText, bool bAdd)
	{
		textBox.text = "";
		currentString = "";
		StopAllCoroutines();
		if (bAdd)
		{
			if (strCount == 0)
			{
				item1 = infoText;
				fullSentence = item1;
				StartCoroutine(TypeText());
			}
			else
			{
				if (item1 == null)
				{
					item1 = infoText;
				}
				else
				{
					item2 = infoText;
				}
				StartCoroutine(NeutralCursor());
			}
			strCount++;
		}
		else
		{
			if (item1 == infoText)
			{
				item1 = null;
			}
			else
			{
				item2 = null;
			}

			if (strCount == 2)
			{
				if (item1 == null)
				{
					fullSentence = item2;
					StartCoroutine(TypeText());
				}
				else
				{
					fullSentence = item1;
					StartCoroutine(TypeText());
				}
			}
			else
			{
				StartCoroutine(NeutralCursor());
			}
			strCount--;
		}
	}

	public void Reset()
	{
		textBox.text = "";
		currentString = "";
		StopAllCoroutines();
		item1 = null;
		item2 = null;
		strCount = 0;
		StartCoroutine(NeutralCursor());
	}
}