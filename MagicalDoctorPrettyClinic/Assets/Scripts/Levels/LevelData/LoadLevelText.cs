using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadLevelText : MonoBehaviour
{
    [SerializeField]
    private GameObject _pointText;
    [SerializeField]
    private GameObject _turnText;
    [SerializeField]
    private GameObject _movesText;


    void Start()
    {
        SetStartText();
    }

    private void SetStartText()
    {
        TMP_Text pointText = _pointText.GetComponent<TMP_Text>();
        pointText.text = pointText.text + LoadedLevel.Points.ToString();

        TMP_Text movesText = _movesText.GetComponent<TMP_Text>();
        movesText.text = movesText.text + LoadedLevel.MovesPerTurn.ToString();

        TMP_Text turnText = _turnText.GetComponent<TMP_Text>();
        turnText.text = turnText.text + LoadedLevel.TurnCount.ToString();  
    }
}
