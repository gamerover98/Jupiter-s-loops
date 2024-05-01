using Api.Manager;

namespace Mono.Manager.GameState
{
    public abstract class GenericGameState : IGameState
    {
        public bool IsStarting = true;
        public bool IsUpdating = false;
        public bool IsEnding = false;

        public virtual void Start()
        {
            IsStarting = true;
            IsUpdating = false;
            IsEnding = false;
        }

        public virtual void Update()
        {
            IsStarting = false;
            IsUpdating = true;
            IsEnding = false;
        }

        public virtual void End()
        {
            IsStarting = false;
            IsUpdating = false;
            IsEnding = true;
        }

        public virtual GameStateType? GetNext()
        {
            throw new System.NotImplementedException();
        }
    }
}