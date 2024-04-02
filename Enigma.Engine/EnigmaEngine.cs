using System;
using System.Collections.Generic;
using System.Linq;

namespace Enigma.Engine
{
    public class EnigmaEngine
    {
        public const int AlphabetLength = 26;//TODO 27 (space)

        public EnigmaEngine()
        {
        }

        public List<GearValue> GenerateRotor(int seed, int offset, int size)
        {
            Random r = new Random(seed);
            List<GearValue> rotor = new List<GearValue>();

            for (int blockIndex = 0; blockIndex < AlphabetLength / size; ++blockIndex)
            {
                var shifts = ShiftChunk(r, (blockIndex + 2) * size > AlphabetLength
                    ? AlphabetLength - blockIndex * size
                    : size);
                for (int j = 0; j < shifts.Count; ++j)
                {
                    rotor.Add(CreateGeatValue(blockIndex * size + j, offset + shifts[j]));
                }
            }

            return rotor;
        }

        private List<int> ShiftChunk(Random r, int size)
        {
            List<int> shifts = new List<int>(size);
            List<int> buffer = new List<int>(size);

            //fill a buffer like this : [0,1,2,3,4]
            for (int i = 0; i < size; ++i)
            {
                buffer.Add(i);
            }

            //shake it
            buffer = buffer.OrderBy(i => Rand(r)).ToList();
            for (int i = 0; i < size; ++i)
            {
                int v = (buffer[i] - i + size) % size;
                shifts.Add(v + i >= size ? v - size : v);
            }

            return shifts;
        }

        private GearValue CreateGeatValue(int input, int shift)
        {
            return new GearValue((char)('A' + input), shift % AlphabetLength);
        }


        public int Rand(Random r)
        {
            return r.Next(AlphabetLength);
        }
    }

}
