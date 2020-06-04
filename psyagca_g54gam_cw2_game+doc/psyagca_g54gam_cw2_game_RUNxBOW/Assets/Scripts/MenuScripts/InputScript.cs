using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    public InputField nameEntryField;
    public ScoreManager scoreManager;

    public void Start()
    {
        nameEntryField.text = scoreManager.playerName;
        nameEntryField.onValueChanged.AddListener(delegate { NameChangeCapitalCheck(); });
        nameEntryField.onEndEdit.AddListener(delegate { ExitEntryCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void NameChangeCapitalCheck()
    {
        nameEntryField.text = nameEntryField.text.ToUpper();
    }

    public void ExitEntryCheck()
    {
        while(nameEntryField.text.Length < 3)
        {
            nameEntryField.text += "Z";
        }
        scoreManager.playerName = nameEntryField.text;
    }


}
