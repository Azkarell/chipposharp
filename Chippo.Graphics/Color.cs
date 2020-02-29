using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Chippo.System;

namespace Chippo.Graphics
{
    public struct Color
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        private static Regex regex = new Regex("^#([A-Fa-f0-9]{2})([A-Fa-f0-9]{2})([A-Fa-f0-9]{2})([A-Fa-f0-9]{2})?$");
        private Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static Color FromRGBA(string rgba)
        {
            var match = regex.Match(rgba);
            if(!match.Success) throw new ArgumentException(nameof(rgba));
            var arr = new List<byte>();
            foreach (Group @group in match.Groups.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(group.Value)) continue;
                arr.Add(StringToByte(@group.Value));
            }
            if (arr.Count == 3)
            {
                arr.Add(byte.MaxValue);
            }
            return new Color(arr[0], arr[1], arr[2], arr[3] );
        }

        public static Color FromARGB(string argb)
        {
            var match = regex.Match(argb);
            if (!match.Success) throw new ArgumentException(nameof(argb));
            var arr = new List<byte>();
            foreach (Group @group in match.Groups.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(group.Value)) continue;
                arr.Add(StringToByte(@group.Value));
            }

            if (arr.Count == 3)
            {
                arr.Insert(0, byte.MaxValue);
            }
            return new Color(arr[1], arr[2], arr[3],arr[0] );
        }

        private static BiDirectionalDictionary<char, byte> convertDictionary = new BiDirectionalDictionary<char, byte>
        {
            ['0'] = 0,
            ['1'] = 1,
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['a'] = 10,
            ['b'] = 11,
            ['c'] = 12,
            ['d'] = 13,
            ['e'] = 14,
            ['f'] = 15,
        };

        private static byte StringToByte(string hex)
        {
            if(hex.Length != 2) throw new ArgumentException(nameof(hex));
            var lower = hex.ToLowerInvariant();
            var first = convertDictionary[lower[0]] << 4;
            var second = convertDictionary[lower[1]];
            return (byte) (first | second);
        }

        private static string ByteToString(byte b)
        {
            var first = (byte) ((240 & b) >> 4);
            var second = (byte) (15 & b);

            return string.Concat(convertDictionary[first], convertDictionary[second]);
        }

        public override string ToString()
        {
            return $"#{ByteToString(R)}{ByteToString(G)}{ByteToString(B)}{ByteToString(A)}";
        }
    }
}