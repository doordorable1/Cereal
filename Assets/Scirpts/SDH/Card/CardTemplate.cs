public abstract class CardTemplate
{
    public ActiveSO cardInfo;
    public PassiveSO cardInfo2;

    public virtual void OnTable()
    {
        // 세공창에 올렸을 때 발동
    }

    public virtual void OnHand()
    {
        // 손에 있을 때 발동
    }
}
