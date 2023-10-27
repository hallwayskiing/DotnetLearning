using SchoolManager.entity.@interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.entity
{
    //组合模式中的结点类
    public class Class : ISchool
    {
        public int Cid {  get; set; }

        private string cname;
        public string Cname
        {
            get => cname;
            set
            {
                cname = value;
                OnPropertyChanged(nameof(cname));
            }
        }

        public int Count
        {
            get { return GetCount(); }
        }
        public List<ISchool> Children { get; set; }

        public Class()
        {
            Children = new List<ISchool>();
        }

        public int GetCount()
        {
            int count = 0;
            Children.ForEach(child =>
            {
                count += child.GetCount();
            });
            return count;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
