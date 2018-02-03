using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Wpf.Charts
{
    public partial class MainWindowState :INotifyPropertyChanged
    { 
        public MainWindowState(int height,int width, ResizeMode resizeMode)
        {
            _Height = height;
            _Width = width; 
            _ResizeMode = resizeMode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int MinHeight
        {
            get { return 600; }
            set { }
        }
        public int MinWidth
        {
            get { return 400; }
            set { }
        }

        public int Height
        {
            get { return _Height; }
            set
            {
                if (Equals(_Height, value)) return;

                //if (value >= 600) { value = 600; }
                if (value <= MinHeight) { value = MinHeight; }

                _Height = value;
                PropertyChanged.Raise(() => Height);
            }
        }
        private int _Height;

        public int Width
        {
            get { return _Width; }
            set
            {
                if (Equals(_Width, value)) return;

                //if (value >= 300) { value = 300; }
                if (value <= MinWidth) { value = MinWidth; }

                _Width = value;
                PropertyChanged.Raise(() => Width);
            }
        }
        private int _Width;

        public ResizeMode ResizeMode
        {
            get { return _ResizeMode; }
            set
            {
                if (Equals(_ResizeMode, value)) return;

                _ResizeMode = value;
                PropertyChanged.Raise(() => _ResizeMode);
            }
        }
        private ResizeMode _ResizeMode;
    }
}
