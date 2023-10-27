using SchoolManager.entity.@interface;
using System.ComponentModel;

namespace SchoolManager.entity
{
    //组合模式中的叶子类
    internal class Student:ISchool
    {
        public int Sid { get; set; }

        private string sname;
        public string Sname
        {
            get => sname;
            set
            {
                sname = value;
                OnPropertyChanged(nameof(sname));
            }
        }
        public int FromClass {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int GetCount()
        {
            return 1;
        }
    }
}
