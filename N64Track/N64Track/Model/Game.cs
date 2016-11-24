using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace N64Track
{
    public class Game : INotifyPropertyChanged
    {
        public Game()
        {

        }

        int _ID;
        string _Name;
        string _Year;
        string _Developer;
        string _Publisher;
        string _Region;
        string _Players;
        string _ESRB;
        string _Genre;
        string _URL;
        string _Review;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string Year
        {
            get { return _Year; }
            set
            {
                _Year = value;
                OnPropertyChanged();
            }
        }

        public string Developer
        {
            get { return _Developer; }
            set
            {
                _Developer = value;
                OnPropertyChanged();
            }
        }

        public string Publisher
        {
            get { return _Publisher; }
            set
            {
              _Publisher   = value;
                OnPropertyChanged();
            }
        }

        public string Region
        {
            get { return _Region; }
            set
            {
                _Region = value;
                OnPropertyChanged();
            }
        }

        public string Players
        {
            get { return _Players; }
            set
            {
                _Players = value;
                OnPropertyChanged();
            }
        }

        public string ESRB
        {
            get { return _ESRB; }
            set
            {
                _ESRB = value;
                OnPropertyChanged();
            }
        }
        public string Genre
        {
            get { return _Genre; }
    set
            {
                _Genre = value;
                OnPropertyChanged();
}
        }
        public string URL
        {
            get { return _URL; }
            set
            {
                _URL = value;
                OnPropertyChanged();
            }
        }
        
        public string Review
        {
            get { return _Review; }
            set
            {
                _Review = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
