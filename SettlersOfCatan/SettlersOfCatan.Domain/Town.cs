namespace SettlersOfCatan.Domain
{
    public class Town : SettlementBase
    {
        public override int VictoryPoint => 2;

        public Town(Player owner) : base(owner, 2)
        {}
    }
}
