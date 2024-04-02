namespace Enigme.Engine
{
    public class GearValue
    {
        public char Input { get; set; }
        public int Shift { get; set; }
        public char Output { get; set; }

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
