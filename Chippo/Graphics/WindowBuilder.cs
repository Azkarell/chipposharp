using Chippo.Actions;
using Chippo.Input;
using Chippo.Settings;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Graphics
{
    class WindowBuilder
    {
        private readonly AppSettings settings;
        private readonly IInputMapper inputMapper;

        public WindowBuilder(AppSettings settings,
            IInputMapper inputMapper)
        {
            this.settings = settings;
            this.inputMapper = inputMapper;
        }

        public RenderWindow Build()
        {
            var window = new RenderWindow(
                new VideoMode(settings.WindowSettings.Width,
                    settings.WindowSettings.Height),
                settings.Title,
                Styles.None);

            window.Closed += (_, __) => window.Close();
            window.KeyPressed += (o, s) => inputMapper.HandlePressed(s);
            window.KeyReleased += (o, s) => inputMapper.HandleReleased(s);
            window.MouseButtonPressed += (o, s) => inputMapper.HandlePressed(s);
            window.MouseButtonReleased += (o, s) => inputMapper.HandleReleased(s);
            window.MouseMoved += (o, s) => inputMapper.HandleMove(s);
            window.MouseWheelScrolled += (o, s) => inputMapper.HandleWheel(s);

            return window;
        }
    }
}
