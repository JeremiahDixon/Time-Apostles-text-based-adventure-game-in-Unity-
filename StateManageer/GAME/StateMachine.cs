namespace StateStuff
{
    public class StateMachine<T>
    {
        public State<T> currentState { get; set; }
        public T Owner;


        public StateMachine(T _owner)
        {
            Owner = _owner;
            currentState = null;

        }

        public void changeState(State<T> newState)
        {
            if (currentState != null)
            {
                currentState.exitState(Owner);
            }


            currentState = newState;
            currentState.enterState(Owner);
        }

        public void update()
        {
            if (currentState != null)
            {
                currentState.updateState(Owner);
            }

        }
    }

    public abstract class State<T>
    {

        public abstract string enterState(T _owner);
        public abstract void exitState(T _owner);
        public abstract string updateState(T _owner);

    }

}