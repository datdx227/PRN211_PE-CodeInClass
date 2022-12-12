using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class CheckBox
    {
        public string Text { get; set; }
        public bool _checked;

		public bool Checked
		{
			get { return _checked; }
			set {
				if(_checked != value)
				{
					if(CheckChanged != null)
					{
						CheckChanged(Text, value);
					}
				} 
				_checked = value; 
			}
		}
		//Tạo sự kiện checkchang
		public delegate void handle(string text, bool check);
		public event handle CheckChanged;

	}
}
