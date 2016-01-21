using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.Custom
{
    public delegate void EventHandler<T>(object sender, EventArgs<T> e);
}
