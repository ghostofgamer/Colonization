using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FreeUnits : MonoBehaviour
{
    [SerializeField] private TMP_Text _freeUnitsCountTxt;
    [SerializeField] private Base _base;
    [SerializeField] private Button _goUnitButton;

    private void Update()
    {
        var filter = _base.UnitMovers.Where(p => p._isGo == false);
        _goUnitButton.GetComponent<Button>().interactable = filter.Count() > 0 ? true : false;
        _freeUnitsCountTxt.text = filter.Count().ToString();
    }
}