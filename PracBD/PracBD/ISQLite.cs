using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PracBD
{
   public interface ISQLite
    {
        String GetLocalFilePath(string Filename);
    }
}
