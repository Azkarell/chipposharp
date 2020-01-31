using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chippo.GameObjects;
using Chippo.Interfaces;

namespace Chippo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var window = new RenderWindow(VideoMode.DesktopMode, "Game", Styles.None);


            var eventDispatcher = new EventDispatcher(window);
            var stopwatch = new Stopwatch();
            var gameObjects = new GameObjectsCollection(stopwatch);
            using var sfmlwindow = new SfmlWindow(window, gameObjects);
            var keyboardaxis = new KeyboardAxis2D(sfmlwindow.Input,
                Keyboard.Key.A,
                Keyboard.Key.D,
                Keyboard.Key.W,
                Keyboard.Key.S);
            var mouseAxis = new MouseAxis2D(sfmlwindow.Input,sfmlwindow.Dimension,0.3f);
            var axisproxy = new Axis2DProxy(keyboardaxis);
            gameObjects.Add(new Rectangle(15,axisproxy));
            gameObjects.Add(new AxisSwitcher(sfmlwindow.Input,axisproxy,new IAxis2D[]{mouseAxis,keyboardaxis}));
            var logic = new GameLogic(gameObjects, stopwatch,sfmlwindow.Input);
            var app = new App(sfmlwindow,eventDispatcher,logic);


            stopwatch.Start();
            await app.Start();
        }
    }

    internal class AxisSwitcher : GameObject
    {
        
        private readonly Input input;
        private readonly Axis2DProxy axisproxy;
        private readonly IAxis2D[] axis2Ds;
        private uint cur = 0;

        public AxisSwitcher(Input input, Axis2DProxy axisproxy, IAxis2D[] axis2Ds)
        {
            this.input = input;
            this.axisproxy = axisproxy;
            this.axis2Ds = axis2Ds;
        }

        public override void Update(TimeSpan delta)
        {
            if (input.IsPressed(Keyboard.Key.R))
            {
                axisproxy.SwitchImplementation(axis2Ds[cur++ % axis2Ds.Length]);
            }
        }
    }
}
