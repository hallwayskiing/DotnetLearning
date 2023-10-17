using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileBrowser
{
    public class FileNode
    {
        public string FileName {  get; set; }
        public string LastAccess {  get; set; }
        public string Path {  get; set; }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; ImageSource = $"/icons/{value}.png";}
        }
        public string ImageSource {  get; private set; }
        public long Size {  get; set; }
        public List<FileNode> Children { get; set; }
        
        public FileNode()
        {
            FileName=string.Empty;
            LastAccess=string.Empty;
            Path=string.Empty;
            type=string.Empty;
            ImageSource=string.Empty;
            Size = 0;
            Children = new List<FileNode>();
        }
    }
}
