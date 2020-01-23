using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chippo.Settings
{
    class SettingPath
    {
        private readonly string[] parts;

        public SettingPath(string[] parts)
        {
            this.parts = parts;
        }

        public static SettingPath? TryParse(string? key)
        {
            var split = key?.Split(".").Select(x => x.ToLowerInvariant()).ToArray();
            if (split == null) return null;
            return new SettingPath(split);
        }
    }
}
