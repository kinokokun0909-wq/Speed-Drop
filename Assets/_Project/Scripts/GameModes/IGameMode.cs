namespace SpeedDrop.GameModes
{
    public interface IGameMode
    {
        void Begin();
        void Tick(float deltaTime);
        void End();
    }
}
