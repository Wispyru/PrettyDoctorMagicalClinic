using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _comboText;

    [SerializeField]
    private TextMeshProUGUI _movesText;

    [SerializeField]
    private TextMeshProUGUI[] _scoreTexts;

    [SerializeField]
    private Image[] _scoreIcons;

    [SerializeField]
    private Sprite[] _medicineSprites;

    [SerializeField]
    private float _comboFadeDelay = 3f;

    [SerializeField]
    private float _comboFadeDuration = 2f;

    private Tween _comboFadeTween;

    private void Start()
    {
        SetupScoreIcons();
        UpdateScoreDisplays();
        UpdateMovesDisplay();
        HideComboText();
    }

    /// <summary>
    /// Assigns the correct medicine sprite to each score icon.
    /// </summary>
    private void SetupScoreIcons()
    {
        for (int i = 0; i < _scoreIcons.Length; i++)
        {
            if (i < _medicineSprites.Length)
                _scoreIcons[i].sprite = _medicineSprites[i];
        }
    }

    /// <summary>
    /// Updates all five medicine type score displays from GameData.
    /// </summary>
    public void UpdateScoreDisplays()
    {
        if (_scoreTexts.Length < 5) return;

        _scoreTexts[0].text = GameData.ScoreMedicineType1.ToString();
        _scoreTexts[1].text = GameData.ScoreMedicineType2.ToString();
        _scoreTexts[2].text = GameData.ScoreMedicineType3.ToString();
        _scoreTexts[3].text = GameData.ScoreMedicineType4.ToString();
        _scoreTexts[4].text = GameData.ScoreMedicineType5.ToString();
    }

    /// <summary>
    /// Updates the moves remaining display from GameData.
    /// </summary>
    public void UpdateMovesDisplay()
    {
        _movesText.text = GameData.CurrentMoves.ToString();
    }

    /// <summary>
    /// Shows the combo text for the given combo count, then fades it out after a delay.
    /// </summary>
    public void ShowComboText(int comboCount)
    {
        if (comboCount <= 1) return;

        _comboFadeTween?.Kill();

        _comboText.text = $"x{comboCount} COMBO!";
        _comboText.alpha = 1f;

        _comboFadeTween = DOVirtual.DelayedCall(_comboFadeDelay, () =>
        {
            _comboText.DOFade(0f, _comboFadeDuration);
        });
    }

    /// <summary>
    /// Hides the combo text instantly.
    /// </summary>
    private void HideComboText()
    {
        _comboText.alpha = 0f;
    }
}