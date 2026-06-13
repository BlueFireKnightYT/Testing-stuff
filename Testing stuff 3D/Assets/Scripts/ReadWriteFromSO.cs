using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadWriteFromSO : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_InputField scoreInput;

    [SerializeField] GameDataScriptableObject gameDataSO;

    private void Start()
    {
        ReadValues();
    }

    public void WriteValues()
    {
        if (nameInput.text != "")
        {
            gameDataSO.playerName = nameInput.text;
        }
        if(scoreInput.text != "")
        {
            gameDataSO.playerScore = int.Parse(scoreInput.text);
        }
        ReadValues();
    }

    public void ReadValues()
    {
        nameText.text = gameDataSO.playerName;
        scoreText.text = gameDataSO.playerScore.ToString();
    }

    public void SubmitInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            WriteValues();
            ReadValues();
        }
    }
}
