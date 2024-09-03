public interface IStateSwithcer
{
    public void SwitchState<T>() where T : IState; 
}
