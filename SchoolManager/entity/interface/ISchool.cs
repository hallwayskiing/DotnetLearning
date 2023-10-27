using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.entity.@interface
{
    //使用设计模式：组合模式
    public interface ISchool:INotifyPropertyChanged
    {
        int GetCount();
    }
}
