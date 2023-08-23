namespace OOP22_luxor4_CSharp_Guiducci_Federica.App.input.api
{
    public interface IInputController
    {
        bool IsMoveLeft();

        bool IsMoveRight();

        bool IsShoot();

        void StopShooting();
    }
}
