public abstract class CardTemplate
{
    public ActiveSO cardInfo;
    public PassiveSO cardInfo2;

    public virtual void OnTable()
    {
        // ����â�� �÷��� �� �ߵ�
    }

    public virtual void OnHand()
    {
        // �տ� ���� �� �ߵ�
    }
}
