using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Models;

namespace MassDefect
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new MassDefectContext();
            context.Database.Initialize(true);
        }
    }
}
