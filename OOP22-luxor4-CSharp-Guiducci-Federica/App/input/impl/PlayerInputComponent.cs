using System;

namespace OOP22_luxor4_CSharp_Guiducci_Federica.App.input.impl
{
    // Assuming the equivalent namespaces and classes exist in the C# codebase
    class PlayerInputComponent : InputComponent
    {
        public const int SPEED = 5;
        public const int ADJUST_RIGHT_BORDER_LIMIT = 90;

        public void Update(GameObject gameObject, InputController ctrl)
        {
            P2d pos = gameObject.CurrentPos;

            int moveSpeedX = 0;
            if (ctrl.IsMoveLeft && pos.X > WorldImpl.GetBBox().ULCorner.X)
            {
                moveSpeedX = -PlayerInputComponent.SPEED;
            }
            else if (ctrl.IsMoveRight && pos.X < WorldImpl.GetBBox().BRCorner.X - PlayerInputComponent.ADJUST_RIGHT_BORDER_LIMIT)
            {
                moveSpeedX = PlayerInputComponent.SPEED;
            }

            pos = pos.Sum(new V2d(moveSpeedX, 0));

            gameObject.Pos = pos;

            if (gameObject is Cannon && ctrl.IsShoot)
            {
                Cannon cannon = (Cannon)gameObject;
                ctrl.StopShooting();
                cannon.FireBall();
            }
        }
    }
}
