using Enigme.Engine;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Enigma.View
{

    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<GearValue> R3 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<GearValue> R2 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<GearValue> R1 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<char> Alphabet { get => Get<ObservableCollection<char>>(); set => Set(value); }



        public ICommand ClickCommand { get => Get<ICommand>(); set => Set(value); }

        private EnigmaEngine _engine;

        public MainViewModel()
        {
            Alphabet = new ObservableCollection<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
                Alphabet.Add(c);
            _engine = new EnigmaEngine();
            ClickCommand = new CommandBase(Generate);
            R1 = new ObservableCollection<GearValue>();
            R2 = new ObservableCollection<GearValue>();
            R3 = new ObservableCollection<GearValue>();
        }

        public void Generate()
        {
            R1.Clear();
            R2.Clear();
            R3.Clear();

            int seed = 1;
            foreach (var v in _engine.GenerateRotor(seed, 0, 5))
                R3.Add(v);
            foreach (var v in _engine.GenerateRotor(seed, 5, 5))
                R2.Add(v);
            foreach (var v in _engine.GenerateRotor(seed, 10, 5))
                R1.Add(v);
        }


    }
}
