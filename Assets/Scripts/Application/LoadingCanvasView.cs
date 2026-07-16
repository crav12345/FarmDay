using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasView : MonoBehaviour
{
    [SerializeField] private Image[] _dotImages;

    private static readonly WaitForSeconds _wait = new(0.5f);

    private void OnEnable()
    {
        StartCoroutine(LoadingCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(LoadingCoroutine());
    }

    private IEnumerator LoadingCoroutine()
    {
        var activeDot = 0;

        while (true)
        {
            yield return _wait;

            if (activeDot == _dotImages.Length)
            {
                activeDot = 0;

                foreach (var dot in _dotImages)
                {
                    dot.enabled = false;
                }
            }
            else
            {
                _dotImages[activeDot].enabled = true;
                activeDot++;
            }
        }
    }
}
