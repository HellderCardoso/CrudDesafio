using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Model
{
    public class __ScriptMigrationHistory : Entity
    {
        public string FileName { get; set; }
        protected __ScriptMigrationHistory() { }
        public __ScriptMigrationHistory(string fileName)
        {
            FileName = fileName;
        }
    }
}