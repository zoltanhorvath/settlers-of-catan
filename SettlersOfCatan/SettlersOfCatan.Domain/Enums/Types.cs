namespace SettlersOfCatan.Domain.Enums
{
    public enum TerrainType
    {
        Hills,
        Pasture,
        Mountains,
        Fields,
        Forest,
        Desert
    }
    public enum ResourceType
    {
        Brick,
        Wool,
        Ore,
        Grain,
        Lumber,
        Nothing
    }

    public enum BuildableType
    {
        City,
        Road,
        Settlement
    }

    public enum TradingCapability
    {
        None,
        Brick,
        Wool,
        Ore,
        Grain,
        Lumber,
        FourToOne,
        ThreeToOne,
    }

    public enum Direction
    {
        NorthEast,
        East,
        SouthEast,
        SouthWest,
        West,
        NorthWest
    }

    public enum GamePhase
    {
        SettingUp,
        Playing,
        Ending
    }
}
