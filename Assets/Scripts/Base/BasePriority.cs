using UnityEngine;
using UnityEngine.UI;

public class BasePriority : MonoBehaviour
{
    private const int BotPriority = 0;
    private const int BildPriority = 1;

    [SerializeField] private BuyBot _buyBotButton;
    [SerializeField] private GameObject _bildButton;
    [SerializeField] private Score _score;

    private int _priority = 0;

    public int Priority => _priority;

    private void Start()
    {
        SetMarker(_priority);
    }

    public void SetMarker(int number)
    {
        _priority = number;

        switch (_priority)
        {
            case BotPriority:
                BuyBotsPriority();
                break;

            case BildPriority:
                BuildBasePriority();
                break;
        }
    }

    private void BuyBotsPriority()
    {
        SetBool(true);
    }

    private void BuildBasePriority()
    {
        SetBool(false);
    }

    private void SetBool(bool flag)
    {
        _bildButton.GetComponent<Button>().interactable = !flag;
        _buyBotButton.GetComponent<Button>().interactable = flag;
    }
}