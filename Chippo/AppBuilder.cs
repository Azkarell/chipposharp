using System;
using System.Diagnostics;
using Chippo.GameObjects;
using Chippo.Input;
using Chippo.Input.Axis;
using Chippo.Input.Keyboards;
using Chippo.Input.Mouses;
using Chippo.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chippo
{
    public class AppBuilder
    {
        public const string KeyboardAxisId = "keyboard";
        public const string MouseAxisId = "mouse";
        public const string WheelAxisId = "wheel";

        public App Build()
        {
            var window = new RenderWindow(VideoMode.DesktopMode, "Game", Styles.None);
            var eventDispatcher = new EventDispatcher(window);
            var stopwatch = new Stopwatch();
            var loop = new SimpleLoop(stopwatch, TimeSpan.FromMilliseconds(16));
            var state = new GameState();
            var gameObjects = state.GameObjects;
            var staticObjects = state.StaticObjects;
            var drawables = state.Drawables;
            var sfmlwindow = new SfmlWindow(window, drawables);
            var dimension = Dimension.FromWindow(window);
            var input = sfmlwindow.Input;

            var keyboardConfiguration = new Axis2DConfiguration(
                new KeyDirection(Keyboard.Key.A, input),
                new KeyDirection(Keyboard.Key.D, input),
                new KeyDirection(Keyboard.Key.W, input),
                new KeyDirection(Keyboard.Key.S, input)
                );
            var mouseConfiguration = new Axis2DConfiguration(
                new LeftMouseDirection(input, dimension, 0.1f),
                new RightMouseDirection(input, dimension, 0.1f),
                new UpMouseDirection(input, dimension, 0.1f),
                new DownMouseDirection(input, dimension, 0.1f)
                );

            var wheelConfiguration = new Axis2DConfiguration(
                new HorizontalWheelDirection(input, loop),
                new VerticalWheelDirection(input, loop)
                );

            var axisProvider = new AxisProvider(new AxisFactory());

            axisProvider.Register(KeyboardAxisId, keyboardConfiguration);
            axisProvider.Register(MouseAxisId, mouseConfiguration);
            axisProvider.Register(WheelAxisId, wheelConfiguration);
            var axisproxy = new Axis2DProxy(axisProvider.GetAxis2D(KeyboardAxisId));
            var axisSwitcher = new AxisSwitcher(input,axisproxy, new IAxis2D[] { axisProvider.GetAxis2D(KeyboardAxisId), axisProvider.GetAxis2D(MouseAxisId), axisProvider.GetAxis2D(WheelAxisId) });
            
            var movement = new AxisMovement(50,axisproxy);

            var rectangle = new Rectangle(
                new Vector2f(dimension.Width / 2, dimension.Height / 2),
                new Vector2f(50, 50),
                Color.Red, movement);
            var rectangle2 = new Rectangle(
                new Vector2f(40,40),
                new Vector2f(50,50),
                Color.Green,
                movement
                );
            gameObjects.Add(rectangle);
            gameObjects.Add(rectangle2);
            drawables.Add(rectangle);
            drawables.Add(rectangle2);
            staticObjects.Add(axisSwitcher);

            var logic = new GameLogic(loop, state, sfmlwindow.Input);
            var app = new App(sfmlwindow, eventDispatcher, logic, loop);
            return app;
        }


    }
}