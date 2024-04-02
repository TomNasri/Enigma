using System.Collections.ObjectModel;
using Enigma.Engine.Models;

namespace Enigma.Engine
{
    public class GearValue : CoreModel
    {
        public char Input { get => Get<char>(); set => Set(value); }
        public int Shift { get => Get<int>(); set => Set(value); }
        public char Output { get => Get<char>(); set => Set(value); }
        public bool IsSelected { get => Get<bool>(); set => Set(value); }

        public GearValue(char input, int shift)
        {
            Shift = shift;
            SetInput(input);
        }

        public void SetInput(char input)
        {
            Input = input;
            Output = (char)('A' + ((Input - 'A' + Shift + EnigmaEngine.AlphabetLength) % EnigmaEngine.AlphabetLength));
        }

        public override string ToString()
        {
            return $"{Output} < {Input}";
        }
    }

}
