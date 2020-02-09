using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using Autofac;
using Autofac.Core.Registration;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class AppRegistration
    {
        private ContainerBuilder builder;
        public const string KeyboardAxisId = "keyboard";
        public const string MouseAxisId = "mouse";
        public const string WheelAxisId = "wheel";

        public AppRegistration(ContainerBuilder containerBuilder)
        {
            builder = containerBuilder;
            builder.RegisterType<App>();
        }

        //public App Build()
        //{
        //    builder.RegisterType<App>();
        //    var container = builder.Build();
        //    return container.Resolve<App>();
        //    //var window = new RenderWindow(VideoMode.DesktopMode, "Game", Styles.None);
        //    //var eventDispatcher = new EventDispatcher(window);
        //    //var stopwatch = new Stopwatch();
        //    //var loop = new SimpleLoop(stopwatch, TimeSpan.FromMilliseconds(16));
        //    //var state = new GameState();
        //    //var gameObjects = state.GameObjects;
        //    //var staticObjects = state.StaticObjects;
        //    //var drawables = state.Drawables;
        //    //var sfmlwindow = new SfmlWindow(window, drawables);
        //    //var dimension = Dimension.FromWindow(window);
        //    //var input = sfmlwindow.Input;

        //    //var keyboardConfiguration = new Axis2DConfiguration(
        //    //    new KeyDirection(Keyboard.Key.A, input),
        //    //    new KeyDirection(Keyboard.Key.D, input),
        //    //    new KeyDirection(Keyboard.Key.W, input),
        //    //    new KeyDirection(Keyboard.Key.S, input)
        //    //    );
        //    //var mouseConfiguration = new Axis2DConfiguration(
        //    //    new LeftMouseDirection(input, dimension, 0.1f),
        //    //    new RightMouseDirection(input, dimension, 0.1f),
        //    //    new UpMouseDirection(input, dimension, 0.1f),
        //    //    new DownMouseDirection(input, dimension, 0.1f)
        //    //    );

        //    //var wheelConfiguration = new Axis2DConfiguration(
        //    //    new HorizontalWheelDirection(input, loop),
        //    //    new VerticalWheelDirection(input, loop)
        //    //    );

        //    //var axisProvider = new AxisProvider(new AxisFactory());

        //    //axisProvider.Register(KeyboardAxisId, keyboardConfiguration);
        //    //axisProvider.Register(MouseAxisId, mouseConfiguration);
        //    //axisProvider.Register(WheelAxisId, wheelConfiguration);
        //    //var axisproxy = new Axis2DProxy(axisProvider.GetAxis2D(KeyboardAxisId));
        //    //var axisSwitcher = new AxisSwitcher(input,axisproxy, new IAxis2D[] { axisProvider.GetAxis2D(KeyboardAxisId), axisProvider.GetAxis2D(MouseAxisId), axisProvider.GetAxis2D(WheelAxisId) });
            
        //    //var movement = new AxisMovement(50,axisproxy, new Pixels(50));

        //    //var rectangle = new Rectangle(
        //    //    new Vector2f(dimension.Width / 2, dimension.Height / 2),
        //    //    new Vector2f(50, 50),
        //    //    Color.Red, movement);
        //    //var rectangle2 = new Rectangle(
        //    //    new Vector2f(40,40),
        //    //    new Vector2f(50,50),
        //    //    Color.Green,
        //    //    movement
        //    //    );
        //    //gameObjects.Add(rectangle);
        //    //gameObjects.Add(rectangle2);
        //    //drawables.Add(rectangle);
        //    //drawables.Add(rectangle2);
        //    //staticObjects.Add(axisSwitcher);

        //    //var logic = new GameLogic(loop, state, sfmlwindow.Input);
        //    //var app = new App(sfmlwindow, eventDispatcher, logic, loop);
        //    //return app;
        //}


        public AppRegistration UseOutput<T>() where T : IOutput
        {
            builder.RegisterType<T>()
                .As<IOutput>()
                .AsSelf()
                .SingleInstance();
            return this;
        }

        public AppRegistration UseLogic<T>() where T : ILogic
        {
            builder.RegisterType<T>().As<ILogic>().SingleInstance();
            return this;
        }

        public AppRegistration UseLoop<T>() where T : ILoop
        {
            builder.RegisterType<T>().As<ILoop>().SingleInstance();
            return this;
        }

        public AppRegistration UseDispatcher<T>() where T : IDispatcher
        {
            builder.RegisterType<T>().As<IDispatcher>().SingleInstance();
            return this;
        }

    }
}