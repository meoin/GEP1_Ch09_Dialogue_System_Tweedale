using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMesh;
    [SerializeField] private string _textToDisplay = string.Empty;
    [SerializeField] private float _textIndex;
    public float TextScrollSpeed;
    public float PauseTimeAfterDialogue = 1f;
    public bool FullTextDisplayed = false;

    private void Start()
    {
        ClearText();
    }

    // Update is called once per frame
    void Update()
    {
        if (_textToDisplay == string.Empty) return;

        if (_textIndex >= _textToDisplay.Length)
        {
            FullTextDisplayed = true;
            return;
        }

        _textIndex += Time.deltaTime * TextScrollSpeed;

        string text = _textToDisplay.Substring(0, (int)Mathf.Min(_textIndex, _textToDisplay.Length));

        UpdateText(text);
    }

    void UpdateText(string text)
    {
        _textMesh.text = text;
    }

    public void SetText(string text)
    {
        _textMesh.color = new Color(_textMesh.color.r, _textMesh.color.g, _textMesh.color.b, 1f);
        FullTextDisplayed = false;
        _textToDisplay = text;
        _textIndex = 0;
    }

    public void ClearText()
    {
        FullTextDisplayed = false;
        _textToDisplay = string.Empty;
        _textMesh.text = string.Empty;
        _textIndex = 0;
    }

    public void SetTextOpacity(float opacity)
    {
        _textMesh.color = new Color(_textMesh.color.r, _textMesh.color.g, _textMesh.color.b, opacity);
    }

    public float GetTextOpacity()
    {
        return _textMesh.color.a;
    }

    public void SetTextImmediately(string text)
    {
        FullTextDisplayed = true;
        _textIndex = text.Length;
        _textToDisplay = text;
        _textMesh.text = text;
    }
}
