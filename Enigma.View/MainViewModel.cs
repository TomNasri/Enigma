using Enigma.Engine;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace Enigma.View
{

    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<GearValue> R3 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<GearValue> R2 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<GearValue> R1 { get => Get<ObservableCollection<GearValue>>(); set => Set(value); }
        public ObservableCollection<char> Alphabet { get => Get<ObservableCollection<char>>(); set => Set(value); }

        private int seed = 1;

        public ICommand ClickCommand { get => Get<ICommand>(); set => Set(value); }
        public ICommand SelectInputCommand { get => Get<ICommand>(); set => Set(value); }


        private EnigmaEngine _engine;

        public MainViewModel()
        {
            Alphabet = new ObservableCollection<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
                Alphabet.Add(c);
            _engine = new EnigmaEngine();
            ClickCommand = new CommandBase(Generate);
            SelectInputCommand = new CommandBase(SelectInput);
            R1 = new ObservableCollection<GearValue>();
            R2 = new ObservableCollection<GearValue>();
            R3 = new ObservableCollection<GearValue>();
        }

        public void Generate()
        {
            R1.Clear();
            R2.Clear();
            R3.Clear();

            foreach (var v in _engine.GenerateRotor(seed, 0, 5))
                R3.Add(v);
            foreach (var v in _engine.GenerateRotor(seed, 5, 5))
                R2.Add(v);
            foreach (var v in _engine.GenerateRotor(seed, 10, 5))
                R1.Add(v);

            seed++;

            Thread.Sleep(5000);

            SelectInput('A');
        }

        private void SelectInput(object v)
        {
            foreach (var g in R3.Union(R2).Union(R1))
                g.IsSelected = false;

            var g3 = R3.FirstOrDefault(gear => gear.Input == (char)v);
            var g2 = R2.FirstOrDefault(gear => gear.Input == g3.Output);
            var g1 = R1.FirstOrDefault(gear => gear.Input == g2.Output);
            g3.IsSelected = true;
            g2.IsSelected = true;
            g1.IsSelected = true;

            SelectOutput(g1.Output);

            Notify(nameof(R3));
            Notify(nameof(R2));
            Notify(nameof(R1));
        }

        private void SelectOutput(char v)
        {
            var g1 = R1.FirstOrDefault(gear => gear.Output == v);
            var g2 = R2.FirstOrDefault(gear => gear.Output == g1.Input);
            var g3 = R3.FirstOrDefault(gear => gear.Output == g2.Input);
            g1.IsSelected = true;
            g2.IsSelected = true;
            g3.IsSelected = true;
        }
    }
}
