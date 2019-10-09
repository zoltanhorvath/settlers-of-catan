namespace SettlersOfCatan.Domain
{
    public class Village : SettlementBase
    {
        public override int VictoryPoint { get; } = 1;

        public Village(Player owner) : base(owner, 1) { }

    }
}
