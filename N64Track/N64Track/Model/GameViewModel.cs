using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace N64Track
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Game> _Games = new ObservableCollection<Game>();

        public ObservableCollection<Game> Games
        {
            get { return _Games; }
            set
            {
                _Games = value;
                OnPropertyChanged();
            }
        }

        public GameViewModel()
        {
            //Games.Add(new Quiz { ID = 1, gameName = "Mario"});
        }

        public GameViewModel(List<Game> gameList)
        {
            Games = new ObservableCollection<Game>();
            foreach (Game gm in gameList)
            {
                Games.Add(gm);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
