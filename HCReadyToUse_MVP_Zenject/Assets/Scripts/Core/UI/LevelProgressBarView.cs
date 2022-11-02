using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressBarView : MonoBehaviour
{
    [SerializeField] private int _cellsCount = 5;
    [SerializeField] private List<Image> _levelCellsBackground;
    [SerializeField] private List<Image> _levelCellsOutline;
    [SerializeField] private List<TextMeshProUGUI> _levelNumbers;
    [SerializeField] private Image _progressLine;

    private Color _whiteColor = Color.white;
    private Color _greenColor = Color.green;
    private Color _darkGreenColor = new Color(0.07f, 0.39f, 0.07f);
    private Color _yellowColor = Color.yellow;
    private Color _transparent = new Color(0, 0, 0, 0);

    public void InitProgressBar(int currentLevel)
    {
        int curCell;
        int firstLevelNumber;

        if (currentLevel <= _cellsCount)
        {
            curCell = currentLevel;
            firstLevelNumber = 1;
        }
        else
        {
            var repeatCount = currentLevel / _cellsCount;

            if (currentLevel % _cellsCount != 0)
            {
                var roundedLevelCount = _cellsCount * repeatCount + _cellsCount;
                firstLevelNumber = roundedLevelCount - _cellsCount + 1;
                curCell = currentLevel + _cellsCount - roundedLevelCount;
            }
            else
            {
                var roundedLevelCount = _cellsCount * repeatCount;
                firstLevelNumber = roundedLevelCount - _cellsCount + 1;
                curCell = currentLevel + _cellsCount - roundedLevelCount;
            }

        }

        for (int i = 0; i < _cellsCount; i++)
        {
            var current = curCell - 1;
            var previous = curCell - 2;

            if (i == current)
            {
                _levelCellsOutline[i].color = _yellowColor;
                _levelCellsBackground[i].color = _whiteColor;
            }
            else if (i <= previous)
            {
                _levelCellsOutline[i].color = _darkGreenColor;
                _levelCellsBackground[i].color = _greenColor;
            }
            else if (i > current)
            {
                _levelCellsBackground[i].color = _whiteColor;
                _levelCellsOutline[i].color = _transparent;
            }
            if (i <= current)
            {
                _progressLine.fillAmount = (1f / (_cellsCount-1)) * i;
            }

            _levelNumbers[i].text = (firstLevelNumber + i).ToString();
        }
    }
}
