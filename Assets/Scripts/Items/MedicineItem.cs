using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class MedicineItem : DraggableItem
{
    Thermometer thermometer;
    Emote emote;

    [SerializeField] private GameEvent useMedicineWhenSick = default;
    [SerializeField] private GameEvent useMedicineWhenHealthy = default;
    [SerializeField] private Resources resources = default;
    [SerializeField] private int moneyReward = default;

    private void Start()
    {
        thermometer = GameObject.Find("Thermometer").GetComponent<Thermometer>();
        emote = GameObject.Find("Emote").GetComponent<Emote>();
    }

    public override void OnDrop()
    {
        if (!emote.isShowingBalloon)
        {
            if (thermometer.isSick)
            {
                resources.AddMoney(moneyReward);
                StartCoroutine(emote.ShowBalloon(true));
                UseItem();
                useMedicineWhenSick.Raise();
            }
            else
            {
                StartCoroutine(emote.ShowBalloon(false));
                useMedicineWhenHealthy.Raise();
            }
        }
    }
}
