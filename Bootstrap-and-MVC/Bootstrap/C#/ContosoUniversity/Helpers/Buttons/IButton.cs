namespace ContosoUniversity.Helpers.Buttons
{
    public interface IButton : IButtonFluent
    {
        IButtonFluent Default();
        IButtonFluent Primary();
        IButtonFluent Success();
        IButtonFluent Info();
        IButtonFluent Warning();
        IButtonFluent Danger();
        IButtonFluent Link();
    }
}