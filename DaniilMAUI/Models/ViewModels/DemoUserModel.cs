//This code is not part of this project
//It shows how to dynamically change properties without ObservableObject



//using System.ComponentModel;

//namespace AccountSystem.Models.ViewModels
//{
//    partial class UserModel : INotifyPropertyChanged
//    {
//        private string userName;

//        public string UserName
//        {
//            get { return userName; }
//            set
//            {
//                userName = value;
//                NotifyPropertyChanged(nameof(UserName));
//            }
//        }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public bool PrimeUser { get; set; }

//        public event PropertyChangedEventHandler PropertyChanged;

//        private void NotifyPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
//}

