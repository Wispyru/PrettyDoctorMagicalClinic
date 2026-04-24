using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarRatingAnimated : MonoBehaviour
{
    [SerializeField] private Image[] _stars; // Array of 3 star images
    [SerializeField] private Color _filledStarColor = Color.yellow;
    [SerializeField] private Color _emptyStarColor = Color.gray;
    [SerializeField] private float _animationDuration = 0.5f; // Duration to fill each star
    [SerializeField] private bool _animateOnSet = true; // Whether to animate when SetStars is called

    private Coroutine _currentAnimation;

    /// <summary>
    /// Updates the star display based on the player's score percentage with animation.
    /// 1 star = 30%, 2 stars = 60%, 3 stars = 100%.
    /// </summary>
    public void SetStars(int score, int minimumScore)
    {
        if (_stars.Length != 3)
        {
            Debug.LogError("StarRatingAnimated must have exactly 3 stars configured!");
            return;
        }

        float percentage = minimumScore > 0 ? (float)score / minimumScore * 100f : 0f;
        int starsToFill = 0;

        if (percentage >= 100f) starsToFill = 3;
        else if (percentage >= 60f) starsToFill = 2;
        else if (percentage >= 30f) starsToFill = 1;

        if (_animateOnSet)
        {
            if (_currentAnimation != null)
                StopCoroutine(_currentAnimation);
            _currentAnimation = StartCoroutine(AnimateStars(starsToFill));
        }
        else
        {
            SetStarsImmediate(starsToFill);
        }
    }

    /// <summary>
    /// Sets the stars immediately without animation.
    /// </summary>
    private void SetStarsImmediate(int starsToFill)
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].color = i < starsToFill ? _filledStarColor : _emptyStarColor;
        }
    }

    /// <summary>
    /// Animates the stars filling in sequence.
    /// </summary>
    private IEnumerator AnimateStars(int starsToFill)
    {
        // First, reset all stars to empty
        for (int i = 0; i < _stars.Length; i++)
        {
            _stars[i].color = _emptyStarColor;
        }

        // Then animate each star filling in
        for (int i = 0; i < starsToFill; i++)
        {
            yield return StartCoroutine(AnimateStar(_stars[i]));
        }
    }

    /// <summary>
    /// Animates a single star filling in with a color lerp.
    /// </summary>
    private IEnumerator AnimateStar(Image star)
    {
        float elapsedTime = 0f;
        Color startColor = _emptyStarColor;

        while (elapsedTime < _animationDuration)
        {
            elapsedTime += Time.deltaTime;
            star.color = Color.Lerp(startColor, _filledStarColor, elapsedTime / _animationDuration);
            yield return null;
        }

        star.color = _filledStarColor;
    }

    /// <summary>
    /// Resets all stars to empty state.
    /// </summary>
    public void ResetStars()
    {
        if (_currentAnimation != null)
            StopCoroutine(_currentAnimation);

        foreach (Image star in _stars)
        {
            star.color = _emptyStarColor;
        }
    }
}
