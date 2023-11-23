using System.Collections;

namespace Course_Library.Scripts.Player
{
    public abstract class StateBase<T>
    {
        protected readonly StateController stateController;

        public StateBase(StateController stateController)
        {
            this.stateController = stateController;
        }

        public virtual IEnumerator Start(T owner)
        {
            yield break;
        }

        public virtual IEnumerator Jumping(T owner)
        {
            yield break;
        }

        public virtual IEnumerator Running(T owner)
        {
            yield break;
        }
    }
}