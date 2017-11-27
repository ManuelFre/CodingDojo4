using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CodingDojo4_Server.Communication;
using System.Collections.ObjectModel;

namespace CodingDojo4_Server.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        RelayCommand StartStopBtnClickedCommand;
        RelayCommand AddMessageCommand;
        public ObservableCollection<String> ConnectedUsers { get; set; }
        public ObservableCollection<String> Message { get; set; }
        public int MessagesReceived { get; set; }
        //public string ConnectedUsers { get; set; }
        //public string Message { get; set; }
        public bool Start_Stop { get; set; }

        Server server;
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ConnectedUsers = new ObservableCollection<string>();
            Message = new ObservableCollection<string>();

            StartStopBtnClickedCommand = new RelayCommand(new Action(StartStopBtnClickedAction));
            AddMessageCommand = new RelayCommand(new Action(AddMessageAction));

        }

        private void AddMessageAction()
        {
            Message.Add(server.StartReceiving());
        }

        private void StartStopBtnClickedAction()
        {
            if (Start_Stop)
            {
                server = new Server();
            }
            else
            {
                server = null;
            }
            Start_Stop = !Start_Stop;
            RaisePropertyChanged("Start_Stop");
            
        }
    }
}